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
        private FDPAppContext db = new FDPAppContext();

        /* GET: api/games */
        [Route("")]
        [HttpGet]
        [ResponseType(typeof(GameDTO))]
        public IHttpActionResult GetGames()
        {
            var games = db.Games.ToArray();
            return Ok (games.Select(g => new GameDTO(g)).ToArray());
        }    

        /* GET: api/games/{id} */
        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(GameDTO))]
        public IHttpActionResult GetGame(int id)
        {
            Game game = db.Games.Where(g => g.GameId == id).FirstOrDefault();
            if (game == null)
            {
                return NotFound();
            }

            return Ok(new GameDTO(game));
        }

        /* PUT: api/games/{id} */
        [Route("{id}")]
        [ResponseType(typeof(GameDTO))]
        public IHttpActionResult UpdateGame(int id, Game gameDto)
        {
            if (id != gameDto.GameId)
            {
                return BadRequest();
            }

            var game = db.Games.Where(g => g.GameId == id).FirstOrDefault();
            if (game == null)
            {
                return NotFound();
            }

            game.IsCurrent = gameDto.IsCurrent;
            db.SaveChanges();

            return Ok(new GameDTO(game));
        }
        
    }
}