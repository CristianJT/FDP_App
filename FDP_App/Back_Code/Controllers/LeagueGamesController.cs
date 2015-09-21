using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace App.FDP
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

        /* PUT: api/leagues/{leagueId}/games/{gameNumber} */
        [Route("gameNumber")]
        [HttpPut]
        [ResponseType(typeof(GameDTO))]
        public IHttpActionResult UpdateLeagueGame(int leagueId, int gameNumber, GameDTO gameDto)
        {
            if (leagueId != gameDto.league_id || gameNumber != gameDto.game_number)
            {
                return BadRequest();
            }

            var game = db.Games.Where(g => g.LeagueId == leagueId && g.GameNumber == gameNumber).FirstOrDefault();
            if (game == null)
            {
                return NotFound();
            }

            game.IsCurrent = gameDto.is_current;
            db.SaveChanges();

            return Ok(new GameDTO(game));
        }
    }
}
