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
using APIBIBLIOTECA.Models;

namespace APIBIBLIOTECA.Controllers
{
    public class PrestamoesController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Prestamoes
        public IQueryable<Prestamo> GetPrestamo()
        {
            return db.Prestamo;
        }

        // GET: api/Prestamoes/5
        [ResponseType(typeof(Prestamo))]
        public async Task<IHttpActionResult> GetPrestamo(int id)
        {
            Prestamo prestamo = await db.Prestamo.FindAsync(id);
            if (prestamo == null)
            {
                return NotFound();
            }

            return Ok(prestamo);
        }

        // PUT: api/Prestamoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPrestamo(int id, Prestamo prestamo)
        {

            if (id != prestamo.idPrestamo)
            {
                return BadRequest();
            }

            db.Entry(prestamo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrestamoExists(id))
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

        // POST: api/Prestamoes
        [ResponseType(typeof(Prestamo))]
        public async Task<IHttpActionResult> PostPrestamo(Prestamo prestamo)
        {
            db.Prestamo.Add(prestamo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = prestamo.idPrestamo }, prestamo);
        }

        // DELETE: api/Prestamoes/5
        [ResponseType(typeof(Prestamo))]
        public async Task<IHttpActionResult> DeletePrestamo(int id)
        {
            Prestamo prestamo = await db.Prestamo.FindAsync(id);
            if (prestamo == null)
            {
                return NotFound();
            }

            db.Prestamo.Remove(prestamo);
            await db.SaveChangesAsync();

            return Ok(prestamo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PrestamoExists(int id)
        {
            return db.Prestamo.Count(e => e.idPrestamo == id) > 0;
        }
    }
}