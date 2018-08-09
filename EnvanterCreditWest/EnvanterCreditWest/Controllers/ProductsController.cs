using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EnvanterCreditWest.Models;

namespace EnvanterCreditWest.Controllers
{
    public class ProductsController : Controller
    {
        private EnvanterCreditWestContext db = new EnvanterCreditWestContext();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Branches).Include(p => p.Brands).Include(p => p.Firms).Include(p => p.Users);

            ViewBag.Branches = new SelectList(db.Branches, "Id", "BranchName");
            ViewBag.Firms = new SelectList(db.Firms, "Id", "Name");
            ViewBag.Users = new SelectList(db.Users, "Id", "FirstLastName");
            ViewBag.Brands = new SelectList(db.Brands, "Id", "BrandName");
           

            List<string> list = new List<string>();
            foreach(var item in products)
            {
                list.Add(item.Model);
            }
            ViewBag.Models = new SelectList(list);

            return View(products.ToList());
        }

        public ActionResult Search(int checkBrand, int checkBranch, int checkFirm, int checkUser, int checkModel, int dropBranch, int dropBrand, int dropFirm, int dropUser, string dropModel)
        {
            var products = db.Products.Include(p => p.Branches).Include(p => p.Firms).Include(p => p.Users).ToList();
            List<string> list = new List<string>();
            foreach (var item in products)
            {
                list.Add(item.Model);
            }
            ViewBag.Models = new SelectList(list,dropModel);

            if (checkBrand == 1)
                products = products.Where(x => x.BrandId == dropBrand).ToList();

            if (checkBranch == 1)
                products = products.Where(x => x.BranchId == dropBranch).ToList();

            if (checkFirm == 1)
                products = products.Where(x => x.FirmId == dropFirm).ToList();

            if (checkUser == 1)
                products = products.Where(x => x.UserId == dropUser).ToList();

            if (checkModel == 1)
                products = products.Where(x => x.Model == dropModel).ToList();

            ViewBag.Branches = new SelectList(db.Branches, "Id", "BranchName", dropBranch);
            ViewBag.Firms = new SelectList(db.Firms, "Id", "Name", dropFirm);
            ViewBag.Users = new SelectList(db.Users, "Id", "FirstLastName", dropUser);
            ViewBag.Brands = new SelectList(db.Brands, "Id", "BrandName", dropBrand);



            return View("Index", products);
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName");
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "BrandName");
            ViewBag.FirmId = new SelectList(db.Firms, "Id", "Name");
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstLastName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase invoiceFile,[Bind(Include = "Id,Type,BrandId,Model,Barcode,BranchId,UserId,DateAcquired,Warranty,FirmId,Status,Price,InvoiceURL")] Products products)
        {
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName", products.BranchId);
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "BrandName", products.BrandId);
            ViewBag.FirmId = new SelectList(db.Firms, "Id", "Name", products.FirmId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstLastName", products.UserId);


            products.InvoiceURL = "";
            if (ModelState.IsValid)
            {
                if (invoiceFile == null)
                {
                    return View(products);
                }
                else
                {
                    var extension = Path.GetExtension(invoiceFile.FileName);

                    var imgName = products.Barcode + extension;

                    string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(imgName));
                    invoiceFile.SaveAs(path);
                    products.InvoiceURL = "/Images/" + imgName;
                }

                db.Products.Add(products);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                db.Products.Add(products);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

    
            return View(products);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName", products.BranchId);
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "BrandName", products.BrandId);
            ViewBag.FirmId = new SelectList(db.Firms, "Id", "Name", products.FirmId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstLastName", products.UserId);
            return View(products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type,BrandId,Model,Barcode,BranchId,UserId,DateAcquired,Warranty,FirmId,Status,Price,InvoiceURL")] Products products)
        {
            if (ModelState.IsValid)
            {
                db.Entry(products).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName", products.BranchId);
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "BrandName", products.BrandId);
            ViewBag.FirmId = new SelectList(db.Firms, "Id", "Name", products.FirmId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstLastName", products.UserId);
            return View(products);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Products products = db.Products.Find(id);
            db.Products.Remove(products);
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
