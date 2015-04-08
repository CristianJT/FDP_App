using FDP_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace FDP_App.DAL
{
    public class TorneoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }     
    }

    public class TorneoDetailDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Decripcion { get; set; }
        
        //public EquipoDTO[] Equipos { get; set; }

        //public TorneoDetailDTO(Torneo t)
        //{
        //    this.Id = t.Id;
        //    this.Nombre = t.Nombre;
        //    List<EquipoDTO> listaEquipos = new List<EquipoDTO>();
        //    foreach (Equipo e in t.Equipos)
        //    {
        //        listaEquipos.Add(new EquipoDTO(e));
        //    }
        //    this.Equipos = listaEquipos.ToArray();
        //}

        //public TorneoDetailDTO()
        //{
            
        //}
    }


    public class EquipoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Puntos { get; set; }
        public int Jugados { get; set; }
        public int Ganados { get; set; }
        public int Empatados { get; set; }
        public int Perdidos { get; set; }
        public int GolesFavor { get; set; }
        public int GolesContra { get; set; }
        public int Diferencia { get; set; }
    }

    public class EquipoDetailDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Estadio { get; set; }
        public string Ubicacion { get; set; }
        public int? TorneoId { get; set; }
    }
}