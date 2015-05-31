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

namespace FDP_App.Controllers
{
    [RoutePrefix("api/leagues")]
    public class LeaguesController : ApiController
    {
        private readonly LeagueService _leagueService = new LeagueService();

        [Route("")]
        public IEnumerable<League> GetLeagues()
        {
            return _leagueService.GetAll();
        }

        [Route("{id}", Name = "GetByIdRoute")]
        [ResponseType(typeof(League))]
        public IHttpActionResult GetLeague(int id)
        {
            League league = _leagueService.GetById(id);
            if (league == null)
            {
                return NotFound();
            }
            return Ok(league);
        }

        [Route("{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLeague(int id, League league)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != league.LeagueId)
            {
                return BadRequest();
            }

            try
            {
                _leagueService.Update(league, id);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_leagueService.Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("")]
        [ResponseType(typeof(League))]
        public IHttpActionResult PostLeague(League league)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _leagueService.Add(league);
            }
            catch (DbUpdateException)
            {
                if (_leagueService.Exists(league.LeagueId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetByIdRoute", new { id = league.LeagueId }, league);
        }

        [Route("{id}")]
        [ResponseType(typeof(League))]
        public IHttpActionResult DeleteLeague(int id)
        {
            League league = _leagueService.GetById(id);
            if (league == null)
            {
                return NotFound();
            }

            _leagueService.Delete(id);
            return Ok(league);
        }

    }
}