using System;
using System.Drawing;
using System.Windows.Forms;
using Mediatek86.controller;

namespace Mediatek86.Vue
{
    /// <summary>
    /// Classe AjouterPersonnel heritant de Form
    /// </summary>
    public partial class AjouterPersonnel : Form
    {
        /// <summary>
        /// Permet de drag le form sans les bordure de base.
        /// </summary>
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        /// <summary>
        /// Instance de PersonnelController
        /// </summary>
        readonly PersonnelController unPersonnel = new PersonnelController();

        /// <summary>
        /// Classe qui initialise le form d'ajout de personnel
        /// </summary>
        public AjouterPersonnel()
        {
            InitializeComponent();
        }

        private void AjouterPersonnel_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void AjouterPersonnel_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void AjouterPersonnel_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void AjouterPersonnel_Load(object sender, EventArgs e)
        {
            unPersonnel.SelectService(servicePersonnelLst);
        }

        private void ajouterPersonnelBtn_Click(object sender, EventArgs e)
        {
            DialogResult response = MessageBox.Show("Voulez vous vraiment ajouter ce personnel ?", "Confirmation ajout d'un personnel", MessageBoxButtons.OKCancel);
            if(response == DialogResult.OK)
            {
                unPersonnel.AddPersonnel(nomPersonnelTxt, prenomPersonnelTxt, telPersonnelTxt, emailPersonnelTxt, servicePersonnelLst);
                //Créer une instance d'accueil qui est la page principal
                Accueil accueil = (Accueil)this.Owner;
                //Actualise la grid dans accueil
                accueil.actualiserDataGridView();
                //Rend la page d'accueil visible
                accueil.Visible = true;
                //Ferme la page d'ajout du personnel
                this.Close();
            }
        }

        private void annulerPersonnelBtn_Click(object sender, EventArgs e)
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
