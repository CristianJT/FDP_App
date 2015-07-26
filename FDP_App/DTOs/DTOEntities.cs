using Entities.Models;
using System;
using System.Collections.Generic;

namespace FDP_App.DTOs
{
    public class LeaguesDTO
    {
        public LeaguesDTO()
        {

        }
        public LeaguesDTO(League l)
        {
            this.league_id = l.LeagueId;
            this.name = l.Name;
            this.season = l.Season;
            this.start_date = l.StartDate;
            this.finish_date = l.FinishDate;
            this.is_current = l.IsCurrent;
            this.champion = l.Champion;
            this.relegated_teams = l.RelegatedTeams;
        }

        public int league_id { get; set; }
        public string name { get; set; }
        public int season { get; set; }
        public DateTime start_date { get; set; }
        public DateTime finish_date { get; set; }
        public bool is_current { get; set; }
        public string champion { get; set; }
        public int relegated_teams { get; set; }
    }
    public class LeaguesDetailDTO
    {
        public LeaguesDetailDTO()
        {

        }
        public LeaguesDetailDTO(League l)
        {
            this.league_id = l.LeagueId;
            this.name = l.Name;
            this.season = l.Season;
            this.start_date = l.StartDate;
            this.finish_date = l.FinishDate;
            this.is_current = l.IsCurrent;
            this.champion = l.Champion;
            this.relegated_teams = l.RelegatedTeams;

            List<TeamsLeagueDTO> teamList = new List<TeamsLeagueDTO>();
            foreach (LeagueTeam t in l.Teams)
            {
                teamList.Add(new TeamsLeagueDTO(t));
            }
            this.teams = teamList.ToArray();

            this.fixture = new FixtureLeagueDTO(l.Fixture);
        }

        public int league_id { get; set; }
        public string name { get; set; }
        public int season { get; set; }
        public DateTime start_date { get; set; }
        public DateTime finish_date { get; set; }
        public bool is_current { get; set; }
        public string champion { get; set; }
        public int relegated_teams { get; set; }
        public TeamsLeagueDTO[] teams { get; set; }
        public FixtureLeagueDTO fixture { get; set; }
    }
    public class TeamsLeagueDTO
    {
        public TeamsLeagueDTO()
        {

        }
        public TeamsLeagueDTO(LeagueTeam tl)
        {
            this.team_id = tl.TeamId;
            this.league_id = tl.LeagueId;
            this.name = tl.Team.Name;
            this.points = tl.Points;
            this.played = tl.Played;
            this.won = tl.Won;
            this.draws = tl.Draws;
            this.lost = tl.Lost;
            this.goals_for = tl.GoalsFor;
            this.goals_against = tl.GoalsAgainst;
            this.goal_difference = tl.GoalDifference;
        }

        public int team_id { get; set; }
        public int league_id { get; set; }
        public string name { get; set; }
        public int points { get; set; }
        public int played { get; set; }
        public int won { get; set; }
        public int draws { get; set; }
        public int lost { get; set; }
        public int goals_for { get; set; }
        public int goals_against { get; set; }
        public int goal_difference { get; set; }
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
        public MatchDTO()
        {

        }
        public MatchDTO(Match m)
        {
            this.match_id = m.MatchId;
            this.game_id = m.GameId;
            this.match_date = m.MatchDate;
            this.is_confirm = m.IsConfirm;
            this.home_team = m.HomeTeam;
            this.away_team = m.AwayTeam;
            this.home_result = m.HomeResult;
            this.away_result = m.AwayResult;
        }

        public int match_id { get; set; }
        public int game_id { get; set; }
        public DateTime match_date { get; set; }
        public bool is_confirm { get; set; }
        public string home_team { get; set; }
        public string away_team { get; set; }
        public int? home_result { get; set; }
        public int? away_result { get; set; }
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
