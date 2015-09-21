using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace App.FDP
{
    [RoutePrefix("api/leagues/{leagueId}/teams")]
    public class LeagueTeamsController : ApiController
    {
        private FDPAppContext db = new FDPAppContext();

        /* GET: api/leagues/{leagueId}/teams */
        [Route("")]
        [ResponseType(typeof(TeamsLeagueDTO))]
        public IHttpActionResult GetLeagueTeams(int leagueId)
        {
            var teams = db.LeagueTeams.Where(t => t.LeagueId == leagueId).ToArray();
            return Ok(teams.Select(t => new TeamsLeagueDTO(t)).ToArray());
        }

        /* GET: api/leagues/{leagueId}/teams/{teamId} */
        [Route("{teamId}")]
        [ResponseType(typeof(TeamsLeagueDTO))]
        public IHttpActionResult GetLeagueTeam(int leagueId, int teamId)
        {
            var team = db.LeagueTeams.Where(t =>  t.LeagueId == leagueId && t.TeamId == teamId).FirstOrDefault();
            if (team == null)
            {
                return NotFound();
            }

            return Ok(new TeamsLeagueDTO(team));
        }

        /* PUT: api/leagues/{leagueId}/teams/{teamId} */
        [Route("{teamId}")]
        [ResponseType(typeof(TeamsLeagueDTO))]
        [HttpPut]
        public IHttpActionResult UpdateLeagueTeam(int leagueId, int teamId, TeamsLeagueDTO teamDto)
        {
            if (teamId != teamDto.TeamId || leagueId != teamDto.LeagueId)
            {
                return BadRequest();
            }

            var lt = db.LeagueTeams.Where(x => x.LeagueId == leagueId && x.TeamId == teamId).FirstOrDefault();
            if (lt == null)
            {
                return NotFound();
            }

            lt.Played = teamDto.Played;
            lt.Points = teamDto.Points;
            lt.Won = teamDto.Won;
            lt.Draws = teamDto.Draws;
            lt.Lost = teamDto.Lost;
            lt.GoalsFor = teamDto.GoalsFor;
            lt.GoalsAgainst = teamDto.GoalsAgainst;
            lt.GoalDifference = teamDto.GoalDifference;
            db.SaveChanges();

            return Ok(new TeamsLeagueDTO(lt));

        }
    }
}
