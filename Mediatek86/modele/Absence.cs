using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatek86.modele
{
    /// <summary>
    /// Classe définissant la structure d'une absence
    /// </summary>
    public class Absence
    {
        /// <summary>
        /// Constructeur de la classe absence pour une absence
        /// </summary>
        /// <param name="idPersonnel">identifiant d'un personnel</param>
        /// <param name="dateDebut">date de début de l'absence</param>
        /// <param name="dateFin">date de fin de l'absence</param>
        /// <param name="idMotif">identifiant d'un motif</param>
        public Absence(int idPersonnel, DateTime dateDebut, DateTime dateFin, int idMotif) 
        {
            this.IdPersonnel = idPersonnel;
            this.DateDebut = dateDebut;
            this.DateFin = dateFin;
            this.IdMotif = idMotif;
        }
        /// <summary>
        /// Getter et setter sur IdPersonnel
        /// </summary>
        public int IdPersonnel { get; set; }

        /// <summary>
        /// Getter et setter sur DateDebut
        /// </summary>
        public DateTime DateDebut { get; set; }

        /// <summary>
        /// Getter et setter sur DateFin
        /// </summary>
        public DateTime DateFin { get; set; }

        /// <summary>
        /// Getter et setter sur IdMotif
        /// </summary>
        public int IdMotif { get; set; }

    }
}
