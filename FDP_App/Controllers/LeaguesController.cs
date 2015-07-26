using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Data.Services;
using Entities.Models;
using FDP_App.DTOs;
using Data;

namespace FDP_App.Controllers
{
    [RoutePrefix("api/leagues")]
    public class LeaguesController : ApiController
    {
        private FDPAppContext db = new FDPAppContext();
       
        /* GET: api/leagues */
        [Route("")]
        [HttpGet]
        [ResponseType(typeof(LeaguesDTO))]
        public IHttpActionResult GetLeagues()
        {
            var leagues = db.Leagues.ToArray();
            return Ok(leagues.Select(l => new LeaguesDTO(l)).ToArray());
        }

        /* GET: api/leagues/{id} */
        [Route("{id}", Name = "GetLeagueByIdRoute")]
        [HttpGet]
        [ResponseType(typeof(LeaguesDetailDTO))]
        public IHttpActionResult GetLeague(int id)
        {
            var league = db.Leagues.Where(l => l.LeagueId == id).FirstOrDefault();
            if (league == null)
            {
                return NotFound();
            }

            return Ok(new LeaguesDetailDTO(league));
        }

        /* PUT: api/leagues/{id} */
        [Route("{id}")]
        [HttpPut]
        [ResponseType(typeof(LeaguesDTO))]
        public IHttpActionResult UpdateLeague(int id, LeaguesDTO leagueDto)
        {
            if (id != leagueDto.league_id)
            {
                return BadRequest();
            }

            var league = db.Leagues.Where(l => l.LeagueId == id).FirstOrDefault();
            if (league == null)
            {
                return NotFound();
            }

            league.Champion = leagueDto.champion;
            league.IsCurrent = leagueDto.is_current;
            db.SaveChanges();

            return Ok(new LeaguesDTO(league));
        }

        /* POST: api/leagues */
        [Route("")]
        [HttpPost]
        [ResponseType(typeof(LeaguesDetailDTO))]
        public IHttpActionResult CreateLeague(LeaguesDetailDTO leagueDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            League league = new League();
            LeagueDTOtoEntity(ref league, leagueDTO);

            db.Leagues.Add(league);
            db.SaveChanges();

            return CreatedAtRoute("GetLeagueByIdRoute", new { id = league.LeagueId }, new LeaguesDetailDTO(league));
        }

        /* DELETE: api/leagues/{id} */
        [Route("{id}")]
        [HttpDelete]
        [ResponseType(typeof(LeaguesDetailDTO))]
        public IHttpActionResult DeleteLeague(int id)
        {
            var league = db.Leagues.Where(l => l.LeagueId == id).FirstOrDefault();
            if (league == null)
            {
                return NotFound();
            }

            db.Leagues.Remove(league);
            db.SaveChanges();

            return Ok(new LeaguesDetailDTO(league));
        }

        public void LeagueDTOtoEntity(ref League league, LeaguesDetailDTO leagueDTO)
        {
            league.LeagueId = leagueDTO.league_id;
            league.Season = leagueDTO.season;
            league.Name = leagueDTO.name;
            league.StartDate = leagueDTO.start_date;
            league.FinishDate = leagueDTO.finish_date;
            league.IsCurrent = leagueDTO.is_current;
            league.Champion = leagueDTO.champion;

            league.Teams = new List<LeagueTeam>();
            foreach (var leagueTeamDTO in leagueDTO.teams)
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
            league.Fixture.LeagueId = leagueDTO.fixture.LeagueId;
            league.Fixture.TotalGames = leagueDTO.fixture.TotalGames;
            league.Fixture.SpecialGame = leagueDTO.fixture.SpecialGame;
            league.Fixture.League = league;

            league.Fixture.Games = new List<Game>();
            foreach (var gameDTO in leagueDTO.fixture.Games)
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
                    match.MatchDate = matchDTO.match_date;
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
    }
}