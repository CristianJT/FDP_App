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

namespace FDP_App.Controllers
{
    [RoutePrefix("api/leagues")]
    public class LeaguesController : ApiController
    {
        private readonly LeagueService _leagueService = new LeagueService();
        private readonly MapToDTO _asDto = new MapToDTO();

        /* GET: api/leagues */
        [Route("")]
        [HttpGet]
        public IEnumerable<LeaguesDTO> GetLeagues()
        {
            var leagues = _leagueService.GetAll();
            return _asDto.GetAllLeaguesAsDTO(leagues);
        }

        /* GET: api/leagues/{id} */
        [Route("{id}", Name = "GetLeagueByIdRoute")]
        [HttpGet]
        [ResponseType(typeof(LeaguesDetailDTO))]
        public IHttpActionResult GetLeague(int id)
        {
            League league = _leagueService.GetById(id);
            if (league == null)
            {
                return NotFound();
            }
            return Ok(_asDto.GetLeagueAsDTO(league));
        }

        /* PUT: api/leagues/{id} */
        [Route("{id}")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLeague(int id, League league)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
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

        /* POST: api/leagues */
        [Route("")]
        [HttpPost]
        [ResponseType(typeof(League))]
        public IHttpActionResult PostLeague(League league)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _leagueService.Add(league);
            return CreatedAtRoute("GetLeagueByIdRoute", new { id = league.LeagueId }, league);
        }

        /* DELETE: api/leagues/{id} */
        [Route("{id}")]
        [HttpDelete]
        [ResponseType(typeof(LeaguesDetailDTO))]
        public IHttpActionResult DeleteLeague(int id)
        {
            League league = _leagueService.GetById(id);
            if (league == null)
            {
                return NotFound();
            }

            _leagueService.Delete(id);
            return Ok(_asDto.GetLeagueAsDTO(league));
        }

    }
}