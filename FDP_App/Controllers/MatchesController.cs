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
using Data;
using Entities.Models;
using Data.Services;
using FDP_App.DTOs;

namespace FDP_App.Controllers
{
    [RoutePrefix("api/matches")]
    public class MatchesController : ApiController
    {
        /* Iniciar Servicios */
        private readonly MatchService _matchService = new MatchService();
        private readonly MapToDTO _asDto = new MapToDTO();

        /* GET: api/matches */
        [Route("")]
        public IEnumerable<MatchDTO> GetMatches()
        {
            var matches = _matchService.GetAll();
            return _asDto.GetAllMatchesAsDTO(matches);
        }

        /* GET: api/matches/{id} */
        [Route("{id}")]
        [ResponseType(typeof(MatchDTO))]
        public IHttpActionResult GetMatch(int id)
        {
            Match match = _matchService.GetById(id);
            if (match == null)
            {
                return NotFound();
            }

            return Ok(_asDto.GetMatchAsDTO(match));
        }

        /* PUT: api/Matches/{id} */
        [Route("{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMatch(int id, Match match)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _matchService.Update(match, id);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_matchService.Exists(id))
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

    }
}