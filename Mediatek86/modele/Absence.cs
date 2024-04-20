using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatek86.modele
{
    public class Absence
    {
        public Absence(int idPersonnel, DateTime dateDebut, DateTime dateFin, int idMotif) 
        {
            this.IdPersonnel = idPersonnel;
            this.DateDebut = dateDebut;
            this.DateFin = dateFin;
            this.IdMotif = idMotif;
        }
        public int IdPersonnel { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public int IdMotif { get; set; }

    }
}
