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
    public class TypeysController : Controller
    {
        private EnvanterCreditWestContext db = new EnvanterCreditWestContext();

        // GET: Typeys
        public ActionResult Index()
        {
            return View(db.Types.ToList());
        }

        // GET: Typeys/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Typey typey = db.Types.Find(id);
            if (typey == null)
            {
                return HttpNotFound();
            }
            return View(typey);
        }

        // GET: Typeys/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Typeys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TypeName")] Typey typey)
        {
            if (ModelState.IsValid)
            {
                db.Types.Add(typey);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typey);
        }

        // GET: Typeys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Typey typey = db.Types.Find(id);
            if (typey == null)
            {
                return HttpNotFound();
            }
            return View(typey);
        }

        // POST: Typeys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TypeName")] Typey typey)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typey).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typey);
        }

        // GET: Typeys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Typey typey = db.Types.Find(id);
            if (typey == null)
            {
                return HttpNotFound();
            }
            return View(typey);
        }

        // POST: Typeys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Typey typey = db.Types.Find(id);
            db.Types.Remove(typey);
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
