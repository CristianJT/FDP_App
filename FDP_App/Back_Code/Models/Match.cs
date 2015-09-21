using System;
using System.ComponentModel.DataAnnotations;

namespace App.FDP
{
    public class Match
    {
        public Match()
        {
            State = MatchState.assigned;
        }

        public int Id { get; set; }
        public int GameId { get; set; }
        public int StadiumId { get; set; }
        public DateTime? MatchDate { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public int? HomeResult { get; set; }
        public int? AwayResult { get; set; }
        public MatchState State { get; set; }
        public int? PlayedMinutes { get; set; }

        public virtual Game Game { get; set; }
        public virtual Stadium Stadium { get; set; }
        public virtual Team HomeTeam { get; set; }
        public virtual Team AwayTeam { get; set; }
    }

    public enum MatchState
    {
        assigned = 1,
        confirmed = 2,
        finished = 3,
        suspended = 4,
        postponed = 5,
    }
}
