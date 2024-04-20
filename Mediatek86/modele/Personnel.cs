using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatek86.modele
{
    public class Personnel
    {
        public Personnel(int idPersonnel, string nom, string prenom, string tel, string mail, int idService) 
        {
            this.IdPersonnel = idPersonnel;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Tel = tel;
            this.Mail = mail;
            this.IdService = idService;
        }

        public int IdPersonnel { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Tel { get; set; }
        public string Mail { get; set; }
        public int IdService { get; set; }
    }
}
