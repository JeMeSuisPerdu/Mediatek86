using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Mediatek86.dal;
using Mediatek86.modele;

namespace Mediatek86.controller
{
    /// <summary>
    /// Classe qui permet de gérer la logique métier et de controle pour les absences
    /// </summary>
    class AbsenceController
    {
        /// <summary>
        /// Instance de la classe Access pour vérifier la connexion à la BDD
        /// </summary>
         private Access access = Access.GetInstance();

        /// <summary>
        /// Methode qui charge la dataGridVue des absences avec les données de la bdd
        /// </summary>
        /// <param name="dataAbsenceGridName">dataGridView des absences</param>
        /// <param name="personnelGridName">dataGridView du personnel</param>
        public void AbsenceGridData(DataGridView dataAbsenceGridName, DataGridView personnelGridName)
        {
            if (access.Manager != null)
            {
                try
                {
                    //Id du personnel récupéré dans la grid du personnel
                    string personnelId = personnelGridName.SelectedRows[0].Cells["IdPersonnel"].Value.ToString();

                    //Dictionnaire pour eviter l'injection sql contenant l'id du personnel
                    Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        {"@personnelId", personnelId }
                    };

                    //Requete select avec tri croissant en fonction de l'id du personnel
                    string req = "SELECT * FROM absence WHERE idpersonnel=@personnelId";
                    List<Object[]> reqAbsence = access.Manager.ReqSelect(req, parameters);
                    List<Absence> lesAbsences = new List<Absence>();

                    //boucle foreach pour récupérer les valeur dans la table absence
                    foreach (Object[] columnTable in reqAbsence)
                    {
                        Absence uneAbsence = new Absence(Convert.ToInt32(columnTable[0]),
                            Convert.ToDateTime(columnTable[1]),
                            Convert.ToDateTime(columnTable[2]),
                            Convert.ToInt32(columnTable[3]));
                        lesAbsences.Add(uneAbsence);
                    }
                    //Ajoute la liste d'absence à la datagridView
                    dataAbsenceGridName.DataSource = lesAbsences;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("La requête SELECT envoyée à la base de données a échoué : " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("La connexion à la base de données a échoué !");
            }
        }

        /// <summary>
        /// Methode CRUD pour supprimer une absence dans la BDD + la dataGridView 
        /// </summary>
        /// <param name="dataAbsenceGridName">dataGridView des absences</param>
        /// <param name="personnelGridName">dataGridView du personnel</param>
        public void DeleteAbsence(DataGridView dataAbsenceGridName, DataGridView personnelGridName)
        {
            if (access.Manager != null && dataAbsenceGridName.SelectedRows.Count > 0)
            {
                DialogResult response = MessageBox.Show("Etes vous sûr de vouloir supprimer cette absence ?", "Confirmation de suppression", MessageBoxButtons.OKCancel);
                if (response == DialogResult.OK)
                {
                    string req = "DELETE FROM absence WHERE idpersonnel=@personnelId AND datedebut = @dateDebut;";
                    try
                    {
                        //Prends la valeur de la ligne selectionner qui est égale à IdPersonnel et la convertit en str
                        string personnelId = dataAbsenceGridName.SelectedRows[0].Cells["IdPersonnel"].Value.ToString();
                        DateTime dateDebut = (DateTime) dataAbsenceGridName.SelectedRows[0].Cells["DateDebut"].Value;
                        //Création d'un paramètre pour éviter les injections sql
                        Dictionary<string, object> parameters = new Dictionary<string, object>
                        {
                            {"@personnelId", personnelId },
                            {"@dateDebut", dateDebut }
                        };

                        //Execution de la requête 
                        access.Manager.ReqUpdate(req, parameters);
                        //Actualisation de l'affichage de la dataGridView
                        AbsenceGridData(dataAbsenceGridName, personnelGridName);

                        MessageBox.Show("L'absence sélectionnée a été supprimée !");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("La requête DELETE envoyée à la base de donnée a echouée : " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Aucune absence sélectionnée pour la suppression.");
            }
        }

        /// <summary>
        /// Methode qui permet d'afficher des données (dans un form...)
        /// </summary>
        /// <param name="dataAbsenceGridName">dataGridView des absences</param>
        /// <param name="dateDebutActuelle">date de début de l'absence avant modification (type DateTimePicker)</param>
        /// <param name="dateFinActuelle">date de fin de l'absence avant modification (type DateTimePicker)</param>
        /// <param name="modifierBtn">le bouton modifier</param>
        public void ShowAbsenceInfo(DataGridView dataAbsenceGridName, DateTimePicker dateDebutActuelle, DateTimePicker dateFinActuelle, Button modifierBtn)
        {

            if (access.Manager != null && dataAbsenceGridName.SelectedRows.Count > 0)
            {
                try
                {
                    //Désactive le bouton modifier pour eviter la duplication dans la liste services.
                    modifierBtn.Enabled = false;
                    // Récupère le texte de chaque cellule de la dataGridView en fonction du titre de la colonne
                    DateTime personnelNom = (DateTime)dataAbsenceGridName.SelectedRows[0].Cells["DateDebut"].Value;
                    DateTime personnelPrenom = (DateTime)dataAbsenceGridName.SelectedRows[0].Cells["DateFin"].Value;

                    //Attribut à chaque textbox le texte récupéré dans la dataGridView
                    dateDebutActuelle.Value = personnelNom;
                    dateFinActuelle.Value = personnelPrenom;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de la sélection des données ! " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Methode qui permet d'initialiser la liste des Motifs
        /// </summary>
        /// <param name="listeMotif"></param>
        public void SelectMotif(ListBox listeMotif)
        {
            string req = "SELECT idmotif, libelle FROM motif";
            try
            {
                List<Object[]> reqMotif = access.Manager.ReqSelect(req);

                foreach (Object[] columnTable in reqMotif)
                {
                    int idMotif = Convert.ToInt32(columnTable[0]);
                    string nomMotif = Convert.ToString(columnTable[1]);
                    //On ajoute à la liste un objet KeyValuePair qui associe IdService à idService...
                    listeMotif.Items.Add(new KeyValuePair<int, string>(idMotif, nomMotif));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de récupération des services : " + ex.Message);
            }
        }

        /// <summary>
        /// Methode CRUD pour mettre à jour une absence dans la BDD + la dataGridView. Et gère la visibilité de la groupBox + bouton modifier.
        /// </summary>
        /// <param name="dataAbsenceGridName">dataGridView des absences</param>
        /// <param name="dataPersonnelGridName">dataGridView du personnel</param>
        /// <param name="dateDebut">date de début d'une absence après modification</param>
        /// <param name="dateFin">date de fin d'une absence après modification</param>
        /// <param name="listeMotif">liste des motifs pour une absence</param>
        /// <param name="modifierBtn">le bouton modifier</param>
        /// <param name="groupeBox">ensemble des élements graphiques faisant partie du groupe des absences</param>
        public void UpdateAbsence(DataGridView dataAbsenceGridName, DataGridView dataPersonnelGridName, DateTimePicker dateDebut, DateTimePicker dateFin, ListBox listeMotif, Button modifierBtn, GroupBox groupeBox)
        {
            try
            {
                if ( listeMotif.SelectedIndex != -1)
                {
                    DialogResult response = MessageBox.Show("Êtes vous sûr de vouloir modifier cette absence ?", "Confirmation modification", MessageBoxButtons.OKCancel);
                    if (response == DialogResult.OK)
                    {
                        // Requête d'update avec parametres
                        string req = "UPDATE absence SET idpersonnel=@idPersonnel, datedebut=@dateDebutUpdate, datefin=@dateFinUpdate, idmotif=@idMotif WHERE idpersonnel=@idPersonnel AND datedebut=@dateDebutInitiale";

                        // Définition des variables utilisés pour définir les paramètres (Les valeurs update qu'on envoie à la DB)
                        DateTime dateDebutInitial = (DateTime)dataAbsenceGridName.SelectedRows[0].Cells["DateDebut"].Value;
                        DateTime dateDebutUpdate = dateDebut.Value;
                        DateTime dateFinUpdate = dateFin.Value;
                        int idPersonnel = Convert.ToInt32(dataAbsenceGridName.SelectedRows[0].Cells["IdPersonnel"].Value);

                        // récupère la clé de la pair Clé / Valeur définie dans la méthode SelectMotif()
                        KeyValuePair<int, string> selectedMotif = (KeyValuePair<int, string>)listeMotif.SelectedItem;

                        // Récupère l'ID du motif à partir de l'élément sélectionné
                        int idMotif = selectedMotif.Key;

                        //Condition pour vérifier la date
                        if (dateFinUpdate < dateDebutUpdate)
                        {
                            MessageBox.Show("La date de fin ne peut pas être antérieure à la date de début.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; 
                        }

                        //Dictionnaire des paramètres pour éviter les injections sql
                        Dictionary<string, object> parameters = new Dictionary<string, object>
                        {
                            {"@dateDebutInitiale", dateDebutInitial },
                            {"@dateDebutUpdate", dateDebutUpdate },
                            {"@dateFinUpdate", dateFinUpdate },
                            {"@idMotif", idMotif },
                            {"@idPersonnel", idPersonnel }
                        };

                        //Execution de la requete
                        access.Manager.ReqUpdate(req, parameters);
                        //Actualise la Grid
                        AbsenceGridData(dataAbsenceGridName, dataPersonnelGridName);

                        //Reactive le bouton modifier
                        modifierBtn.Enabled = true;
                        //Reactive la DataGridView
                        dataAbsenceGridName.Enabled = true;
                        //Vide la liste pour éviter les doublons
                        listeMotif.Items.Clear();
                        //Visibilité de la groupebox sur false
                        groupeBox.Enabled = false;
                    }

                    if (response == DialogResult.Cancel)
                    {
                        groupeBox.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Tous les champs doivent êtres remplis, et un motif sélectionné ! ");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur les modifications n'ont pas aboutis : ", ex.Message);
            }

        }

        /// <summary>
        /// Methode CRUD qui ajoute une absence pour un personnel dans la grid et dans la BDD
        /// </summary>
        /// <param name="idPersonnel">identifiant d'un personnel</param>
        /// <param name="dateDebut">date de début sélectionnée par l'utilisateur</param>
        /// <param name="dateFin">date de fin sélectionnée par l'utilisateur</param>
        /// <param name="listeMotif"></param>
        public void AddAbsence(int idPersonnel,DateTimePicker dateDebut, DateTimePicker dateFin, ListBox listeMotif)
        {
            try
            {
                if (listeMotif.SelectedIndex != -1)
                {
                    string req = "INSERT INTO absence(idpersonnel,datedebut,datefin,idmotif) VALUES(@IdPersonnel,@DateDebut,@DateFin,@IdMotif)";

                    // Définition des variables utilisés pour définir les paramètres (Les valeurs update qu'on envoie à la DB)
                    DateTime dateDebutAjout = dateDebut.Value;
                    DateTime dateFinAjout = dateFin.Value;
                    KeyValuePair<int, string> selectedMotif = (KeyValuePair<int, string>)listeMotif.SelectedItem;

                    // Récupère l'ID du service à partir de l'élément sélectionné
                    int idMotif = selectedMotif.Key;

                    Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        {"@DateDebut", dateDebutAjout },
                        {"@DateFin", dateFinAjout },
                        {"@IdMotif", idMotif },
                        {"@IdPersonnel", idPersonnel }
                    };
                    //Execution de la requête
                    access.Manager.ReqUpdate(req, parameters);
                   
                }
                else
                {
                    MessageBox.Show("Tous les champs doivent êtres remplis, et un motif sélectionné ! ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur les modifications n'ont pas aboutis : ", ex.Message);
            }
        }
    }
}
