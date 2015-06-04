using System.Collections.Generic;

namespace Entities.Models
{
    public class Fixture
    {
        public Fixture()
        {
            this.SpecialGame = 0;
            this.Games = new HashSet<Game>();
        }

        public int LeagueId { get; set; }
        public int TotalGames { get; set; }
        public int SpecialGame { get; set; }

        public virtual League League { get; set; }
        public virtual ICollection<Game> Games { get; set; }
    }
}
