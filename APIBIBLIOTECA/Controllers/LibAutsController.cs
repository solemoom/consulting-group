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
    public class LibAutsController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/LibAuts
        public IQueryable<LibAut> GetLibAut()
        {
            return db.LibAut;
        }

        // GET: api/LibAuts/5
        [ResponseType(typeof(LibAut))]
        public async Task<IHttpActionResult> GetLibAut(int id)
        {
            LibAut libAut = await db.LibAut.FindAsync(id);
            if (libAut == null)
            {
                return NotFound();
            }

            return Ok(libAut);
        }

        // PUT: api/LibAuts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLibAut(int id, LibAut libAut)
        {
            if (id != libAut.IdLibAut)
            {
                return BadRequest();
            }
            db.Entry(libAut).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibAutExists(id))
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

        // POST: api/LibAuts
        [ResponseType(typeof(LibAut))]
        public async Task<IHttpActionResult> PostLibAut(LibAut libAut)
        {

            db.LibAut.Add(libAut);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = libAut.IdLibAut }, libAut);
        }

        // DELETE: api/LibAuts/5
        [ResponseType(typeof(LibAut))]
        public async Task<IHttpActionResult> DeleteLibAut(int id)
        {
            LibAut libAut = await db.LibAut.FindAsync(id);
            if (libAut == null)
            {
                return NotFound();
            }

            db.LibAut.Remove(libAut);
            await db.SaveChangesAsync();

            return Ok(libAut);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LibAutExists(int id)
        {
            return db.LibAut.Count(e => e.IdLibAut == id) > 0;
        }
    }
}