using Entities.Models;
using System;
using System.Collections.Generic;

namespace FDP_App.DTOs
{
    public class LeaguesDTO
    {
        public LeaguesDTO(League l)
        {
            if (l != null)
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
            if (l != null)
            {
                this.LeagueId = l.LeagueId;
                this.Name = l.Name;
                this.Season = l.Season;
                this.StartDate = l.StartDate;
                this.FinishDate = l.FinishDate;
                this.IsCurrent = l.IsCurrent;
                this.Champion = l.Champion;
                this.RelegatedTeams = l.RelegatedTeams;

                List<TeamsLeagueDTO> teamList = new List<TeamsLeagueDTO>();
                foreach (LeagueTeam t in l.Teams)
                {
                    teamList.Add(new TeamsLeagueDTO(t));
                }
                this.Teams = teamList.ToArray();

                this.Fixture = new FixtureLeagueDTO(l.Fixture);
            }
        }

        public int LeagueId { get; set; }
        public string Name { get; set; }
        public int Season { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public bool IsCurrent { get; set; }
        public string Champion { get; set; }
        public int RelegatedTeams { get; set; }
        public TeamsLeagueDTO[] Teams { get; set; }
        public FixtureLeagueDTO Fixture { get; set; }
    }
    public class TeamsLeagueDTO
    {
        public TeamsLeagueDTO(LeagueTeam tl)
        {
            if (tl != null)
            {
                this.TeamId = tl.TeamId;
                this.LeagueId = tl.LeagueId;
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
        }

        public int TeamId { get; set; }
        public int LeagueId { get; set; }
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

    public class FixtureLeagueDTO
    {
        public FixtureLeagueDTO(Fixture f)
        {
            if (f != null)
            {
                this.LeagueId = f.LeagueId;
                this.TotalGames = f.TotalGames;
                this.SpecialGame = f.SpecialGame;
                List<GameDTO> gameList = new List<GameDTO>();
                foreach (Game g in f.Games)
                {
                    gameList.Add(new GameDTO(g));
                }
                this.Games = gameList.ToArray();
            }
        }
        public int LeagueId { get; set; }
        public int TotalGames { get; set; }
        public int SpecialGame { get; set; }
        public GameDTO[] Games { get; set; }
    }
    public class GameDTO
    {
        public GameDTO(Game g)
        {
            if (g != null)
            {
                this.GameId = g.GameId;
                this.LeagueId = g.LeagueId;
                this.GameNumber = g.GameNumber;
                this.IsSpecialGame = g.IsSpecialGame;
                this.IsCurrent = g.IsCurrent;
                List<MatchDTO> matchList = new List<MatchDTO>();
                foreach (Match m in g.Matches)
                {
                    matchList.Add(new MatchDTO(m));
                }
                this.Matches = matchList.ToArray();
            }
        }

        public int GameId { get; set; }
        public int LeagueId { get; set; }
        public int GameNumber { get; set; }
        public bool IsSpecialGame { get; set; }
        public bool IsCurrent { get; set; }
        public MatchDTO[] Matches { get; set; }
    }
    public class MatchDTO
    {
        public MatchDTO(Match m)
        {
            if (m != null)
            {
                this.MatchId = m.MatchId;
                this.GameId = m.GameId;
                this.MatchDate = m.MatchDate;
                this.IsConfirm = m.IsConfirm;
                this.HomeTeam = m.HomeTeam;
                this.AwayTeam = m.AwayTeam;
                this.HomeResult = m.HomeResult;
                this.AwayResult = m.AwayResult;
            }
        }

        public int MatchId { get; set; }
        public int GameId { get; set; }
        public DateTime? MatchDate { get; set; }
        public bool IsConfirm { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public int HomeResult { get; set; }
        public int AwayResult { get; set; }
    }

    public class TeamsDTO
    {
        public TeamsDTO(Team t)
        {
            if (t != null)
            {
                this.TeamId = t.TeamId;
                this.Name = t.Name;
                this.Stadium = t.Stadium;
                this.City = t.City;
                this.IsTopDivision = t.IsTopDivision;
            }
        }

        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Stadium { get; set; }
        public string City { get; set; }
        public bool IsTopDivision { get; set; }
    }
    public class TeamsDetailDTO
    {
        public TeamsDetailDTO(Team t)
        {
            if (t != null)
            {
                this.TeamId = t.TeamId;
                this.Name = t.Name;
                this.Stadium = t.Stadium;
                this.City = t.City;
                this.IsTopDivision = t.IsTopDivision;

                List<LeaguesTeamDTO> leagueList = new List<LeaguesTeamDTO>();
                foreach (LeagueTeam l in t.Leagues)
                {
                    leagueList.Add(new LeaguesTeamDTO(l));
                }
                this.Leagues = leagueList.ToArray();
            }
        }

        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Stadium { get; set; }
        public string City { get; set; }
        public bool IsTopDivision { get; set; }
        public LeaguesTeamDTO[] Leagues { get; set; }
    }
    public class LeaguesTeamDTO
    {
        public LeaguesTeamDTO(LeagueTeam lt)
        {
            if (lt != null)
            {
                this.LeagueId = lt.LeagueId;
                this.Season = lt.League.Season;
                this.League = lt.League.Name;
                this.Played = lt.Played;
                this.Points = lt.Points;
            }
        }

        public int LeagueId { get; set; }
        public string League { get; set; }
        public int Season { get; set; }
        public int Points { get; set; }
        public int Played { get; set; }
    }
}
