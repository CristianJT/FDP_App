﻿using System;

namespace Entities.Models
{
    public class LeagueTeam
    {
        public LeagueTeam()
        {
            this.Points = 0;
            this.Played = 0;
            this.Won = 0;
            this.Draws = 0;
            this.Lost = 0;
            this.GoalsFor = 0;
            this.GoalsAgainst = 0;
            this.GoalDifference = 0;
        }

        public int LeagueId { get; set; }
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