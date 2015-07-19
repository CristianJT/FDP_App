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
        protected FDPAppContext context = new FDPAppContext();

        /* GET: api/matches */
        [Route("")]
        public IHttpActionResult GetMatches()
        {
            var matches = _matchService.GetAll();
            return Ok(_asDto.GetAllMatchesAsDTO(matches));
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
        [ResponseType(typeof(MatchDTO))]
        public IHttpActionResult PutMatch(int id, MatchDTO matchDto)
        {
            if (id != matchDto.match_id)
            {
                return BadRequest();
            }

            Match match = new Match();
            match.MatchId = matchDto.match_id;
            match.GameId = matchDto.game_id;
            match.HomeTeam = matchDto.home_team;
            match.AwayTeam = matchDto.away_team;
            match.HomeResult = matchDto.home_result;
            match.AwayResult = matchDto.away_result;
            match.MatchDate = matchDto.match_date.ToLocalTime();
            
            match.IsConfirm = matchDto.is_confirm;


            Match existingMatch = _matchService.Update(match, id);           

            return Ok(_asDto.GetMatchAsDTO(existingMatch));
        }

    }
}