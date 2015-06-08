using Entities.Models;
using System.Collections.Generic;

namespace FDP_App.DTOs
{
    public class MapToEntities
    {
        public void LeagueDTOtoEntity(ref League league, LeaguesDetailDTO leagueDTO)
        {
            league.LeagueId = leagueDTO.LeagueId;
            league.Season = leagueDTO.Season;
            league.Name = leagueDTO.Name;
            league.StartDate = leagueDTO.StartDate;
            league.FinishDate = leagueDTO.FinishDate;
            league.IsCurrent = leagueDTO.IsCurrent;
            league.Champion = leagueDTO.Champion;

            league.Teams = new List<LeagueTeam>();
            foreach (var leagueTeamDTO in leagueDTO.Teams)
            {
                LeagueTeam leagueTeam = new LeagueTeam();
                leagueTeam.LeagueId = leagueTeamDTO.LeagueId;
                leagueTeam.TeamId = leagueTeamDTO.TeamId;
                leagueTeam.Points = leagueTeamDTO.Points;
                leagueTeam.Played = leagueTeamDTO.Played;
                leagueTeam.Won = leagueTeamDTO.Won;
                leagueTeam.Draws = leagueTeamDTO.Draws;
                leagueTeam.Lost = leagueTeamDTO.Lost;
                leagueTeam.GoalsAgainst = leagueTeamDTO.GoalsAgainst;
                leagueTeam.GoalsFor = leagueTeamDTO.GoalsFor;
                leagueTeam.GoalDifference = leagueTeamDTO.GoalDifference;

                league.Teams.Add(leagueTeam);
            }

            league.Fixture = new Fixture();
            league.Fixture.LeagueId = leagueDTO.Fixture.LeagueId;
            league.Fixture.TotalGames = leagueDTO.Fixture.TotalGames;
            league.Fixture.SpecialGame = leagueDTO.Fixture.SpecialGame;
            league.Fixture.League = league;

            league.Fixture.Games = new List<Game>();
            foreach (var gameDTO in leagueDTO.Fixture.Games)
            {
                Game game = new Game();
                game.GameId = gameDTO.GameId;
                game.Fixture = league.Fixture;

                game.Matches = new List<Match>();
                foreach (var matchDTO in gameDTO.Matches)
                {
                    Match match = new Match();
                    match.MatchId = matchDTO.MatchId;
                    match.Game = game;
                    match.HomeTeam = matchDTO.HomeTeam;
                    match.AwayTeam = matchDTO.AwayTeam;
                    match.HomeResult = matchDTO.HomeResult;
                    match.AwayResult = matchDTO.AwayResult;

                    game.Matches.Add(match);

                }

                league.Fixture.Games.Add(game);
            }
        }

        public void TeamDTOtoEntity(ref Team team, TeamsDTO teamDTO)
        {
            team.TeamId = teamDTO.TeamId;
            team.Name = teamDTO.Name;
            team.Stadium = teamDTO.Stadium;
            team.City = teamDTO.City;
            team.IsTopDivision = teamDTO.IsTopDivision;
        }
    }
}
