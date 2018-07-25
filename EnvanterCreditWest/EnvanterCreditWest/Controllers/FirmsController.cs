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
    public class FirmsController : Controller
    {
        private EnvanterCreditWestContext db = new EnvanterCreditWestContext();

        // GET: Firms
        public ActionResult Index()
        {
            return View(db.Firms.ToList());
        }

        // GET: Firms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Firms firms = db.Firms.Find(id);
            if (firms == null)
            {
                return HttpNotFound();
            }
            return View(firms);
        }

        // GET: Firms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Firms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,PhoneNumber,Email,Address,VendorName,VendorEmail,VendorNumber,Description")] Firms firms)
        {
            if (ModelState.IsValid)
            {
                db.Firms.Add(firms);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(firms);
        }

        // GET: Firms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Firms firms = db.Firms.Find(id);
            if (firms == null)
            {
                return HttpNotFound();
            }
            return View(firms);
        }

        // POST: Firms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,PhoneNumber,Email,Address,VendorName,VendorEmail,VendorNumber,Description")] Firms firms)
        {
            if (ModelState.IsValid)
            {
                db.Entry(firms).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(firms);
        }

        // GET: Firms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Firms firms = db.Firms.Find(id);
            if (firms == null)
            {
                return HttpNotFound();
            }
            return View(firms);
        }

        // POST: Firms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Firms firms = db.Firms.Find(id);
            db.Firms.Remove(firms);
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
