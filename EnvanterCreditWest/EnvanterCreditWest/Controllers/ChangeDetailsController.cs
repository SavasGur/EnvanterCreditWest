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
        public ActionResult Index(int? id, int? pid)
        {
            var changeDetails = new List<ChangeDetails>();

            if (id!=null)
                 changeDetails = db.ChangeDetails.Where(x => x.ChangesId==id).Include(x => x.Changes.Products).Include(c => c.Changes).ToList();

            return View(changeDetails);
        }
        public ActionResult PIndex(int? id)
        {
            var changeDetails = new List<ChangeDetails>();
            if (id != null)
                changeDetails = db.ChangeDetails.Where(x => x.Changes.ProductId == id).Include(x => x.Changes.Products).Include(c => c.Changes).ToList();

            ViewBag.ProductId = id;

            return View("Index",changeDetails);
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
            ViewBag.ChangesId = new SelectList(db.Changes, "Id", "Ip");
            return View();
        }

        // POST: ChangeDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ChangesId,Description")] ChangeDetails changeDetails)
        {
            if (ModelState.IsValid)
            {
                db.ChangeDetails.Add(changeDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ChangesId = new SelectList(db.Changes, "Id", "Ip", changeDetails.ChangesId);
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
            ViewBag.ChangesId = new SelectList(db.Changes, "Id", "Ip", changeDetails.ChangesId);
            return View(changeDetails);
        }

        // POST: ChangeDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ChangesId,Description")] ChangeDetails changeDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(changeDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChangesId = new SelectList(db.Changes, "Id", "Ip", changeDetails.ChangesId);
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
