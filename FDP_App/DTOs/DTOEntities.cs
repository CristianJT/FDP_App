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

            List<TeamsLeagueDTO> teamList = new List<TeamsLeagueDTO>();
            foreach (LeagueTeam t in l.Teams)
            {
                teamList.Add(new TeamsLeagueDTO(t));
            }
            this.Teams = teamList.ToArray();
        }

        public int LeagueId { get; set; }
        public string Name { get; set; }
        public int Season { get; set; }
        public int RelegatedTeams { get; set; }
        public TeamsLeagueDTO[] Teams { get; set; }
    }

    public class TeamsLeagueDTO
    {
        public TeamsLeagueDTO(LeagueTeam tl)
        {
            this.TeamId = tl.TeamId;
            this.Name = tl.Team.Name;
            this.Points = tl.Points;
            this.Played = tl.Played;
            this.Won = tl.Won;
            this.Draws = tl.Draws;
            this.Lost = tl.Lost;
            this.GoalsFor = tl.GoalsFor;
            this.GoalsAgainst = tl.GoalsAgainst;
            this.GoalDifference = tl.GoalDifference;
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

    public class TeamsDTO
    {
        public TeamsDTO(Team t)
        {
            this.TeamId = t.TeamId;
            this.Name = t.Name;
            this.Stadium = t.Stadium;
            this.City = t.City;
            this.IsTopDivision = t.IsTopDivision;
        }

        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Stadium { get; set; }
        public string City { get; set; }
        public bool IsTopDivision { get; set; }
    }
}
