using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EnvanterCreditWest.Models;

namespace EnvanterCreditWest.Controllers
{
    public class UserProductsController : Controller
    {
        private EnvanterCreditWestContext db = new EnvanterCreditWestContext();

        // GET: UserProducts
        public ActionResult Index()
        {
            var userProducts = db.UserProducts.Include(u => u.Product).Include(u => u.Users);
            return View(userProducts.ToList());
        }

        // GET: UserProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProducts userProducts = db.UserProducts.Find(id);
            if (userProducts == null)
            {
                return HttpNotFound();
            }
            return View(userProducts);
        }

        // GET: UserProducts/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Type");
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName");
            return View();
        }

        // POST: UserProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductId,UserId")] UserProducts userProducts)
        {
            if (ModelState.IsValid)
            {
                db.UserProducts.Add(userProducts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "Id", "Type", userProducts.ProductId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", userProducts.UserId);
            return View(userProducts);
        }

        // GET: UserProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProducts userProducts = db.UserProducts.Find(id);
            if (userProducts == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Type", userProducts.ProductId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", userProducts.UserId);
            return View(userProducts);
        }

        // POST: UserProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductId,UserId")] UserProducts userProducts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userProducts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Type", userProducts.ProductId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", userProducts.UserId);
            return View(userProducts);
        }

        // GET: UserProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProducts userProducts = db.UserProducts.Find(id);
            if (userProducts == null)
            {
                return HttpNotFound();
            }
            return View(userProducts);
        }

        // POST: UserProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserProducts userProducts = db.UserProducts.Find(id);
            db.UserProducts.Remove(userProducts);
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
