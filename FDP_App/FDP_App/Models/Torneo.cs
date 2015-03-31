using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDP_App.Models
{
    public class Torneo
    {
        public Torneo()
        {
            this.Equipos = new HashSet<Equipo>();
            this.Fixture = new HashSet<Fecha>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Equipo> Equipos { get; set; }
        public virtual ICollection<Fecha> Fixture { get; set; }

    }
}