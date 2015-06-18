using System.Collections.Generic;

namespace Entities.Models
{
    public class Game
    {

        public Game()
        {
            this.Matches = new HashSet<Match>();
        }

        public int GameId { get; set; }
        public int LeagueId { get; set; }
        public int GameNumber { get; set; }
        public bool IsSpecialGame { get; set; }
        public bool IsCurrent { get; set; }

        public virtual Fixture Fixture { get; set; }
        public virtual ICollection<Match> Matches { get; set; }

    }
}
