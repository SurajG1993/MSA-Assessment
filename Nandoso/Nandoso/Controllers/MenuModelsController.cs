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
    public class MenuModelsController : ApiController
    {
        private NandosoContext db = new NandosoContext();

        // GET: api/MenuModels
        public IQueryable<MenuModel> GetMenuModels()
        {
            return db.MenuModels;
        }

        // GET: api/MenuModels/5
        [ResponseType(typeof(MenuModel))]
        public IHttpActionResult GetMenuModel(int id)
        {
            MenuModel menuModel = db.MenuModels.Find(id);
            if (menuModel == null)
            {
                return NotFound();
            }

            return Ok(menuModel);
        }

        // PUT: api/MenuModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMenuModel(int id, MenuModel menuModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != menuModel.id)
            {
                return BadRequest();
            }

            db.Entry(menuModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuModelExists(id))
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

        // POST: api/MenuModels
        [ResponseType(typeof(MenuModel))]
        public IHttpActionResult PostMenuModel(MenuModel menuModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MenuModels.Add(menuModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = menuModel.id }, menuModel);
        }

        // DELETE: api/MenuModels/5
        [ResponseType(typeof(MenuModel))]
        public IHttpActionResult DeleteMenuModel(int id)
        {
            MenuModel menuModel = db.MenuModels.Find(id);
            if (menuModel == null)
            {
                return NotFound();
            }

            db.MenuModels.Remove(menuModel);
            db.SaveChanges();

            return Ok(menuModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MenuModelExists(int id)
        {
            return db.MenuModels.Count(e => e.id == id) > 0;
        }
    }
}