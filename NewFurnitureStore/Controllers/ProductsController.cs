using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FurnitureStore.Models;
using NewFurnitureStore.Models;

namespace NewFurnitureStore.Controllers
{
    [Authorize(Roles = RoleName.Admin)]
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Products
        [AllowAnonymous]
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.ProductType).Include(p => p.Store).Include(p => p.WoodType);

            if (User.IsInRole(RoleName.Admin))
            {
                return View("IndexAdmin",products.ToList());
            }
            else
            {
                return View(products.ToList());
            }
           
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.ProductTypeId = new SelectList(db.ProductTypes, "Id", "Name");
            ViewBag.StoreId = new SelectList(db.Stores, "Id", "Name");
            ViewBag.WoodTypeId = new SelectList(db.WoodTypes, "Id", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
                string extension = Path.GetExtension(product.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                product.ImagePath = "~/Content/images/products/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Content/images/products/"), fileName);
                product.ImageFile.SaveAs(fileName);

                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductTypeId = new SelectList(db.ProductTypes, "Id", "Name", product.ProductTypeId);
            ViewBag.StoreId = new SelectList(db.Stores, "Id", "Name", product.StoreId);
            ViewBag.WoodTypeId = new SelectList(db.WoodTypes, "Id", "Name", product.WoodTypeId);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductTypeId = new SelectList(db.ProductTypes, "Id", "Name", product.ProductTypeId);
            ViewBag.StoreId = new SelectList(db.Stores, "Id", "Name", product.StoreId);
            ViewBag.WoodTypeId = new SelectList(db.WoodTypes, "Id", "Name", product.WoodTypeId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,WoodTypeId,Discription,Brand,Color,Price,ProductTypeId,StoreId,Stock,ImagePath")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductTypeId = new SelectList(db.ProductTypes, "Id", "Name", product.ProductTypeId);
            ViewBag.StoreId = new SelectList(db.Stores, "Id", "Name", product.StoreId);
            ViewBag.WoodTypeId = new SelectList(db.WoodTypes, "Id", "Name", product.WoodTypeId);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
