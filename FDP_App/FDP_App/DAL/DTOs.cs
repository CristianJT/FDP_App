using FDP_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDP_App.DAL
{
    public class TorneoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Decripcion { get; set; }
        public EquipoDTO[] Equipos { get; set; }
    }

    public class EquipoDTO
    {
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

        public EquipoDTO(Equipo e)
        {
            this.Id = e.Id;
            this.Nombre = e.Nombre;
            this.Estadio = e.Estadio;
            this.Ubicacion = e.Ubicacion;
            this.TorneoId = e.TorneoId;
            this.Puntos = e.Puntos;
            this.Jugados = e.Jugados;
            this.Ganados = e.Ganados;
            this.Empatados = e.Empatados;
            this.Perdidos = e.Perdidos;
            this.GolesFavor = e.GolesFavor;
            this.GolesContra = e.GolesContra;
            this.Diferencia = e.Diferencia;
        }
    }
}