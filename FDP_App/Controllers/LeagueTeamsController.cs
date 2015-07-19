using Data;
using Entities.Models;
using FDP_App.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace FDP_App.Controllers
{
    [RoutePrefix("api/leagues/{leagueId}/teams")]
    public class LeagueTeamsController : ApiController
    {
        private FDPAppContext db = new FDPAppContext();

        /* GET: api/leagues/{leagueId}/teams */
        [Route("")]
        [ResponseType(typeof(TeamsLeagueDTO))]
        public IHttpActionResult GetLeagueTeams(int leagueId)
        {
            var teams = db.LeagueTeams.Where(t => t.LeagueId == leagueId).ToArray();
            return Ok(teams.Select(t => new TeamsLeagueDTO(t)).ToArray());
        }

        /* GET: api/leagues/{leagueId}/teams/{teamId} */
        [Route("{teamId}")]
        [ResponseType(typeof(TeamsLeagueDTO))]
        public IHttpActionResult GetLeagueTeam(int leagueId, int teamId)
        {
            var team = db.LeagueTeams.Where(t =>  t.LeagueId == leagueId && t.TeamId == teamId).FirstOrDefault();
            if (team == null)
            {
                return NotFound();
            }

            return Ok(new TeamsLeagueDTO(team));
        }

        /* PUT: api/leagues/{leagueId}/teams/{teamId} */
        [Route("{teamId}")]
        [ResponseType(typeof(TeamsLeagueDTO))]
        [HttpPut]
        public IHttpActionResult UpdateLeagueTeam(int leagueId, int teamId, TeamsLeagueDTO teamDto)
        {
            if (teamId != teamDto.team_id)
            {
                return BadRequest();
            }

            var lt = db.LeagueTeams.Where(x => x.LeagueId == leagueId && x.TeamId == teamId).FirstOrDefault();
            if (lt == null)
            {
                return NotFound();
            }

            lt.Played = teamDto.played;
            lt.Points = teamDto.points;
            lt.Won = teamDto.won;
            lt.Draws = teamDto.draws;
            lt.Lost = teamDto.lost;
            lt.GoalsFor = teamDto.goals_for;
            lt.GoalsAgainst = teamDto.goals_against;
            lt.GoalDifference = teamDto.goal_difference;
            db.SaveChanges();

            return Ok(new TeamsLeagueDTO(lt));

        }
    }
}
