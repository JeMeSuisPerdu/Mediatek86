using Mediatek86.bddmanager;
using System;



namespace Mediatek86.dal
{
    public class Access
    {
        /// <summary>
        /// nom de connexion à la bdd
        /// </summary>
        private static readonly string connectionString = "server=localhost;user id=root;database=mediatek86;SslMode=none";
        /// <summary>
        /// instance unique de la classe
        /// </summary>
        private static Access instance = null;
        /// <summary>
        /// Getter sur l'objet d'accès aux données
        /// </summary>
        public BddManager Manager { get; }

        /// <summary>
        /// Création unique de l'objet de type BddManager
        /// Arrête le programme si l'accès à la BDD a échoué
        /// </summary>
        private Access()
        {
            try
            {
                // Créer une instance de BddManager
                Manager = BddManager.GetInstance(connectionString);
            }
            catch (Exception e)
            {
                // Remonter l'exception pour que le code appelant puisse la traiter
                throw new Exception("Erreur lors de la création de l'instance de BddManager", e);
            }
        }

        /// <summary>
        /// Création d'une seule instance de la classe
        /// </summary>
        /// <returns></returns>
        public static Access GetInstance()
        {
            if (instance == null)
            {
                instance = new Access();
            }
            return instance;
        }

    }
}
