using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDP_App.Models
{
    public class Fecha
    {
        public Fecha()
        {
            this.Partidos = new HashSet<Partido>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int TorneoId { get; set; }

        public virtual ICollection<Partido> Partidos { get; set; }
        public virtual Torneo Torneo { get; set; }
    }
}