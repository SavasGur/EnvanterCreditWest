using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EnvanterCreditWest.Models;
using EnvanterCreditWest.Service;

namespace EnvanterCreditWest.Controllers
{
    public class ProductDetailsController : Controller
    {
        private EnvanterCreditWestContext db = new EnvanterCreditWestContext();

        // GET: ProductDetails
        public ActionResult Index()
        {
            var productDetails = db.ProductDetails.Include(p => p.Products);
            return View(productDetails.ToList());
        }

        // GET: ProductDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductDetails productDetails = db.ProductDetails.Find(id);
            if (productDetails == null)
            {
                return HttpNotFound();
            }

            return View(productDetails);
        }

        // GET: ProductDetails/Create
        public ActionResult Create(int? Id)
        {
            var product = db.ProductDetails.FirstOrDefault(x => x.ProductId==Id);
            if (product != null)
                return RedirectToAction("Details/"+ product.Id);

            ViewBag.Barcode = db.Products.Find(Id).Barcode;
            ViewBag.ProductId =Id;

            return View(new ProductDetails
            {
                ProductId=Id ?? 0
            });
        }
        
        // POST: ProductDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductId,Ram,CPU,OS,Size")] ProductDetails productDetails)
        {
            productDetails.ProductId = productDetails.Id;
            if (ModelState.IsValid)
            {
                db.ProductDetails.Add(productDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "Id", "TypeId", productDetails.ProductId);
            return View(productDetails);
        }

        // GET: ProductDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductDetails productDetails = db.ProductDetails.Find(id);
            if (productDetails == null)
            {
                return HttpNotFound();
            }

            var productId = db.ProductDetails.Find(id).ProductId;
            ViewBag.Barcode = db.Products.Find(productId).Barcode;
            return View(productDetails);
        }

        // POST: ProductDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductId,Ram,CPU,OS,Size")] ProductDetails productDetails)
        {

            if (ModelState.IsValid)
            {
                var get = db.ProductDetails.Find(productDetails.Id);

                var changes = new Changes
                {
                    LocalIpAddress = LocalIPAddress.Get(),
                    Date = DateTime.Now.Date,
                    ProductId = get.Products.Id,
                    Ip = "???"
                };

                if (get.OS != productDetails.OS)
                {
                    db.ChangeDetails.Add(new ChangeDetails
                    {
                        Changes = changes,
                        Description = "OS değişiklik yapıldı. ---- " + get.OS + " --> " + productDetails.OS
                    });
                    get.OS = productDetails.OS;
                }

                if (get.Ram != productDetails.Ram)
                {
                    db.ChangeDetails.Add(new ChangeDetails
                    {
                        Changes = changes,
                        Description = "Ram değişiklik yapıldı. ---- " + get.Ram + " --> " + productDetails.Ram
                    });
                    get.Ram = productDetails.Ram;
                }
                if (get.Ram != productDetails.Ram)
                {
                    db.ChangeDetails.Add(new ChangeDetails
                    {
                        Changes = changes,
                        Description = "Ram değişiklik yapıldı. ---- " + get.Ram + " --> " + productDetails.Ram
                    });
                    get.Ram = productDetails.Ram;
                }
                if (get.Size != productDetails.Size)
                {
                    db.ChangeDetails.Add(new ChangeDetails
                    {
                        Changes = changes,
                        Description = "Boyut değişiklik yapıldı. ---- " + get.Size + " --> " + productDetails.Size
                    });
                    get.Size = productDetails.Size;
                }

                if (get.CPU != productDetails.CPU)
                {
                    db.ChangeDetails.Add(new ChangeDetails
                    {
                        Changes = changes,
                        Description = "CPU değişiklik yapıldı. ---- " + get.CPU + " --> " + productDetails.CPU
                    });
                    get.CPU = productDetails.CPU;
                }
                db.SaveChanges();


                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "TypeId", productDetails.ProductId);
            return View(productDetails);
        }

        // GET: ProductDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductDetails productDetails = db.ProductDetails.Find(id);
            if (productDetails == null)
            {
                return HttpNotFound();
            }
            return View(productDetails);
        }

        // POST: ProductDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductDetails productDetails = db.ProductDetails.Find(id);
            db.ProductDetails.Remove(productDetails);
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
