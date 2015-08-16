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
        public FixtureLeagueDTO()
        {

        }
        public FixtureLeagueDTO(Fixture f)
        {
            this.league_id = f.LeagueId;
            this.total_games = f.TotalGames;
            this.special_game = f.SpecialGame;
            List<GameDTO> gameList = new List<GameDTO>();
            foreach (Game g in f.Games)
            {
                gameList.Add(new GameDTO(g));
            }
            this.games = gameList.ToArray();
        }
        public int league_id { get; set; }
        public int total_games { get; set; }
        public int special_game { get; set; }
        public GameDTO[] games { get; set; }
    }
    public class GameDTO
    {
        public GameDTO()
        {

        }
        public GameDTO(Game g)
        {
            this.game_id = g.GameId;
            this.league_id = g.LeagueId;
            this.game_number = g.GameNumber;
            this.is_special_game = g.IsSpecialGame;
            this.is_current = g.IsCurrent;
            List<MatchDTO> matchList = new List<MatchDTO>();
            foreach (Match m in g.Matches)
            {
                matchList.Add(new MatchDTO(m));
            }
            this.matches = matchList.ToArray();
        }

        public int game_id { get; set; }
        public int league_id { get; set; }
        public int game_number { get; set; }
        public bool is_special_game { get; set; }
        public bool is_current { get; set; }
        public MatchDTO[] matches { get; set; }
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
        public TeamsDTO()
        {

        }
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
    public class TeamsDetailDTO
    {
        public TeamsDetailDTO()
        {

        }
        public TeamsDetailDTO(Team t)
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
