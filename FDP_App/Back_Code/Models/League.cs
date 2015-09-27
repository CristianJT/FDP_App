using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.FDP
{
    public class League
    {

        public League()
        {
            Teams = new HashSet<LeagueTeam>();
            Games = new HashSet<Game>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Season { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public bool IsCurrent { get; set; }
        public string Champion { get; set; }
        public int? RelegatedTeams { get; set; }
        public int TotalGames { get; set; }
        public int TotalTeams { get; set; }
        public int? SpecialGame { get; set; }

        public virtual ICollection<LeagueTeam> Teams { get; set; }
        public virtual ICollection<Game> Games { get; set; }

    }

   
}
