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
    public class EstudiantesController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Estudiantes
        public IQueryable<Estudiante> GetEstudiante()
        {
            return db.Estudiante;
        }

        // GET: api/Estudiantes/5
        [ResponseType(typeof(Estudiante))]
        public async Task<IHttpActionResult> GetEstudiante(int id)
        {
            Estudiante estudiante = await db.Estudiante.FindAsync(id);
            if (estudiante == null)
            {
                return NotFound();
            }

            return Ok(estudiante);
        }

        // PUT: api/Estudiantes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEstudiante(int id, Estudiante estudiante)
        {

            if (id != estudiante.IdLector)
            {
                return BadRequest();
            }

            db.Entry(estudiante).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstudianteExists(id))
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

        // POST: api/Estudiantes
        [ResponseType(typeof(Estudiante))]
        public async Task<IHttpActionResult> PostEstudiante(Estudiante estudiante)
        {
            db.Estudiante.Add(estudiante);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = estudiante.IdLector }, estudiante);
        }

        // DELETE: api/Estudiantes/5
        [ResponseType(typeof(Estudiante))]
        public async Task<IHttpActionResult> DeleteEstudiante(int id)
        {
            Estudiante estudiante = await db.Estudiante.FindAsync(id);
            if (estudiante == null)
            {
                return NotFound();
            }

            db.Estudiante.Remove(estudiante);
            await db.SaveChangesAsync();

            return Ok(estudiante);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EstudianteExists(int id)
        {
            return db.Estudiante.Count(e => e.IdLector == id) > 0;
        }
    }
}