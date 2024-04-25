using Mediatek86.dal;
using Mediatek86.controller;
using System;
using System.Drawing;
using Mediatek86.Vue;
using System.Windows.Forms;


namespace Mediatek86
{
    public partial class Login : Form
    {
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        //Instance du controller qui gère l'authentification
        FormAuthController formAuthController = new FormAuthController();

        public Login()
        {
            InitializeComponent();
            
            //Redéfinit la taille des textBox
            this.usernameTxt.AutoSize = false;
            this.usernameTxt.Size = new System.Drawing.Size(209, 27);
            this.passwordTxt.AutoSize = false;
            this.passwordTxt.Size = new System.Drawing.Size(209, 27);
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Login_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Login_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void connexionBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Vérifie si les champs de nom d'utilisateur et de mot de passe sont remplis
                if (usernameTxt.Text != "" && passwordTxt.Text != "")
                {
                    // Vérifie les informations d'identification en utilisant le FormAuthController
                    bool authIsValid = formAuthController.CheckCredentials(usernameTxt.Text, passwordTxt.Text);

                    // Si les informations d'identification sont valides, affiche un message de succès
                    if (authIsValid)
                    {
                        MessageBox.Show("Connexion à la base de données établie !", "Succès", MessageBoxButtons.OK);
                        Accueil accueilForm = new Accueil();
                        accueilForm.Owner = this;
                        this.Visible = false;
                        accueilForm.Show();

                    }
                    else
                    {
                        MessageBox.Show("Les identifiants sont incorrects !");
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez remplir tous les champs !");
                }
            }
            catch (Exception ex)
            {
                // En cas d'erreur, affiche un message d'erreur à l'utilisateur
                MessageBox.Show($"Erreur lors de la connexion à la base de données : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
