using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Management;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using NewsApi.Models;

namespace NewsApi.Controllers
{
    public class NoticiasController : ApiController
    {
        
        private NewsAppDbContext db = new NewsAppDbContext();
       
        // GET: api/Noticias
        public IQueryable<Noticias> GetNoticias(int page = 0)
        {
            int page_size = db.Paginacions.FirstOrDefault().PageSize;
            return db.Noticias.OrderBy(n =>n.NoticiaId)
                .Skip(page * page_size)
                .Take(page_size).Where(n => n.EstadoId == 1 && n.Eliminado != true);
        }

        [Route("~/api/noticias/getallnoticias")]
        public IQueryable<Noticias> GetAllNoticias()
        {
            return db.Noticias.Where(n=> n.EstadoId == 1 && n.Eliminado!= true);
        }

        [Authorize(Roles="Administrador, Editor")]
        [Route("~/api/noticias/getalldbnoticias")]
        public IQueryable<Noticias> GetAllDbNoticias()
        {
            return db.Noticias.Where(n => n.Eliminado != true);
        }


        [Authorize(Roles = "Estándar, Administrador, Editor")]
        [Route("~/api/noticias/getnoticiasbyuser")]
        public IQueryable<Noticias> GetNoticiasByUser()
        {
            var userId = RequestContext.Principal.Identity.GetUserId();
            string  rol = db.AspNetUserRoles.FirstOrDefault(x => x.UserId == userId).RoleId;
            if(rol == "1")
            {
                return db.Noticias.Where(n => n.EstadoId == 1 && n.Eliminado != true && n.Autor == userId);
            }
            return db.Noticias.Where(n => n.Eliminado != true);
            
        }

        // GET: api/Noticias/5
        [ResponseType(typeof(Noticias))]
        public IHttpActionResult GetNoticias(short id)
        {
            Noticias noticias = db.Noticias.Find(id);
            if (noticias == null)
            {
                return NotFound();
            }

            return Ok(noticias);
        }

        [Authorize(Roles = "Estándar, Administrador, Editor")]
        // PUT: api/Noticias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNoticias(int id, Noticias noticias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != noticias.NoticiaId)
            {
                return BadRequest();
            }

            db.Entry(noticias).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoticiasExists(id))
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

        // POST: api/Noticias

        [Authorize(Roles = "Administrador, Editor, Estándar")]
        [ResponseType(typeof(Noticias))]
        public IHttpActionResult PostNoticias(Noticias noticias)
        {
            var userId = RequestContext.Principal.Identity.GetUserId();
            noticias.Autor = userId;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            noticias.FechaCreacion = DateTime.Now;

            db.Noticias.Add(noticias);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = noticias.NoticiaId }, noticias);
        }


        [Authorize(Roles = "Administrador, Editor, Estándar")]
        // DELETE: api/Noticias/5
        [ResponseType(typeof(Noticias))]
        public IHttpActionResult DeleteNoticias(int id)
        {
            Noticias noticias = db.Noticias.Find(id);
            if (noticias == null)
            {
                return NotFound();
            }

            db.Noticias.Remove(noticias);
            db.SaveChanges();

            return Ok(noticias);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NoticiasExists(int id)
        {
            return db.Noticias.Count(e => e.NoticiaId == id) > 0;
        }
    }
}