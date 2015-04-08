using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using FDP_App.DAL;
using FDP_App.Models;
using System.Linq.Expressions;

namespace FDP_App.Controllers
{
    [RoutePrefix("api/torneos")]
    public class TorneosController : ApiController
    {
        private FDP_AppContext db = new FDP_AppContext();

        private static readonly Expression<Func<Equipo, EquipoDTO>> asEquipoDto =
            e => new EquipoDTO
            {
                Id = e.Id,
                Nombre = e.Nombre,
                Puntos = e.Puntos,
                Jugados = e.Jugados,
                Ganados = e.Ganados,
                Empatados = e.Empatados,
                Perdidos = e.Perdidos,
                GolesFavor = e.GolesFavor,
                GolesContra = e.GolesContra,
                Diferencia = e.Diferencia
            };

        //GET: api/torneos
        [Route("")]
        public IQueryable<TorneoDTO> GetTorneos()
        {
            var torneos = from t in db.Torneos
                          select new TorneoDTO() { Id = t.Id, Nombre = t.Nombre };
            return torneos;
        }

        // GET: api/torneos/{id}
        [Route("{id:int}")]
        [ResponseType(typeof(TorneoDetailDTO))]
        public async Task<IHttpActionResult> GetTorneo(int id)
        {
            var torneo = await db.Torneos.Select(t => new TorneoDetailDTO() { Id = t.Id, Nombre = t.Nombre, Decripcion = t.Descripcion })
                .SingleOrDefaultAsync(t => t.Id == id);
            if (torneo == null)
            {
                return NotFound();
            }

            return Ok(torneo);
        }

        // GET: api/torneos/{id}/equipos
        [Route("{id}/equipos")]
        public IQueryable<EquipoDTO> GetEquiposByTorneo(int id)
        {
            return db.Equipos.Include(e => e.Torneo)
                .Where(e => e.TorneoId == id)
                .Select(asEquipoDto);
        }


        // PUT: api/Torneos/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTorneo(int id, Torneo torneo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != torneo.Id)
            {
                return BadRequest();
            }

            db.Entry(torneo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TorneoExists(id))
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

        // POST: api/Torneos
        [ResponseType(typeof(Torneo))]
        public async Task<IHttpActionResult> PostTorneo(Torneo torneo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Torneos.Add(torneo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = torneo.Id }, torneo);
        }

        // DELETE: api/Torneos/5
        [ResponseType(typeof(Torneo))]
        public async Task<IHttpActionResult> DeleteTorneo(int id)
        {
            Torneo torneo = await db.Torneos.FindAsync(id);
            if (torneo == null)
            {
                return NotFound();
            }

            db.Torneos.Remove(torneo);
            await db.SaveChangesAsync();

            return Ok(torneo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TorneoExists(int id)
        {
            return db.Torneos.Count(e => e.Id == id) > 0;
        }
    }
}