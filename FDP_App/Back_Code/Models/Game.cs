using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.FDP
{
    public class Game
    {

        public Game()
        {
            this.Matches = new HashSet<Match>();
        }

        [Key]
        public int GameId { get; set; }
        public int LeagueId { get; set; }
        public int GameNumber { get; set; }
        public bool IsSpecialGame { get; set; }
        public bool IsCurrent { get; set; }

        public virtual Fixture Fixture { get; set; }
        public virtual ICollection<Match> Matches { get; set; }

    }
}
