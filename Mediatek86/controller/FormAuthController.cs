using System;
using System.Collections.Generic;
using Mediatek86.dal;
namespace Mediatek86.controller
{
    /// <summary>
    /// Classe controller qui gère la logique d'authentification
    /// </summary>
    public class FormAuthController
    {
        /// <summary>
        /// Instance de la classe Access pour la connexion à la bdd
        /// </summary>
        Access access = Access.GetInstance();

        /// <summary>
        /// Vérifie les informations d'identifications
        /// </summary>
        /// <param name="username">nom d'utilisateur du responsable</param>
        /// <param name="password">mdp du responsable</param>
        /// <returns></returns>
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

                    // Vérifie si des donnees ont été retournés
                    return (reqExecution != null && reqExecution.Count > 0);
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Erreur lors de la vérification des informations de connexion :" + ex.Message);
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
