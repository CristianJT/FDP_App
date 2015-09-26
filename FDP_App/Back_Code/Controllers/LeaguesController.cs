using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

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
            League[] torneos = db.Leagues.AsNoTracking().ToArray();
            if (torneos.Length == 0)
            {
                return Ok(new List<LeagueDTO>().ToArray());
            }
            return Ok(torneos.Select(l => new LeagueDTO(l)));
        }

        /* GET: api/torneos/{id} */
        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult GetLeague(int id)
        {
            League torneo = db.Leagues
                .Where(l => l.Id == id).AsNoTracking().FirstOrDefault();
            if (torneo == null)
            {
                return NotFound();
            }
            return Ok(new LeagueDTO(torneo));
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


        /* POST: api/torneos/crear */
        [Route("crear")]
        [HttpPost]
        public IHttpActionResult CreateLeague(LeagueDTO torneoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            League torneo = new League();
            torneo.Name = torneoDTO.nombre;
            torneo.Season = torneoDTO.temporada;
            torneo.StartDate = torneoDTO.fecha_inicio;
            torneo.FinishDate = torneoDTO.fecha_fin;
            torneo.IsCurrent = torneoDTO.en_progreso;
            torneo.Champion = torneoDTO.campeon;
            torneo.RelegatedTeams = torneoDTO.cantidad_descensos;
            torneo.TotalTeams = torneoDTO.total_equipos;
            torneo.TotalGames = torneoDTO.total_fechas;
            torneo.SpecialGame = torneoDTO.fecha_especial_numero;

            db.Leagues.Add(torneo);
            db.SaveChanges();

            return Ok(torneoDTO);
        }

        /* PUT: api/torneos/{id} */
        [Route("{id}")]
        [HttpPut]
        public IHttpActionResult UpdateLeague(int id, LeagueDTO torneoDTO)
        {
            if (id != torneoDTO.id)
            {
                return BadRequest();
            }

            League torneo = db.Leagues
                .Where(l => l.Id == id).FirstOrDefault();
            if (torneo == null)
            {
                return BadRequest();
            }

            torneo.Champion = torneoDTO.campeon;
            torneo.IsCurrent = torneoDTO.en_progreso;
            db.SaveChanges();

            return Ok(new LeagueDTO(torneo));
        }

        /* DELETE: api/torneos/{id}/eliminar */
        [Route("{id}/eliminar")]
        [HttpPost]
        public IHttpActionResult DeleteLeague(int id)
        {
            League torneo = db.Leagues
                .Where(l => l.Id == id).FirstOrDefault();
            if (torneo == null)
            {
                return BadRequest();
            }
            db.Leagues.Remove(torneo);
            db.SaveChanges();

            return Ok();
        }


    }
}