using Entities.Models;
using System;
using System.Collections.Generic;

namespace FDP_App.DTOs
{
    public class LeaguesDTO
    {
        public LeaguesDTO(League l)
        {
            this.LeagueId = l.LeagueId;
            this.Name = l.Name;
            this.Season = l.Season;
            this.StartDate = l.StartDate;
            this.FinishDate = l.FinishDate;
            this.IsCurrent = l.IsCurrent;
            this.Champion = l.Champion;
            this.RelegatedTeams = l.RelegatedTeams;
        }

        public int LeagueId { get; set; }
        public string Name { get; set; }
        public int Season { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public bool IsCurrent { get; set; }
        public string Champion { get; set; }
        public int RelegatedTeams { get; set; }
    }

    public class LeaguesDetailDTO
    {
        public LeaguesDetailDTO(League l)
        {
            this.LeagueId = l.LeagueId;
            this.Name = l.Name;
            this.Season = l.Season;
            this.RelegatedTeams = l.RelegatedTeams;

            List<TeamDTO> teamList = new List<TeamDTO>();
            foreach (LeagueTeam t in l.Teams)
            {
                teamList.Add(new TeamDTO(t));
            }
            this.Teams = teamList.ToArray();
        }

        public int LeagueId { get; set; }
        public string Name { get; set; }
        public int Season { get; set; }
        public int RelegatedTeams { get; set; }
        public TeamDTO[] Teams { get; set; }
    }

    public class TeamDTO
    {

        public TeamDTO(LeagueTeam t)
        {
            this.TeamId = t.TeamId;
            this.Name = t.Team.Name;
            this.Points = t.Points;
            this.Played = t.Played;
            this.Won = t.Won;
            this.Draws = t.Draws;
            this.Lost = t.Lost;
            this.GoalsFor = t.GoalsFor;
            this.GoalsAgainst = t.GoalsAgainst;
            this.GoalDifference = t.GoalDifference;
        }

        public int TeamId { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public int Played { get; set; }
        public int Won { get; set; }
        public int Draws { get; set; }
        public int Lost { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int GoalDifference { get; set; }
    }
}
