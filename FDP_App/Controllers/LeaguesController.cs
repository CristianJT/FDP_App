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

namespace FDP_App.Controllers
{
    [RoutePrefix("api/leagues")]
    public class LeaguesController : ApiController
    {
        /* Iniciar Servicios */
        private readonly LeagueService _leagueService = new LeagueService();
        private readonly MapToDTO _asDto = new MapToDTO();
        private readonly MapToEntities _asEntity = new MapToEntities();
       
        /* GET: api/leagues */
        [Route("")]
        [HttpGet]
        public IHttpActionResult GetLeagues()
        {
            var leagues = _leagueService.GetAll();
            return Ok(_asDto.GetAllLeaguesAsDTO(leagues));
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

        /* POST: api/leagues */
        [Route("")]
        [HttpPost]
        [ResponseType(typeof(LeaguesDetailDTO))]
        public IHttpActionResult PostLeague(LeaguesDetailDTO leagueDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            League league = new League();
            _asEntity.LeagueDTOtoEntity(ref league, leagueDTO);
            _leagueService.Add(league);

            leagueDTO.LeagueId = league.LeagueId;
            return CreatedAtRoute("GetLeagueByIdRoute", new { id = league.LeagueId }, leagueDTO);
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