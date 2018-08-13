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
    public class ChangesController : Controller
    {
        private EnvanterCreditWestContext db = new EnvanterCreditWestContext();

        // GET: Changes
        public ActionResult Index()
        {
            var changes = db.Changes.Include(c => c.ChangeDetails).Include(c => c.Products);
            return View(changes.ToList());
        }

        // GET: Changes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Changes changes = db.Changes.Find(id);
            if (changes == null)
            {
                return HttpNotFound();
            }
            return View(changes);
        }

        // GET: Changes/Create
        public ActionResult Create()
        {
            ViewBag.ChangesDetailsId = new SelectList(db.ChangeDetails, "Id", "Type");
            ViewBag.ProductId = new SelectList(db.Products, "Id", "TypeId");
            return View();
        }

        // POST: Changes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,ChangesDetailsId,Description,IP,ProductId")] Changes changes)
        {
            if (ModelState.IsValid)
            {
                db.Changes.Add(changes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ChangesDetailsId = new SelectList(db.ChangeDetails, "Id", "Type", changes.ChangesDetailsId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "TypeId", changes.ProductId);
            return View(changes);
        }

        // GET: Changes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Changes changes = db.Changes.Find(id);
            if (changes == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChangesDetailsId = new SelectList(db.ChangeDetails, "Id", "Type", changes.ChangesDetailsId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "TypeId", changes.ProductId);
            return View(changes);
        }

        // POST: Changes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,ChangesDetailsId,Description,IP,ProductId")] Changes changes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(changes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChangesDetailsId = new SelectList(db.ChangeDetails, "Id", "Type", changes.ChangesDetailsId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "TypeId", changes.ProductId);
            return View(changes);
        }

        // GET: Changes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Changes changes = db.Changes.Find(id);
            if (changes == null)
            {
                return HttpNotFound();
            }
            return View(changes);
        }

        // POST: Changes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Changes changes = db.Changes.Find(id);
            db.Changes.Remove(changes);
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
