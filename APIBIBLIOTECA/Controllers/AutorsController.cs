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
    public class AutorsController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Autors
        public IQueryable<Autor> GetAutor()
        {
            return db.Autor;
        }

        // GET: api/Autors/5
        [ResponseType(typeof(Autor))]
        public async Task<IHttpActionResult> GetAutor(int id)
        {
            Autor autor = await db.Autor.FindAsync(id);
            if (autor == null)
            {
                return NotFound();
            }

            return Ok(autor);
        }

        // PUT: api/Autors/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAutor(int id, Autor autor)
        {
            if (id != autor.IdAutor)
            {
                return BadRequest();
            }

            db.Entry(autor).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutorExists(id))
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

        // POST: api/Autors
        [ResponseType(typeof(Autor))]
        public async Task<IHttpActionResult> PostAutor(Autor autor)
        {

            db.Autor.Add(autor);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = autor.IdAutor }, autor);
        }

        // DELETE: api/Autors/5
        [ResponseType(typeof(Autor))]
        public async Task<IHttpActionResult> DeleteAutor(int id)
        {
            Autor autor = await db.Autor.FindAsync(id);
            if (autor == null)
            {
                return NotFound();
            }

            db.Autor.Remove(autor);
            await db.SaveChangesAsync();

            return Ok(autor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AutorExists(int id)
        {
            return db.Autor.Count(e => e.IdAutor == id) > 0;
        }
    }
}