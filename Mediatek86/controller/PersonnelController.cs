using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Mediatek86.dal;
using Mediatek86.modele;

namespace Mediatek86.controller
{
    public class PersonnelController
    {
        private Access access = Access.GetInstance();
        public void PersonnelGridData(DataGridView dataGridName)
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
                    dataGridName.DataSource = lesPersonnels;
               
                }catch(Exception ex)
                {
                    Console.WriteLine("La requête envoyé à la base de donnée a echouée" + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Connexion à la base de donnée échouée !");
            }
        }
    }
}
