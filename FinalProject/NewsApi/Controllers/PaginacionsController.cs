using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using NewsApi.Models;

namespace NewsApi.Controllers
{
    public class PaginacionsController : ApiController
    {
        private NewsAppDbContext db = new NewsAppDbContext();

        [Authorize(Roles = "Administrador")]
        // GET: api/Paginacions
        public IQueryable<Paginacion> GetPaginacions()
        {
            return db.Paginacions;
        }

        // GET: api/Paginacions/5
        [ResponseType(typeof(Paginacion))]
        public IHttpActionResult GetPaginacion(int id)
        {
            Paginacion paginacion = db.Paginacions.Find(id);
            if (paginacion == null)
            {
                return NotFound();
            }

            return Ok(paginacion);
        }


        [Authorize(Roles = "Administrador")]
        // PUT: api/Paginacions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPaginacion(int id, Paginacion paginacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paginacion.PaginacionId)
            {
                return BadRequest();
            }

            db.Entry(paginacion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaginacionExists(id))
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

        [Authorize(Roles = "Administrador")]
        // POST: api/Paginacions
        [ResponseType(typeof(Paginacion))]
        public IHttpActionResult PostPaginacion(Paginacion paginacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Paginacions.Add(paginacion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = paginacion.PaginacionId }, paginacion);
        }

        [Authorize(Roles = "Administrador")]
        // DELETE: api/Paginacions/5
        [ResponseType(typeof(Paginacion))]
        public IHttpActionResult DeletePaginacion(int id)
        {
            Paginacion paginacion = db.Paginacions.Find(id);
            if (paginacion == null)
            {
                return NotFound();
            }

            db.Paginacions.Remove(paginacion);
            db.SaveChanges();

            return Ok(paginacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PaginacionExists(int id)
        {
            return db.Paginacions.Count(e => e.PaginacionId == id) > 0;
        }
    }
}