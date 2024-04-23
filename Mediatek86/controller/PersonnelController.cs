﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Mediatek86.dal;
using Mediatek86.modele;

namespace Mediatek86.controller
{
    public class PersonnelController
    {
        //instance de Access
        private Access access = Access.GetInstance();

        public void PersonnelGridData(DataGridView dataPersonnelGridName)
        {
            if(access.Manager != null)
            {
                string req = "SELECT * FROM personnel";
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

        public void ShowPersonnelInfo(DataGridView dataPersonnelGridName, TextBox nomPersonnelTxtbox, TextBox prenomPersonnelTxtbox, TextBox telPersonnelTxtbox, TextBox emailPersonnelTxtbox)
        {

            if (access.Manager !=null && dataPersonnelGridName.SelectedRows.Count > 0)
            {
                try
                {
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

                foreach(Object[] columnTable in reqPersonnel)
                {
                    int idService = Convert.ToInt32(columnTable[0]);
                    string nomService = Convert.ToString(columnTable[1]);

                    //On déclare IdService comme clé
                    listeService.ValueMember = "IdService";
                    //On déclare NomService comme valeur
                    listeService.DisplayMember = "NomService";
                    //On ajoute à la liste un objet sans nom qui associe IdService à idService...
                    listeService.Items.Add(new { IdService = idService, NomService = nomService});
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de récupération des services : " + ex.Message);
            }
        }
        public void UpdatePersonnel(DataGridView dataPersonnelGridName)
        {
            MessageBox.Show("Êtes vous sûr de vouloir modifier ce personnel ?", "Confirmation modification");
        }


    }
}
