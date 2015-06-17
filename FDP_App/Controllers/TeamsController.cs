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
using Entities.Models;
using Data.Services;
using FDP_App.DTOs;

namespace FDP_App.Controllers
{
    [RoutePrefix("api/teams")]
    public class TeamsController : ApiController
    {
        /* Iniciar Servicios */
        private readonly TeamService _teamService = new TeamService();
        private readonly MapToDTO _asDto = new MapToDTO();
        private readonly MapToEntities _asEntity = new MapToEntities();

        /* GET: api/teams */
        [Route("")]
        public IEnumerable<TeamsDTO> GetTeams()
        {
            var teams = _teamService.GetAll();
            return _asDto.GetAllTeamsAsDTO(teams);
        }

        /* GET: api/teams/{id} */
        [Route("{id}", Name = "GetTeamByIdRoute")]
        [ResponseType(typeof(TeamsDetailDTO))]
        public IHttpActionResult GetTeam(int id)
        {
            Team team = _teamService.GetById(id);
            if (team == null)
            {
                return NotFound();
            }

            return Ok(_asDto.GetTeamAsDTO(team));
        }

        /* PUT: api/teams/{id} */
        [Route("{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTeam(int id, Team team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != team.TeamId)
            {
                return BadRequest();
            }

            //Team team = _teamService.GetById(id);

            try
            {
               // _asEntity.TeamDTOtoEntity(ref team, teamDTO);
                _teamService.Update(team, id);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_teamService.Exists(id))
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

        /* POST: api/teams */
        [Route("")]
        [ResponseType(typeof(TeamsDTO))]
        public IHttpActionResult PostTeam(TeamsDTO teamDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Team team = new Team();
            _asEntity.TeamDTOtoEntity(ref team, teamDTO);
            _teamService.Add(team);

            teamDTO.TeamId = team.TeamId;
            return CreatedAtRoute("GetTeamById", new { id = team.TeamId }, teamDTO);
        }

        /* DELETE: api/teams/{id} */
        [Route("{id}")]
        [ResponseType(typeof(Team))]
        public IHttpActionResult DeleteTeam(int id)
        {
            Team team = _teamService.GetById(id);
            if (team == null)
            {
                return NotFound();
            }

            _teamService.Delete(id);
            return Ok(team);
        }

    }
}