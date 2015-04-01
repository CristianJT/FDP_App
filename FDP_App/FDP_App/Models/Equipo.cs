using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FDP_App.Models
{
    public class Equipo
    {
        public Equipo()
        {
            //this.Partidos = new HashSet<Partido>();

            this.Jugados = 0;
            this.Puntos = 0;
            this.Ganados = 0;
            this.Empatados = 0;
            this.Perdidos = 0;
            this.GolesFavor = 0;
            this.GolesContra = 0;
            this.Diferencia = 0;
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Estadio { get; set; }
        public string Ubicacion { get; set; }
        public int? TorneoId { get; set; }

        public int Puntos { get; set; }
        public int Jugados { get; set; }
        public int Ganados { get; set; }
        public int Empatados { get; set; }
        public int Perdidos { get; set; }
        public int GolesFavor { get; set; }
        public int GolesContra { get; set; }
        public int Diferencia { get; set; }

        public virtual Torneo Torneo { get; set; }
        //public virtual ICollection<Partido> Partidos { get; set; }
    }
}