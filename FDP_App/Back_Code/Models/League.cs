using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.FDP
{
    public class League
    {

        public League()
        {
            this.Teams = new HashSet<LeagueTeam>();
        }

        [Key]
        public int LeagueId { get; set; }

        public string Name { get; set; }
        public int Season { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public bool IsCurrent { get; set; }
        public string Champion { get; set; }
        public int RelegatedTeams { get; set; }

        public virtual ICollection<LeagueTeam> Teams { get; set; }
        public virtual Fixture Fixture { get; set; }

    }

   
}
