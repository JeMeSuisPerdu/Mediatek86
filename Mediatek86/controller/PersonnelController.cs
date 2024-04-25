using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Mediatek86.dal;
using Mediatek86.modele;

namespace Mediatek86.controller
{
    public class PersonnelController
    {
        //instance de la classe Access
        private Access access = Access.GetInstance();

        //Methode qui charge les données dans la dataGridView
        public void PersonnelGridData(DataGridView dataPersonnelGridName)
        {
            if(access.Manager != null)
            {
                string req = "SELECT * FROM personnel ORDER BY idpersonnel ASC";
                try
                {
                    List<Object[]> reqPersonnel = access.Manager.ReqSelect(req);
                    List<Personnel> lesPersonnels = new List<Personnel>();

                    //foreach pour récupérer les info de chaque personnel via la requete select
                    foreach(Object[] columnTable in reqPersonnel)
                    {
                        //Création d'unPersonnel de type Personnel répondant aux critères du constructeur de Personnel, et convertissant les infos recu de la requête SELECT
                        Personnel unPersonnel = new Personnel(Convert.ToInt32(columnTable[0]),
                            Convert.ToString(columnTable[1]),
                            Convert.ToString(columnTable[2]),
                            Convert.ToString(columnTable[3]),
                            Convert.ToString(columnTable[4]),
                            Convert.ToInt32(columnTable[5]));

                        //Ajout de chaque personnel dans la liste lesPersonnels
                        lesPersonnels.Add(unPersonnel);
                    }
                    //Lier la liste lesPersonnels à la dataGridView
                    dataPersonnelGridName.DataSource = lesPersonnels;
               
                }catch(Exception ex)
                {
                    Console.WriteLine("La requête SELECT envoyé à la base de donnée a echouée" + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Connexion à la base de donnée échouée !");
            }
        }

        //Methodes CRUD sur un personnel
        public void DeletePersonnel(DataGridView dataPersonnelGridName)
        {
            if(access.Manager != null && dataPersonnelGridName.SelectedRows.Count > 0)
            {
                DialogResult response = MessageBox.Show("Etes vous sûr de vouloir supprimer ce personnel ?", "Confirmation de suppression", MessageBoxButtons.OKCancel);
                if (response == DialogResult.OK)
                {
                    string req = "DELETE FROM personnel WHERE idpersonnel=@personnelId";
                    try
                    {
                        //Prends la valeur de la ligne selectionner qui est égale à IdPersonnel et la convertit en str
                        string personnelId = dataPersonnelGridName.SelectedRows[0].Cells["IdPersonnel"].Value.ToString();
                        //Création d'un paramètre pour éviter les injections sql
                        Dictionary<string, object> parameters = new Dictionary<string, object>
                        {
                            {"@personnelId", personnelId }
                        };

                        //Execution de la requête 
                        access.Manager.ReqUpdate(req, parameters);
                        //Actualisation de l'affichage de la dataGridView en appelant PersonnelGridData
                        PersonnelGridData(dataPersonnelGridName);

                        MessageBox.Show("Le personnel sélectionné a été supprimé !");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("La requête DELETE envoyée à la base de donnée a echouée : " + ex.Message);
                    }
                }     
            }
            else
            {
                MessageBox.Show("Aucun personnel sélectionné pour la suppression.");
            }
        }
        public void ShowPersonnelInfo(DataGridView dataPersonnelGridName, TextBox nomPersonnelTxtbox, TextBox prenomPersonnelTxtbox, TextBox telPersonnelTxtbox, TextBox emailPersonnelTxtbox, Button modifierBtn)
        {

            if (access.Manager !=null && dataPersonnelGridName.SelectedRows.Count > 0)
            {
                try
                {
                    //Désactive le bouton modifier pour eviter la duplication dans la liste services.
                    modifierBtn.Enabled = false;
                    // Récupère le texte de chaque cellule de la dataGridView en fonction du titre de la colonne
                    string personnelNom = dataPersonnelGridName.SelectedRows[0].Cells["Nom"].Value.ToString();
                    string personnelPrenom = dataPersonnelGridName.SelectedRows[0].Cells["Prenom"].Value.ToString();
                    string personnelTel = dataPersonnelGridName.SelectedRows[0].Cells["Tel"].Value.ToString();
                    string personnelEmail = dataPersonnelGridName.SelectedRows[0].Cells["Mail"].Value.ToString();

                    //Attribut à chaque textbox le texte récupéré dans la dataGridView
                    nomPersonnelTxtbox.Text = personnelNom;
                    prenomPersonnelTxtbox.Text = personnelPrenom;
                    telPersonnelTxtbox.Text = personnelTel;
                    emailPersonnelTxtbox.Text = personnelEmail;

                }
                catch(Exception ex)
                {
                    MessageBox.Show("Erreur lors de la sélection des données ! " + ex.Message);
                }              
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner au moins un personnel à modifier ! ");
            }
        }
        public void SelectService(ListBox listeService)
        {
            string req = "SELECT idservice, nom FROM service";
            try
            {
                List<Object[]> reqPersonnel = access.Manager.ReqSelect(req);

                foreach (Object[] columnTable in reqPersonnel)
                {
                    int idService = Convert.ToInt32(columnTable[0]);
                    string nomService = Convert.ToString(columnTable[1]);
                    //On ajoute à la liste un objet KeyValuePair qui associe IdService à idService...
                    listeService.Items.Add(new KeyValuePair<int, string>(idService, nomService));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de récupération des services : " + ex.Message);
            }
        }
        public void UpdatePersonnel(DataGridView dataPersonnelGridName, TextBox nomPersonnelTxtbox, TextBox prenomPersonnelTxtbox, TextBox telPersonnelTxtbox, TextBox emailPersonnelTxtbox, ListBox listeService, Button modifierBtn, GroupBox groupeBox)
        {
            try
            {
                if (nomPersonnelTxtbox.Text != "" && prenomPersonnelTxtbox.Text != "" && telPersonnelTxtbox.Text != "" && emailPersonnelTxtbox.Text != "" && listeService.SelectedIndex != -1)
                {
                    DialogResult response = MessageBox.Show("Êtes vous sûr de vouloir modifier ce personnel ?", "Confirmation modification", MessageBoxButtons.OKCancel);
                    if (response == DialogResult.OK)
                    {
                        // Requête d'update avec parametres
                        string req = "UPDATE personnel SET nom=@updateNom, prenom=@updatePrenom, tel=@updateTel, mail=@updateEmail, idservice=@updateIdService WHERE idpersonnel=@idPersonnel";

                        // Définition des variables utilisés pour définir les paramètres (Les valeurs update qu'on envoie à la DB)
                        string updateNom = nomPersonnelTxtbox.Text;
                        string updatePrenom = prenomPersonnelTxtbox.Text;
                        string updateTel = telPersonnelTxtbox.Text;
                        string updateEmail = emailPersonnelTxtbox.Text;
                        int idPersonnel = Convert.ToInt32(dataPersonnelGridName.SelectedRows[0].Cells["IdPersonnel"].Value);
                        // récupère la clé de la pair Clé / Valeur définie dans la méthode SelectService()
                        KeyValuePair<int, string> selectedService = (KeyValuePair<int, string>)listeService.SelectedItem;

                        // Récupère l'ID du service à partir de l'élément sélectionné
                        int updateIdService = selectedService.Key;

                        Dictionary<string, object> parameters = new Dictionary<string, object>
                        {
                            {"@updateNom", updateNom },
                            {"@updatePrenom", updatePrenom },
                            {"@updateTel", updateTel },
                            {"@updateEmail", updateEmail },
                            {"@updateIdService", updateIdService },
                            {"@idPersonnel", idPersonnel }
                        };

                        //Execution de la requete
                        access.Manager.ReqUpdate(req, parameters);
                        //Actualise la Grid
                        PersonnelGridData(dataPersonnelGridName);

                        //Reactive le bouton modifier
                        modifierBtn.Enabled = true;
                        //Reactive la DataGridView
                        dataPersonnelGridName.Enabled = true;
                        //Vide la liste pour éviter les doublons
                        listeService.Items.Clear();
                        //Visibilité de la groupebox sur false
                        groupeBox.Enabled = false;
                    }
                    if(response == DialogResult.Cancel)
                    {
                        groupeBox.Enabled = true;
                    }
                } else
                {
                    MessageBox.Show("Tous les champs doivent êtres remplis, et un service sélectionné ! ");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur les modifications n'ont pas aboutis : ", ex.Message);
            }
    
        }
        public void AddPersonnel(TextBox nomPersonnelTxtbox, TextBox prenomPersonnelTxtbox, TextBox telPersonnelTxtbox, TextBox emailPersonnelTxtbox, ListBox listeService) 
        {
            try
            {
                if (nomPersonnelTxtbox.Text != "" && prenomPersonnelTxtbox.Text != "" && telPersonnelTxtbox.Text != "" && emailPersonnelTxtbox.Text != "" && listeService.SelectedIndex != -1)
                {
                    string req = "INSERT INTO personnel(nom,prenom,tel,mail,idservice) VALUES(@Nom,@Prenom,@Tel,@Email,@IdService)";

                    // Définition des variables utilisés pour définir les paramètres (Les valeurs update qu'on envoie à la DB)
                    string nom = nomPersonnelTxtbox.Text;
                    string prenom = prenomPersonnelTxtbox.Text;
                    string tel = telPersonnelTxtbox.Text;
                    string email = emailPersonnelTxtbox.Text;

                    KeyValuePair<int, string> selectedService = (KeyValuePair<int, string>)listeService.SelectedItem;

                    // Récupère l'ID du service à partir de l'élément sélectionné
                    int idService = selectedService.Key;

                    Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        {"@Nom", nom },
                        {"@Prenom", prenom },
                        {"@Tel", tel },
                        {"@Email", email },
                        {"@IdService", idService }
                    };
                    //Execution de la requête
                    access.Manager.ReqUpdate(req, parameters);
                }
                else
                {
                    MessageBox.Show("Tous les champs doivent êtres remplis, et un service sélectionné ! ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur les modifications n'ont pas aboutis : ", ex.Message);
            }
        }

    }
}
