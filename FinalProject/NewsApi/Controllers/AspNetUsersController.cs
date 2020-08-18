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
    public class AspNetUsersController : ApiController
    {
        private NewsAppDbContext db = new NewsAppDbContext();

        [Authorize (Roles="Administrador")]
        // GET: api/AspNetUsers
        public IQueryable<AspNetUsers> GetAspNetUsers()
        {
            return db.AspNetUsers.Where(u=> u.Eliminado != true);
        }

        [Authorize(Roles = "Administrador")]
        // GET: api/AspNetUsers/5
        [ResponseType(typeof(AspNetUsers))]
        public IHttpActionResult GetAspNetUsers(string id)
        {
            AspNetUsers aspNetUsers = db.AspNetUsers.Find(id);
            if (aspNetUsers == null)
            {
                return NotFound();
            }

            return Ok(aspNetUsers);
        }

        [Authorize(Roles = "Administrador")]
        // PUT: api/AspNetUsers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAspNetUsers(string id, AspNetUsers aspNetUsers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aspNetUsers.Id)
            {
                return BadRequest();
            }

            db.Entry(aspNetUsers).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AspNetUsersExists(id))
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
        // POST: api/AspNetUsers
        [ResponseType(typeof(AspNetUsers))]
        public IHttpActionResult PostAspNetUsers(AspNetUsers aspNetUsers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AspNetUsers.Add(aspNetUsers);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AspNetUsersExists(aspNetUsers.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = aspNetUsers.Id }, aspNetUsers);
        }

        [Authorize(Roles = "Administrador")]
        // DELETE: api/AspNetUsers/5
        [ResponseType(typeof(AspNetUsers))]
        public IHttpActionResult DeleteAspNetUsers(string id)
        {
            AspNetUsers aspNetUsers = db.AspNetUsers.Find(id);
            if (aspNetUsers == null)
            {
                return NotFound();
            }

            db.AspNetUsers.Remove(aspNetUsers);
            db.SaveChanges();

            return Ok(aspNetUsers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AspNetUsersExists(string id)
        {
            return db.AspNetUsers.Count(e => e.Id == id) > 0;
        }
    }
}