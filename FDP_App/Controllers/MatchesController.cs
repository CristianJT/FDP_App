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
using Data;
using Entities.Models;
using Data.Services;
using FDP_App.DTOs;

namespace FDP_App.Controllers
{
    [RoutePrefix("api/matches")]
    public class MatchesController : ApiController
    {
        private FDPAppContext db = new FDPAppContext();

        /* GET: api/matches */
        [Route("")]
        [ResponseType(typeof(MatchDTO))]
        public IHttpActionResult GetMatches()
        {
            var matches = db.Matches.ToArray();
            return Ok(matches.Select(m => new MatchDTO(m)).ToArray());
        }

        /* GET: api/matches/{id} */
        [Route("{id}")]
        [ResponseType(typeof(MatchDTO))]
        public IHttpActionResult GetMatch(int id)
        {
            Match match = db.Matches.Where(m => m.MatchId == id).FirstOrDefault();
            if (match == null)
            {
                return NotFound();
            }

            return Ok(new MatchDTO(match));
        }

        /* PUT: api/Matches/{id} */
        [Route("{id}")]
        [ResponseType(typeof(MatchDTO))]
        [HttpPut]
        public IHttpActionResult UpdateMatch(int id, MatchDTO matchDto)
        {
            if (id != matchDto.match_id)
            {
                return BadRequest();
            }

            var match = db.Matches.Where(m => m.MatchId == id).FirstOrDefault();
            if (match == null)
            {
                return NotFound();
            }

            match.HomeResult = matchDto.home_result;
            match.AwayResult = matchDto.away_result;
            match.MatchDate = matchDto.match_date.ToLocalTime();        
            match.IsConfirm = matchDto.is_confirm;
            db.SaveChanges();       

            return Ok(new MatchDTO(match));
        }

    }
}