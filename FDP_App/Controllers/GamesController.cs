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
    [RoutePrefix("api/games")]
    public class GamesController : ApiController
    {
        /* Iniciar Servicios */
        private readonly GameService _gameService = new GameService();
        private readonly MapToDTO _asDto = new MapToDTO();

        /* GET: api/games */
        [Route("")]
        public IEnumerable<GameDTO> GetGames(int id)
        {
            var games = _gameService.GetAll();
            return _asDto.GetAllGamesAsDTO(games);
        }

        /* GET: api/leagues/:id/games */
        [Route("~/api/leagues/{id}/games")]
        public IEnumerable<GameDTO> GetLeagueGames(int id)
        {
            var games = _gameService.GetAll().Where(g => g.LeagueId == id );
            return _asDto.GetAllGamesAsDTO(games);
        }

        /* GET: api/games/{id} */
        [Route("{id}")]
        [ResponseType(typeof(GameDTO))]
        public IHttpActionResult GetGame(int id)
        {
            Game game = _gameService.GetById(id);
            if (game == null)
            {
                return NotFound();
            }

            return Ok(_asDto.GetGameAsDTO(game));
        }

        /* PUT: api/games/{id} */
        [Route("{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGame(int id, Game game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _gameService.Update(game, id);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_gameService.Exists(id))
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