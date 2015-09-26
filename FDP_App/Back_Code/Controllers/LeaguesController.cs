using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace App.FDP
{
    [RoutePrefix("api/torneos")]
    public class LeaguesController : ApiController
    {
        private FDPAppContext db = new FDPAppContext();

        /* GET: api/torneos */
        [Route("")]
        [HttpGet]
        public IHttpActionResult GetLeagues()
        {
            League[] leagues = db.Leagues.AsNoTracking().ToArray();
            if (leagues.Length == 0)
            {
                return Ok(new List<LeagueDTO>().ToArray());
            }
            return Ok(leagues.Select(l => new LeagueDTO(l)));
        }

        /* GET: api/torneos/{id} */
        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult GetLeague(int id)
        {
            League league = db.Leagues
                .Where(l => l.Id == id).AsNoTracking().FirstOrDefault();
            if (league == null)
            {
                return NotFound();
            }
            return Ok(new LeagueDTO(league));
        }

        /* GET: api/torneos/{id}/fechas */
        [Route("{id}/fechas")]
        [HttpGet]
        public IHttpActionResult GetLeagueGames(int id)
        {
            Game[] games = db.Games.Where(g => g.LeagueId == id)
                .AsNoTracking().ToArray();
            return Ok(games.Select(g => new GameDTO(g)));           
        }

        /* GET: api/torneos/{id}/equipos */
        [Route("{id}/equipos")]
        [HttpGet]
        public IHttpActionResult GetLeagueTeams(int id)
        {
            LeagueTeam[] teams = db.LeagueTeams.Where(lt => lt.LeagueId == id)
                .AsNoTracking().ToArray();
            return Ok(teams.Select(t => new TeamLeagueDTO(t)));
        }

        /* GET: api/torneos/{idTorneo}/equipos/{idEquipo} */
        [Route("{idTorneo}/equipos/{idEquipo}")]
        [HttpGet]
        public IHttpActionResult GetLeagueTeam(int idTorneo, int idEquipo)
        {
            LeagueTeam team = db.LeagueTeams
                .Where(lt => lt.LeagueId == idTorneo & lt.TeamId == idEquipo).AsNoTracking().FirstOrDefault();
            if (team == null)
            {
                return NotFound();
            }
            return Ok(new TeamLeagueDTO(team));
        }

        /* POST: api/torneos/crear */
        [Route("crear")]
        [HttpPost]
        public IHttpActionResult CreateLeague(LeagueDTO leagueDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            League league = new League();
            league.Name = leagueDTO.nombre;
            league.Season = leagueDTO.temporada;
            league.StartDate = leagueDTO.fecha_inicio;
            league.FinishDate = leagueDTO.fecha_fin;
            league.IsCurrent = leagueDTO.en_progreso;
            league.Champion = leagueDTO.campeon;
            league.RelegatedTeams = leagueDTO.cantidad_descensos;
            league.TotalTeams = leagueDTO.total_equipos;
            league.TotalGames = leagueDTO.total_fechas;
            league.SpecialGame = leagueDTO.fecha_especial_numero;

            db.Leagues.Add(league);
            db.SaveChanges();

            return Ok();
        }

        /* PUT: api/torneos/{id} */
        [Route("{id}")]
        [HttpPut]
        public IHttpActionResult UpdateLeague(int id, LeagueDTO leagueDTO)
        {
            if (id != leagueDTO.id)
            {
                return BadRequest();
            }

            League league = db.Leagues
                .Where(l => l.Id == id).FirstOrDefault();
            if (league == null)
            {
                return NotFound();
            }

            league.Champion = leagueDTO.campeon;
            league.IsCurrent = leagueDTO.en_progreso;
            db.SaveChanges();

            return Ok(new LeagueDTO(league));
        }

        /* DELETE: api/torneos/{id}/eliminar */
        [Route("{id}/eliminar")]
        [HttpPost]
        public IHttpActionResult DeleteLeague(int id)
        {
            League league = db.Leagues
                .Where(l => l.Id == id).FirstOrDefault();
            if (league == null)
            {
                return NotFound();
            }
            db.Leagues.Remove(league);
            db.SaveChanges();

            return Ok();
        }


    }
}