using System;

namespace App.FDP
{
    public class LeagueDTO
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int temporada { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
        public bool en_progreso { get; set; }
        public string campeon { get; set; }
        public int? cantidad_descensos { get; set; }
        public int total_fechas { get; set; }
        public int total_equipos { get; set; }
        public int? fecha_especial_numero { get; set; }

        public LeagueDTO()
        {

        }

        public LeagueDTO(League l)
        {
            id = l.Id;
            nombre = l.Name;
            temporada = l.Season;
            fecha_inicio = l.StartDate;
            fecha_fin = l.FinishDate;
            en_progreso = l.IsCurrent;
            campeon = l.Champion;

            if (l.RelegatedTeams.HasValue)
            {
                cantidad_descensos = l.RelegatedTeams;
            }
         
            total_fechas = l.TotalGames;
            total_equipos = l.TotalTeams;

            if (l.SpecialGame.HasValue)
            {
                fecha_especial_numero = l.SpecialGame;
            }

        }
        
    }

}
