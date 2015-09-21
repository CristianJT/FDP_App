using System.Data;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace App.FDP
{
    [RoutePrefix("api/teams")]
    public class TeamsController : ApiController
    {
        private FDPAppContext db = new FDPAppContext();

        /* GET: api/teams */
        [Route("")]
        [HttpGet]
        [ResponseType(typeof(TeamsDTO))]
        public IHttpActionResult GetTeams()
        {
            var teams = db.Teams.ToArray();
            return Ok(teams.Select(t => new TeamsDTO(t)).ToArray());
        }

        /* GET: api/teams/{id} */
        [Route("{id}", Name = "GetTeamByIdRoute")]
        [HttpGet]
        [ResponseType(typeof(TeamsDetailDTO))]
        public IHttpActionResult GetTeam(int id)
        {
            var team = db.Teams.Where(t => t.TeamId == id).FirstOrDefault();
            if (team == null)
            {
                return NotFound();
            }

            return Ok(new TeamsDetailDTO(team));
        }

        /* PUT: api/teams/{id} */
        [Route("{id}")]
        [HttpPut]
        [ResponseType(typeof(TeamsDTO))]
        public IHttpActionResult UpdateTeam(int id, TeamsDTO teamDto)
        {
            if (id != teamDto.TeamId)
            {
                return BadRequest();
            }

            var team = db.Teams.Where(t => t.TeamId == id).FirstOrDefault();
            if (team == null)
            {
                return NotFound();
            }

            team.IsTopDivision = teamDto.IsTopDivision;
            team.Stadium = teamDto.Stadium;
            db.SaveChanges();

            return Ok(new TeamsDTO(team));
        }

        /* POST: api/teams */
        [Route("")]
        [HttpPost]
        [ResponseType(typeof(TeamsDTO))]
        public IHttpActionResult CreateTeam(TeamsDTO teamDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Team team = new Team();
            TeamDTOtoEntity(ref team, teamDto);

            db.Teams.Add(team);
            db.SaveChanges();

            teamDto.TeamId = team.TeamId;
            return CreatedAtRoute("GetTeamById", new { id = team.TeamId }, teamDto);
        }

        /* DELETE: api/teams/{id} */
        [Route("{id}")]
        [HttpDelete]
        [ResponseType(typeof(TeamsDTO))]
        public IHttpActionResult DeleteTeam(int id)
        {
            Team team = db.Teams.Where(t => t.TeamId == id).FirstOrDefault();
            if (team == null)
            {
                return NotFound();
            }

            db.Teams.Remove(team);
            db.SaveChanges();
            return Ok(new TeamsDTO(team));
        }

        public void TeamDTOtoEntity(ref Team team, TeamsDTO teamDTO)
        {
            team.TeamId = teamDTO.TeamId;
            team.Name = teamDTO.Name;
            team.Stadium = teamDTO.Stadium;
            team.City = teamDTO.City;
            team.IsTopDivision = teamDTO.IsTopDivision;
        }

    }
}