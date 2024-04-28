using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatek86.modele
{
    /// <summary>
    /// Classe définissant la structure d'un personnel
    /// </summary>
    public class Personnel
    {
        /// <summary>
        /// Constructeur de la classe personnel
        /// </summary>
        /// <param name="idPersonnel">identifiant d'un personnel</param>
        /// <param name="nom">nom d'un personnel</param>
        /// <param name="prenom">prenom d'un personnel</param>
        /// <param name="tel">numero de tel d'un personnel</param>
        /// <param name="mail">email d'un personnel</param>
        /// <param name="idService">liste des services d'un personnel</param>
        public Personnel(int idPersonnel, string nom, string prenom, string tel, string mail, int idService) 
        {
            this.IdPersonnel = idPersonnel;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Tel = tel;
            this.Mail = mail;
            this.IdService = idService;
        }

        /// <summary>
        /// Getter et setter sur IdPersonnel
        /// </summary>
        public int IdPersonnel { get; set; }

        /// <summary>
        /// Getter et setter sur Nom
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Getter et setter sur Prenom
        /// </summary>
        public string Prenom { get; set; }

        /// <summary>
        /// Getter et setter sur Tel
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// Getter et setter sur Mail
        /// </summary>
        public string Mail { get; set; }

        /// <summary>
        /// Getter et setter sur IdService
        /// </summary>
        public int IdService { get; set; }
    }
}
