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
    public class LibroesController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Libroes
        public IQueryable<Libro> GetLibro()
        {
            return db.Libro;
        }

        // GET: api/Libroes/5
        [ResponseType(typeof(Libro))]
        public async Task<IHttpActionResult> GetLibro(int id)
        {
            Libro libro = await db.Libro.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }

            return Ok(libro);
        }

        // PUT: api/Libroes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLibro(int id, Libro libro)
        {

            if (id != libro.IdLibro)
            {
                return BadRequest();
            }

            db.Entry(libro).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibroExists(id))
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

        // POST: api/Libroes
        [ResponseType(typeof(Libro))]
        public async Task<IHttpActionResult> PostLibro(Libro libro)
        {

            db.Libro.Add(libro);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = libro.IdLibro }, libro);
        }

        // DELETE: api/Libroes/5
        [ResponseType(typeof(Libro))]
        public async Task<IHttpActionResult> DeleteLibro(int id)
        {
            Libro libro = await db.Libro.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }

            db.Libro.Remove(libro);
            await db.SaveChangesAsync();

            return Ok(libro);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LibroExists(int id)
        {
            return db.Libro.Count(e => e.IdLibro == id) > 0;
        }
    }
}