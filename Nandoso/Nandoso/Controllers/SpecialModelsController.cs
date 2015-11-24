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
    public class SpecialModelsController : ApiController
    {
        private NandosoContext db = new NandosoContext();

        // GET: api/SpecialModels
        public IQueryable<SpecialModel> GetSpecialModels()
        {
            return db.SpecialModels;
        }

        // GET: api/SpecialModels/5
        [ResponseType(typeof(SpecialModel))]
        public IHttpActionResult GetSpecialModel(int id)
        {
            SpecialModel specialModel = db.SpecialModels.Find(id);
            if (specialModel == null)
            {
                return NotFound();
            }

            return Ok(specialModel);
        }

        // PUT: api/SpecialModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSpecialModel(int id, SpecialModel specialModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != specialModel.id)
            {
                return BadRequest();
            }

            db.Entry(specialModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecialModelExists(id))
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

        // POST: api/SpecialModels
        [ResponseType(typeof(SpecialModel))]
        public IHttpActionResult PostSpecialModel(SpecialModel specialModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SpecialModels.Add(specialModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = specialModel.id }, specialModel);
        }

        // DELETE: api/SpecialModels/5
        [ResponseType(typeof(SpecialModel))]
        public IHttpActionResult DeleteSpecialModel(int id)
        {
            SpecialModel specialModel = db.SpecialModels.Find(id);
            if (specialModel == null)
            {
                return NotFound();
            }

            db.SpecialModels.Remove(specialModel);
            db.SaveChanges();

            return Ok(specialModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SpecialModelExists(int id)
        {
            return db.SpecialModels.Count(e => e.id == id) > 0;
        }
    }
}