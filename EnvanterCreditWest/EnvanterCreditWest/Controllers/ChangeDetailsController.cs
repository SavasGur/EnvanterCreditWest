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
    public class ChangeDetailsController : Controller
    {
        private EnvanterCreditWestContext db = new EnvanterCreditWestContext();

        // GET: ChangeDetails
        public ActionResult Index()
        {
            return View(db.ChangeDetails.ToList());
        }

        // GET: ChangeDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChangeDetails changeDetails = db.ChangeDetails.Find(id);
            if (changeDetails == null)
            {
                return HttpNotFound();
            }
            return View(changeDetails);
        }

        // GET: ChangeDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChangeDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TypeId")] ChangeDetails changeDetails)
        {
            if (ModelState.IsValid)
            {
                db.ChangeDetails.Add(changeDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(changeDetails);
        }

        // GET: ChangeDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChangeDetails changeDetails = db.ChangeDetails.Find(id);
            if (changeDetails == null)
            {
                return HttpNotFound();
            }
            return View(changeDetails);
        }

        // POST: ChangeDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TypeId")] ChangeDetails changeDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(changeDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(changeDetails);
        }

        // GET: ChangeDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChangeDetails changeDetails = db.ChangeDetails.Find(id);
            if (changeDetails == null)
            {
                return HttpNotFound();
            }
            return View(changeDetails);
        }

        // POST: ChangeDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChangeDetails changeDetails = db.ChangeDetails.Find(id);
            db.ChangeDetails.Remove(changeDetails);
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
