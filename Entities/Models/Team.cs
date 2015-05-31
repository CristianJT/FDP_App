using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public class Team
    {
        public Team()
        {
            this.Leagues = new HashSet<LeagueTeam>();
        }

        public Guid TeamId { get; set; }

        public string Name { get; set; }
        public string Stadium { get; set; }
        public string City { get; set; }
        public bool IsTopDivision { get; set; }

        public virtual ICollection<LeagueTeam> Leagues { get; set; }
    }
}