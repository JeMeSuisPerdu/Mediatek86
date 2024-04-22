using System;
using System.Collections.Generic;
using Mediatek86.dal;
namespace Mediatek86.controller
{
    public class FormAuthController
    {
        Access access = Access.GetInstance();
        public bool CheckCredentials(string username, string password)
        {
            if(access.Manager != null)
            {
                //Requête SQL de type select avec des paramètres pour éviter les injections SQL
                string req = "SELECT * FROM responsable WHERE login = @username AND pwd = SHA2(@password,256)";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    {"@username", username },
                    {"@password", password }
                };
                try
                {
                    // Exécute la requête SQL avec les paramètres
                    List<Object[]> reqExecution = access.Manager.ReqSelect(req, parameters);

                    // Vérifie si des enregistrements ont été retournés
                    return (reqExecution != null && reqExecution.Count > 0);
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Erreur lors de la vérification des informations de connexion : {ex.Message}");
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
