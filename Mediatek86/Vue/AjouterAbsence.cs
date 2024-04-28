using System;
using System.Drawing;
using System.Windows.Forms;
using Mediatek86.controller;

namespace Mediatek86.Vue
{
    /// <summary>
    /// Classe AjouterAbsence heritant de Form
    /// </summary>
    public partial class AjouterAbsence : Form
    {
        /// <summary>
        /// Permet le mouvement du formulaire meme sans border style. (Aide de stackoverflow pour le faire)
        /// </summary>
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        /// <summary>
        /// Instance d'AbscenceController
        /// </summary>
        readonly AbsenceController uneAbsence = new AbsenceController();

        /// <summary>
        /// Classe qui initialise le form d'ajout d'absence
        /// </summary>
        public AjouterAbsence()
        {
            InitializeComponent();
        }

        private void AjouterAbsence_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void AjouterAbsence_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void AjouterAbsence_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void AjouterAbsence_Load(object sender, EventArgs e)
        {
            uneAbsence.SelectMotif(motifAbsLst);
            // Formate les 2 dateTimepicker pour afficher la date et l'heure
            dateDebutAbs.Format = DateTimePickerFormat.Custom;
            dateDebutAbs.CustomFormat = "dd/MM/yyyy HH:mm";
            dateFinAbs.Format = DateTimePickerFormat.Custom;
            dateFinAbs.CustomFormat = "dd/MM/yyyy HH:mm";
        }

        private void AjouterAbsBtn_Click(object sender, EventArgs e)
        {
            DialogResult response = MessageBox.Show("Voulez vous vraiment ajouter cette absence ?", "Confirmation ajout d'une absence", MessageBoxButtons.OKCancel);
            if (response == DialogResult.OK)
            {
                //Créer une instance d'accueil qui est la page principal
                Accueil accueil = (Accueil)this.Owner;
                //Appeler la fonction qui retourne l'idPersonnel pour lier l'absence au personnel
                int idPersonnel = accueil.getIdPersonnelAbsence();
                //Appel de la méthode d'ajout d'une absence
                uneAbsence.AddAbsence(idPersonnel, dateDebutAbs, dateFinAbs, motifAbsLst);
                //Actualise la grid dans accueil
                accueil.actualiserDataGridView();
                //Rend la page d'accueil visible
                accueil.Visible = true;
                //Ferme la page d'ajout du personnel
                this.Close(); 
            }

        }

        private void AnnulerAbsBtn_Click(object sender, EventArgs e)
        {
            //Créer une instance d'accueil qui est la page principal
            Accueil accueil = (Accueil)this.Owner;
            //Actualise la grid dans accueil
            accueil.actualiserDataGridView();
            //Rend la page d'accueil visible
            accueil.Visible = true;
            this.Close();
        }
    }
}
