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
    public class CategoriasNoticiasController : ApiController
    {
        private NewsAppDbContext db = new NewsAppDbContext();

        // GET: api/CategoriasNoticias
        public IQueryable<CategoriasNoticias> GetCategoriasNoticias()
        {
            return db.CategoriasNoticias;
        }

        // GET: api/CategoriasNoticias/5
        [ResponseType(typeof(CategoriasNoticias))]
        public IHttpActionResult GetCategoriasNoticias(int id)
        {
            CategoriasNoticias categoriasNoticias = db.CategoriasNoticias.Find(id);
            if (categoriasNoticias == null)
            {
                return NotFound();
            }

            return Ok(categoriasNoticias);
        }

        [Authorize(Roles="Administrador")]
        // PUT: api/CategoriasNoticias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategoriasNoticias(int id, CategoriasNoticias categoriasNoticias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoriasNoticias.CategoriaId)
            {
                return BadRequest();
            }

            db.Entry(categoriasNoticias).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriasNoticiasExists(id))
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
        // POST: api/CategoriasNoticias
        [ResponseType(typeof(CategoriasNoticias))]
        public IHttpActionResult PostCategoriasNoticias(CategoriasNoticias categoriasNoticias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CategoriasNoticias.Add(categoriasNoticias);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CategoriasNoticiasExists(categoriasNoticias.CategoriaId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = categoriasNoticias.CategoriaId }, categoriasNoticias);
        }

        [Authorize(Roles = "Administrador")]
        // DELETE: api/CategoriasNoticias/5
        [ResponseType(typeof(CategoriasNoticias))]
        public IHttpActionResult DeleteCategoriasNoticias(int id)
        {
            CategoriasNoticias categoriasNoticias = db.CategoriasNoticias.Find(id);
            if (categoriasNoticias == null)
            {
                return NotFound();
            }

            db.CategoriasNoticias.Remove(categoriasNoticias);
            db.SaveChanges();

            return Ok(categoriasNoticias);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoriasNoticiasExists(int id)
        {
            return db.CategoriasNoticias.Count(e => e.CategoriaId == id) > 0;
        }
    }
}