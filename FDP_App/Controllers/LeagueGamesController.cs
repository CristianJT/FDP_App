using Data;
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
    [RoutePrefix("api/leagues/{leagueId}/games")]
    public class LeagueGamesController : ApiController
    {
        private FDPAppContext db = new FDPAppContext();

        /* GET: api/leagues/{leagueId}/games */
        [Route("")]
        [HttpGet]
        [ResponseType(typeof(GameDTO))]
        public IHttpActionResult GetLeagueGames(int leagueId)
        {
            var games = db.Games.Where(g => g.LeagueId == leagueId).ToArray();
            return Ok (games.Select(g => new GameDTO(g)).ToArray());
        }

        /* GET: api/leagues/{leagueId}/games/{gameNumber} */
        [Route("{gameNumber}")]
        [HttpGet]
        [ResponseType(typeof(GameDTO))]
        public IHttpActionResult GetLeagueGame(int leagueId, int gameNumber)
        {
            var game = db.Games.Where(g => g.LeagueId == leagueId && g.GameNumber == gameNumber).FirstOrDefault();
            if (game == null)
            {
                return NotFound();
            }

            return Ok(new GameDTO(game));
        }
    }
}
