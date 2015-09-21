using System;
using System.ComponentModel.DataAnnotations;

namespace App.FDP
{
    public class Match
    {
        public Match()
        {
            this.MatchDate = DateTime.Today;
            this.IsConfirm = false;
        }

        [Key]
        public int MatchId { get; set; }
        public int GameId { get; set; }
        public DateTime MatchDate { get; set; }
        public bool IsConfirm { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public int? HomeResult { get; set; }
        public int? AwayResult { get; set; }

        public virtual Game Game { get; set; }
    }
}
