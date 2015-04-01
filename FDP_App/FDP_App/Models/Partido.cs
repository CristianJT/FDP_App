using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FDP_App.Models
{
    public class Partido
    {
        public int Id { get; set; }
        public int LocalId { get; set; }
        public int VisitanteId { get; set; }
        public int FechaId { get; set; }

        public DateTime FechaHora { get; set; }
        public string Estadio { get; set; }
        public bool Clasico { get; set; }
        public int LocalRes { get; set; }
        public int VisitanteRes { get; set; }

        //public virtual Equipo Local { get; set; }
        //public virtual Equipo Visitante { get; set; }
        public virtual Fecha Fecha { get; set; }
    }
}