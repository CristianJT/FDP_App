﻿using System;
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

            leagueDTO.league_id = league.LeagueId;
            return CreatedAtRoute("GetLeagueByIdRoute", new { id = league.LeagueId }, leagueDTO);
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
            league.Fixture.LeagueId = leagueDTO.fixture.league_id;
            league.Fixture.TotalGames = leagueDTO.fixture.total_games;
            league.Fixture.SpecialGame = leagueDTO.fixture.special_game;
            league.Fixture.League = league;

            league.Fixture.Games = new List<Game>();
            foreach (var gameDTO in leagueDTO.fixture.games)
            {
                Game game = new Game();
                game.GameId = gameDTO.game_id;
                game.Fixture = league.Fixture;
                game.GameNumber = gameDTO.game_number;
                game.IsSpecialGame = gameDTO.is_special_game;
                game.IsCurrent = gameDTO.is_current;

                game.Matches = new List<Match>();
                foreach (var matchDTO in gameDTO.matches)
                {
                    Match match = new Match();
                    match.MatchId = matchDTO.match_id;
                    match.Game = game;
                    //match.MatchDate = matchDTO.match_date;
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