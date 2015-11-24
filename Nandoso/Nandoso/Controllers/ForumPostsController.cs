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
    public class ForumPostsController : ApiController
    {
        private NandosoContext db = new NandosoContext();

        // GET: api/ForumPosts
        public IQueryable<ForumPost> GetForumPosts()
        {
            return db.ForumPosts;
        }

        // GET: api/ForumPosts/5
        [ResponseType(typeof(ForumPost))]
        public IHttpActionResult GetForumPost(int id)
        {
            ForumPost forumPost = db.ForumPosts.Find(id);
            if (forumPost == null)
            {
                return NotFound();
            }

            return Ok(forumPost);
        }

        // PUT: api/ForumPosts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutForumPost(int id, ForumPost forumPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != forumPost.id)
            {
                return BadRequest();
            }

            db.Entry(forumPost).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ForumPostExists(id))
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

        // POST: api/ForumPosts
        [ResponseType(typeof(ForumPost))]
        public IHttpActionResult PostForumPost(ForumPost forumPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ForumPosts.Add(forumPost);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = forumPost.id }, forumPost);
        }

        // DELETE: api/ForumPosts/5
        [ResponseType(typeof(ForumPost))]
        public IHttpActionResult DeleteForumPost(int id)
        {
            ForumPost forumPost = db.ForumPosts.Find(id);
            if (forumPost == null)
            {
                return NotFound();
            }

            db.ForumPosts.Remove(forumPost);
            db.SaveChanges();

            return Ok(forumPost);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ForumPostExists(int id)
        {
            return db.ForumPosts.Count(e => e.id == id) > 0;
        }
    }
}