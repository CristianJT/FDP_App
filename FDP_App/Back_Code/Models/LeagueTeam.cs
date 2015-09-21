using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.FDP
{
    public class LeagueTeam
    {
        public LeagueTeam()
        {
            Points = 0;
            Played = 0;
            Won = 0;
            Draws = 0;
            Lost = 0;
            GoalsFor = 0;
            GoalsAgainst = 0;
            GoalDifference = 0;
        }

        [Key]
        [Column(Order = 1)]
        public int LeagueId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int TeamId { get; set; }

        public int Points { get; set; }
        public int Played { get; set; }
        public int Won { get; set; }
        public int Draws { get; set; }
        public int Lost { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int GoalDifference { get; set; }


        public virtual League League { get; set; }
        public virtual Team Team { get; set; }

    }
}