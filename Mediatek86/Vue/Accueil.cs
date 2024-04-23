using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mediatek86.controller;

namespace Mediatek86.Vue
{
    public partial class Accueil : Form
    {
        //instance de PersonnelController
        PersonnelController unPersonnel = new PersonnelController();

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

        public Accueil()
        {
            InitializeComponent();
        }

        private void Accueil_Load(object sender, EventArgs e)
        {
            //utilisation de PersonnelGridData pour remplir le dataGridView
            unPersonnel.PersonnelGridData(personnelGrid);

            //redesign des tailles des grid grâce dataGridColumnsResizing
            dataGridColumnsResizing(personnelGrid, "72-80-81-80-168-57", '-');

        }

        private void supprimerPersonnelBtn_Click(object sender, EventArgs e)
        {
            //methode de suppression du personnel dans la grid + base de donnée
            unPersonnel.DeletePersonnel(personnelGrid);
        }

        private void modifierPersonnelBtn_Click(object sender, EventArgs e)
        {
            //Methode qui affiche les infos de la ligne selectionnée
            unPersonnel.ShowPersonnelInfo(personnelGrid, nomPersonnelTxt, prenomPersonnelTxt, telPersonnelTxt, emailPersonnelTxt);
            unPersonnel.SelectService(servicePersonnelLst);
            //Changement de taille du form pour afficher les textbox 
            this.Size = new Size(1326, 717);
            //Empêche la selection dans la dataGridView dès qu'on appuie sur modifier
            personnelGrid.Enabled = false;
            
        }

        private void enregistrerPersonnelBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
