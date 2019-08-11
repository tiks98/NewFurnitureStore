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
using FurnitureStore.Models;
using NewFurnitureStore.Models;

namespace NewFurnitureStore.Controllers.API
{
    public class WoodTypesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/WoodTypes
        public IQueryable<WoodType> GetWoodTypes()
        {
            return db.WoodTypes;
        }

        // GET: api/WoodTypes/5
        [ResponseType(typeof(WoodType))]
        public IHttpActionResult GetWoodType(int id)
        {
            WoodType woodType = db.WoodTypes.Find(id);
            if (woodType == null)
            {
                return NotFound();
            }

            return Ok(woodType);
        }

        // PUT: api/WoodTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWoodType(int id, WoodType woodType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != woodType.Id)
            {
                return BadRequest();
            }

            db.Entry(woodType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WoodTypeExists(id))
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

        // POST: api/WoodTypes
        [ResponseType(typeof(WoodType))]
        public IHttpActionResult PostWoodType(WoodType woodType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.WoodTypes.Add(woodType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = woodType.Id }, woodType);
        }

        // DELETE: api/WoodTypes/5
        [ResponseType(typeof(WoodType))]
        public IHttpActionResult DeleteWoodType(int id)
        {
            WoodType woodType = db.WoodTypes.Find(id);
            if (woodType == null)
            {
                return NotFound();
            }

            db.WoodTypes.Remove(woodType);
            db.SaveChanges();

            return Ok(woodType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WoodTypeExists(int id)
        {
            return db.WoodTypes.Count(e => e.Id == id) > 0;
        }
    }
}