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
                leagueTeam.LeagueId = leagueTeamDTO.league_id;
                leagueTeam.TeamId = leagueTeamDTO.team_id;
                leagueTeam.Points = leagueTeamDTO.points;
                leagueTeam.Played = leagueTeamDTO.played;
                leagueTeam.Won = leagueTeamDTO.won;
                leagueTeam.Draws = leagueTeamDTO.draws;
                leagueTeam.Lost = leagueTeamDTO.lost;
                leagueTeam.GoalsAgainst = leagueTeamDTO.goals_against;
                leagueTeam.GoalsFor = leagueTeamDTO.goals_for;
                leagueTeam.GoalDifference = leagueTeamDTO.goal_difference;

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
                game.GameNumber = gameDTO.GameNumber;
                game.IsSpecialGame = gameDTO.IsSpecialGame;
                game.IsCurrent = gameDTO.IsCurrent;

                game.Matches = new List<Match>();
                foreach (var matchDTO in gameDTO.Matches)
                {
                    Match match = new Match();
                    match.MatchId = matchDTO.match_id;
                    match.Game = game;
                    //match.MatchDate = matchDTO.MatchDate;
                    match.IsConfirm = matchDTO.is_confirm;
                    match.HomeTeam = matchDTO.home_team;
                    match.AwayTeam = matchDTO.away_team;
                    match.HomeResult = matchDTO.home_result;
                    match.AwayResult = matchDTO.away_result;

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
