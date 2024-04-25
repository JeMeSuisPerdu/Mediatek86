using System;
using System.Drawing;
using System.Windows.Forms;
using Mediatek86.controller;


namespace Mediatek86.Vue
{
    public partial class Accueil : Form
    {
        //instance de PersonnelController
        readonly PersonnelController unPersonnel = new PersonnelController();
        readonly AbsenceController uneAbsence = new AbsenceController();

        //Petite methode pour redefinir la width des column...Ouais...j'ai vraiment fais ca...
        public void dataGridColumnsResizing(DataGridView gridName, string sizesString, char separator)
        {
            // sépare la chaîne des tailles en utilisant un séparateur 
            string[] sizesArray = sizesString.Split(separator);

            // Vérifie que le nb de tailles est égale au nb de colonnes dans la DataGridView
            if (gridName.Columns.Count != sizesArray.Length)
            {
                throw new ArgumentException("Le nombre de tailles doit correspondre au nombre de colonnes dans la DataGridView.");
            }

            // Boucle qui redimensionne les colonnes 
            for (int i = 0; i < sizesArray.Length; i++)
            {
                // convertit la string en int
                int size;
                if (!int.TryParse(sizesArray[i], out size))
                {
                    Console.WriteLine("La chaîne de tailles n'est pas au format correct.");
                }
                gridName.Columns[i].Width = size;
            }
        }
        public void actualiserDataGridView()
        {
            // Utilise la méthode pour charger les données dans la DataGridView et absence
            uneAbsence.AbsenceGridData(absenceGrid,personnelGrid);
        }
        public int getIdPersonnelAbsence()
        {
            return (int)personnelGrid.SelectedRows[0].Cells["IdPersonnel"].Value;
        }
        public Accueil()
        {
            InitializeComponent();
        }

        private void Accueil_Load(object sender, EventArgs e)
        {
            //utilisation de PersonnelGridData pour remplir le dataGridView
            unPersonnel.PersonnelGridData(personnelGrid);
            //redesign des tailles des grid grâce dataGridColumnsResizing
            dataGridColumnsResizing(personnelGrid, "72-80-81-80-168-70", '-');

            // Formate les 2 dateTimepicker pour afficher la date et l'heure
            dateDebutPick.Format = DateTimePickerFormat.Custom;
            dateDebutPick.CustomFormat = "dd/MM/yyyy HH:mm";
            dateFinPick.Format = DateTimePickerFormat.Custom;
            dateFinPick.CustomFormat = "dd/MM/yyyy HH:mm";
        }

        private void supprimerPersonnelBtn_Click(object sender, EventArgs e)
        {
            //methode de suppression du personnel dans la grid + base de donnée
            unPersonnel.DeletePersonnel(personnelGrid);
        }

        private void modifierPersonnelBtn_Click(object sender, EventArgs e)
        {
            //Methode qui affiche les infos de la ligne selectionnée
            unPersonnel.ShowPersonnelInfo(personnelGrid, nomPersonnelTxt, prenomPersonnelTxt, telPersonnelTxt, emailPersonnelTxt, modifierPersonnelBtn);
            unPersonnel.SelectService(servicePersonnelLst);

            //Empêche la selection dans la dataGridView dès qu'on appuie sur modifier
            personnelGrid.Enabled = false;
            updatePersonnelGrpBox.Enabled = true;
        }

        private void enregistrerPersonnelBtn_Click(object sender, EventArgs e)
        {
            unPersonnel.UpdatePersonnel(personnelGrid, nomPersonnelTxt, prenomPersonnelTxt, telPersonnelTxt, emailPersonnelTxt, servicePersonnelLst, modifierPersonnelBtn, updatePersonnelGrpBox);
        }

        private void annulerPersonnelBtn_Click(object sender, EventArgs e)
        {
            personnelGrid.Enabled = true;
            modifierPersonnelBtn.Enabled = true;
            servicePersonnelLst.Items.Clear();
            updatePersonnelGrpBox.Enabled = false;
        }

        private void ajouterPersonnelBtn_Click(object sender, EventArgs e)
        {
            // Créer une instance de AjouterPersonnel et définit Accueil comme proprio
            AjouterPersonnel ajouterPersonnelForm = new AjouterPersonnel();
            ajouterPersonnelForm.Owner = this;
            //Cache la page d'accueil
            this.Visible = false;
            // Affiche AjouterPersonnel
            ajouterPersonnelForm.Show();
        }

        private void gestionnaireAbsBtn_Click(object sender, EventArgs e)
        {
            //Change la couleur du texte dans la grid en noir
            this.absenceGrid.DefaultCellStyle.ForeColor = Color.Black;

            if (personnelGrid.SelectedRows.Count > 0)
            {
                absGrpBox.Enabled = true;
                uneAbsence.AbsenceGridData(absenceGrid, personnelGrid);
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un personnel !");
            }
        }

        private void supprimerAbsBtn_Click(object sender, EventArgs e)
        {
            uneAbsence.DeleteAbsence(absenceGrid, personnelGrid);
        }

        private void modifierAbsBtn_Click(object sender, EventArgs e)
        {
            uneAbsence.ShowAbsenceInfo(absenceGrid, dateDebutPick, dateFinPick, modifierAbsBtn);
            uneAbsence.SelectMotif(motifAbsLst);
            updateAbsGrpBox.Enabled = true;
            absenceGrid.Enabled = false;
        }

        private void enregistrerAbsBtn_Click(object sender, EventArgs e)
        {
            uneAbsence.UpdateAbsence(absenceGrid, personnelGrid, dateDebutPick, dateFinPick, motifAbsLst, modifierAbsBtn, absGrpBox);
        }

        private void annulerAbsBtn_Click(object sender, EventArgs e)
        {
            updateAbsGrpBox.Enabled = false;
            absenceGrid.Enabled = true;
            modifierAbsBtn.Enabled = true;
            motifAbsLst.Items.Clear();
        }

        private void AjouterAbsBtn_Click(object sender, EventArgs e)
        {
            // Créer une instance de AjouterAbsence et définit Accueil comme proprio
            AjouterAbsence ajouterAbsenceForm = new AjouterAbsence();
            ajouterAbsenceForm.Owner = this;
            //Cache la page d'accueil
            this.Visible = false;
            // Affiche AjouterPersonnel
            ajouterAbsenceForm.Show();
        }
    }
}
