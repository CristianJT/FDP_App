using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.FDP
{

    public class TeamIdsDTO
    {
        public int[] ids { get; set; }
    }

    public class TeamDTO
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int estadio_id { get; set; }
        public string ubicacion { get; set; }
        public bool es_primera_division { get; set; }

        public TeamDTO()
        {

        }
        public TeamDTO(Team t)
        {
            id = t.Id;
            nombre = t.Name;
            estadio_id = t.StadiumId;
            ubicacion = t.Location;
            es_primera_division = t.IsTopDivision;
        }

    }

    public class TeamLeagueDTO
    {
        public int equipo_id { get; set; }
        public int torneo_id { get; set; }
        public string nombre { get; set; }
        public int puntos { get; set; }
        public int jugados { get; set; }
        public int ganados { get; set; }
        public int empatados { get; set; }
        public int perdidos { get; set; }
        public int goles_favor { get; set; }
        public int goles_contra { get; set; }
        public int goles_diferencia { get; set; }

        public TeamLeagueDTO()
        {

        }
        public TeamLeagueDTO(LeagueTeam tl)
        {
            equipo_id = tl.TeamId;
            torneo_id = tl.LeagueId;
            nombre = tl.Team.Name;
            puntos = tl.Points;
            jugados = tl.Played;
            ganados = tl.Won;
            empatados = tl.Draws;
            perdidos = tl.Lost;
            goles_favor = tl.GoalsFor;
            goles_contra = tl.GoalsAgainst;
            goles_diferencia = tl.GoalDifference;
        }

       
    }

}
