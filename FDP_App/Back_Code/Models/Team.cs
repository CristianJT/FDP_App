using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.FDP
{
    public class Team
    {
        public Team()
        {
            Leagues = new HashSet<LeagueTeam>();
        }

        public int Id { get; set; }
        public int StadiumId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public bool IsTopDivision { get; set; }

        public virtual ICollection<LeagueTeam> Leagues { get; set; }
        public virtual Stadium Stadium { get; set; }
    }
}