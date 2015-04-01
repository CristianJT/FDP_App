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
    public class TorneosController : ApiController
    {
        private FDP_AppContext db = new FDP_AppContext();

        private static readonly Expression<Func<Torneo, TorneoDTO>> AsTorneoDTO =
         x => new TorneoDTO
         {
            Id = x.Id,
            Nombre = x.Nombre,
            Decripcion = x.Descripcion
         };
      
           

        // GET: api/Torneos
        public IQueryable<TorneoDTO> GetTorneos()
        {
            return db.Torneos.Select(AsTorneoDTO);
        }

        // GET: api/Torneos/5
        [ResponseType(typeof(Torneo))]
        public async Task<IHttpActionResult> GetTorneo(int id)
        {
            Torneo torneo = await db.Torneos.FindAsync(id);
            if (torneo == null)
            {
                return NotFound();
            }

            return Ok(torneo);
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