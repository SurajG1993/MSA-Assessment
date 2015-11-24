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
using Nandoso.Models;

namespace Nandoso.Controllers
{
    public class ForumRepliesController : ApiController
    {
        private NandosoContext db = new NandosoContext();

        // GET: api/ForumReplies
        public IQueryable<ForumReplies> GetForumReplies()
        {
            return db.ForumReplies;
        }

        // GET: api/ForumReplies/5
        [ResponseType(typeof(ForumReplies))]
        public IHttpActionResult GetForumReplies(int id)
        {
            ForumReplies forumReplies = db.ForumReplies.Find(id);
            if (forumReplies == null)
            {
                return NotFound();
            }

            return Ok(forumReplies);
        }

        // PUT: api/ForumReplies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutForumReplies(int id, ForumReplies forumReplies)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != forumReplies.id)
            {
                return BadRequest();
            }

            db.Entry(forumReplies).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ForumRepliesExists(id))
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

        // POST: api/ForumReplies
        [ResponseType(typeof(ForumReplies))]
        public IHttpActionResult PostForumReplies(ForumReplies forumReplies)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ForumReplies.Add(forumReplies);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = forumReplies.id }, forumReplies);
        }

        // DELETE: api/ForumReplies/5
        [ResponseType(typeof(ForumReplies))]
        public IHttpActionResult DeleteForumReplies(int id)
        {
            ForumReplies forumReplies = db.ForumReplies.Find(id);
            if (forumReplies == null)
            {
                return NotFound();
            }

            db.ForumReplies.Remove(forumReplies);
            db.SaveChanges();

            return Ok(forumReplies);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ForumRepliesExists(int id)
        {
            return db.ForumReplies.Count(e => e.id == id) > 0;
        }
    }
}