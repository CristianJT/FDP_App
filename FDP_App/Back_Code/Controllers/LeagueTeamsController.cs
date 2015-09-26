using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace App.FDP
{
    [RoutePrefix("api/torneos/{idTorneo}/equipos")]
    public class LeagueTeamsController : ApiController
    {
        private FDPAppContext db = new FDPAppContext();

        /* GET: api/torneos/{idTorneo}/equipos */
        [Route("")]
        [HttpGet]
        public IHttpActionResult GetLeagueTeams(int idTorneo)
        {
            LeagueTeam[] equipos = db.LeagueTeams.Where(lt => lt.LeagueId == idTorneo)
                .AsNoTracking().ToArray();
            return Ok(equipos.Select(t => new TeamLeagueDTO(t)));
        }

        /* GET: api/torneos/{idTorneo}/equipos/{idEquipo} */
        [Route("{idEquipo}")]
        [HttpGet]
        public IHttpActionResult GetLeagueTeam(int idTorneo, int idEquipo)
        {
            LeagueTeam equipo = db.LeagueTeams
                .Where(lt => lt.LeagueId == idTorneo & lt.TeamId == idEquipo).AsNoTracking().FirstOrDefault();
            if (equipo == null)
            {
                return NotFound();
            }
            return Ok(new TeamLeagueDTO(equipo));
        }

        /* POST: api/torneos/{idTorneo}/equipos/crear */
        [Route("crear")]
        [HttpPost]
        public IHttpActionResult CreateLeagueTeam(int idTorneo, TeamIdsDTO equiposId )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            League torneo = db.Leagues
                .Where(l => l.Id == idTorneo).FirstOrDefault();
            if (torneo == null)
            {
                return NotFound();
            }

            Team[] equipos = db.Teams
                .Where(t => equiposId.ids.Contains(t.Id)).ToArray();

            foreach (Team e in equipos)
            {
                LeagueTeam equipoTorneo = new LeagueTeam();
                equipoTorneo.League = torneo;
                equipoTorneo.Team = e;
                if (!db.LeagueTeams.Any(lt => lt.LeagueId == idTorneo & lt.TeamId == e.Id))
                {
                    db.LeagueTeams.Add(equipoTorneo);
                }             
            }
           
            db.SaveChanges();

            return Ok();
        }

        /* PUT: api/torneos/{idTorneo}/equipos/{idEquipo} */
        [Route("{idEquipo}")]
        [HttpPut]
        public IHttpActionResult UpdateLeagueTeam(int idTorneo, int idEquipo, TeamLeagueDTO equipoDTO)
        {
            if (idEquipo != equipoDTO.equipo_id || idTorneo != equipoDTO.torneo_id)
            {
                return BadRequest();
            }

            var equipo = db.LeagueTeams.Where(x => x.LeagueId == idTorneo && x.TeamId == idEquipo).FirstOrDefault();
            if (equipo == null)
            {
                return NotFound();
            }
            equipo.Played = equipoDTO.jugados;
            equipo.Points = equipoDTO.puntos;
            equipo.Won = equipoDTO.ganados;
            equipo.Draws = equipoDTO.empatados;
            equipo.Lost = equipoDTO.perdidos;
            equipo.GoalsFor = equipoDTO.goles_favor;
            equipo.GoalsAgainst = equipoDTO.goles_contra;
            equipo.GoalDifference = equipoDTO.goles_diferencia;

            db.SaveChanges();

            return Ok(new TeamLeagueDTO(equipo));

        }
    }
}
