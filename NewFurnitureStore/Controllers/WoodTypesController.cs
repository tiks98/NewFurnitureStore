using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FurnitureStore.Models;
using NewFurnitureStore.Models;

namespace NewFurnitureStore.Controllers
{
    public class WoodTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WoodTypes
        public ActionResult Index()
        {
            return View(db.WoodTypes.ToList());
        }

        // GET: WoodTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WoodType woodType = db.WoodTypes.Find(id);
            if (woodType == null)
            {
                return HttpNotFound();
            }
            return View(woodType);
        }

        // GET: WoodTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WoodTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] WoodType woodType)
        {
            if (ModelState.IsValid)
            {
                db.WoodTypes.Add(woodType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(woodType);
        }

        // GET: WoodTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WoodType woodType = db.WoodTypes.Find(id);
            if (woodType == null)
            {
                return HttpNotFound();
            }
            return View(woodType);
        }

        // POST: WoodTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] WoodType woodType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(woodType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(woodType);
        }

        // GET: WoodTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WoodType woodType = db.WoodTypes.Find(id);
            if (woodType == null)
            {
                return HttpNotFound();
            }
            return View(woodType);
        }

        // POST: WoodTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WoodType woodType = db.WoodTypes.Find(id);
            db.WoodTypes.Remove(woodType);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
