using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.FDP
{
    public class Game
    {

        public Game()
        {
            Matches = new HashSet<Match>();
        }

        public int Id { get; set; }
        public int LeagueId { get; set; }
        public int GameNumber { get; set; }
        public bool? IsSpecialGame { get; set; }
        public GameState? State { get; set; }

        public virtual League League { get; set; }
        public virtual ICollection<Match> Matches { get; set; }

    }

    public enum GameState
    {
        in_progress = 1,
        finished = 2,
        postponed = 3
    }

}
