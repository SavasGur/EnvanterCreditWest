using System;
using System.Activities;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BarcodeLib;
using EnvanterCreditWest.Bind;
using EnvanterCreditWest.Models;
using EnvanterCreditWest.Service;
using Newtonsoft.Json;

namespace EnvanterCreditWest.Controllers
{
    public class ProductsController : Controller
    {
        private EnvanterCreditWestContext db = new EnvanterCreditWestContext();
        System.Drawing.Image printImg;

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Branches).Include(p => p.Brands).Include(p => p.Firms).Include(p => p.ProductModels).Include(p => p.Types).Include(p => p.Users);
            ViewBag.Branches = new SelectList(db.Branches, "Id", "BranchName");
            ViewBag.Firms = new SelectList(db.Firms, "Id", "Name");
            ViewBag.Users = new SelectList(db.Users, "Id", "FirstLastName");
            ViewBag.Brands = new SelectList(db.Brands, "Id", "BrandName");
            ViewBag.Models = new SelectList(db.ProductModels, "Id", "Name");
            ViewBag.StatusId = new SelectList(db.Statuses, "Id", "Name");

            return View(products.ToList());
        }

        public ActionResult Barcode(string barcode)
        {
            var products = db.Products.Include(p => p.Branches).Include(p => p.Firms).Include(p => p.Users).FirstOrDefault(x => x.Barcode == barcode);
            var productsDetail = new ProductDetails();
            productsDetail = db.ProductDetails.FirstOrDefault(x => x.ProductId == products.Id);

            if (productsDetail == null)
                productsDetail = new ProductDetails { Id = -1, ProductId = products.Id };

            return View("Details", new ProductBind
            {
                Products = products,
                ProductDetails = productsDetail
            });
        }

        public string CreateBarcode(string barcode = "")
        {
            Barcode b = new Barcode();
            Image img = b.Encode(TYPE.Interleaved2of5, barcode, Color.Black, Color.White, 290, 120);
            var randomString = RandomStringGenerator.RandomString();
            var path = Server.MapPath("/Resources/" + randomString) + ".jpg";
            img.Save(path);

            return "/Resources/" + randomString + ".jpg";
        }

        public ActionResult Search(int checkBrand, int checkBranch, int checkFirm, int checkUser, int checkModel, int checkStatus, int dropBranch, int dropBrand, int dropFirm, int dropUser, int dropModel,int dropStatus)
        {
            var products = db.Products.Include(p => p.Branches).Include(p => p.Firms).Include(p => p.Users).ToList();

            if (checkBrand == 1)
                products = products.Where(x => x.BrandId == dropBrand).ToList();

            if (checkBranch == 1)
                products = products.Where(x => x.BranchId == dropBranch).ToList();

            if (checkFirm == 1)
                products = products.Where(x => x.FirmId == dropFirm).ToList();

            if (checkUser == 1)
                products = products.Where(x => x.UserId == dropUser).ToList();

            if (checkModel == 1)
                products = products.Where(x => x.ProductModelId == dropModel).ToList();

            if (checkStatus == 1)
                products = products.Where(x => x.StatusId == dropStatus).ToList();


            ViewBag.Branches = new SelectList(db.Branches, "Id", "BranchName", dropBranch);
            ViewBag.Firms = new SelectList(db.Firms, "Id", "Name", dropFirm);
            ViewBag.Users = new SelectList(db.Users, "Id", "FirstLastName", dropUser);
            ViewBag.Brands = new SelectList(db.Brands, "Id", "BrandName", dropBrand);
            ViewBag.Models = new SelectList(db.ProductModels, "Id", "Name", dropModel);
            ViewBag.StatusId = new SelectList(db.Statuses, "Id", "Name");


            ViewBag.Count = products.Count;
            return View(products);
        }


        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);

            var productsDetail = new ProductDetails();

            productsDetail = db.ProductDetails.FirstOrDefault(x => x.ProductId==products.Id);

            if (products == null)
            {
                return HttpNotFound();
            }
            if (productsDetail == null)
                productsDetail = new ProductDetails{Id = -1,ProductId=products.Id};

            switch(products.Currency)
            {
                case 0:
                    ViewBag.Currency = "₺ (TL)"; break;
                case 1:
                    ViewBag.Currency = "$ (USD)";break;
                case 2:
                    ViewBag.Currency = "€ (EUR)"; break;
                case 3:
                    ViewBag.Currency = "£ (STG)"; break;
            }

            return View(new ProductBind
            {
                Products = products,
                ProductDetails=productsDetail
            });
        }

        public ActionResult PrintBarcode(int? id)
        {
            var getUrl = db.Products.Find(id)?.BarcodeUrl;

            if(getUrl!=null)
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += Pd_PrintPage;
                var url = Path.Combine(Server.MapPath("~/Resources"), Path.GetFileName(getUrl));
                printImg = System.Drawing.Image.FromFile(url);
                pd.Print();
                return null;
            }
            else
            {
                return null;
            }
        }

        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            Point loc = new Point(100, 100);
            e.Graphics.DrawImage(printImg, loc);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName");
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "BrandName");
            ViewBag.FirmId = new SelectList(db.Firms, "Id", "Name");
            ViewBag.ProductModelId = new SelectList(db.ProductModels, "Id", "Name");
            ViewBag.TypeId = new SelectList(db.Types, "Id", "Name");
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstLastName");
            ViewBag.StatusId = new SelectList(db.Statuses, "Id", "Name");
            ViewBag.Currency = new SelectList(new List<SelectListItem>
                               {
                                    new SelectListItem { Selected = true, Text = "₺ (TL) ", Value = "0"},
                                    new SelectListItem { Selected = false, Text = "$ (USD) ", Value = "1"},
                                    new SelectListItem { Selected = false, Text = "€ (EUR)", Value = "2"},
                                    new SelectListItem { Selected = false, Text = "£ (STG)", Value = "3"},
                               },
                                "Value", "Text", 0);

            var list = new List<TypeToModels>();
            var modelsList = db.ProductModels.ToList();
            foreach (var item in modelsList)
            {
                list.Add(new TypeToModels
                {
                    ModelId=item.Id,
                    TypeId=item.TypeId
                });
            }

            ViewBag.TypeToModels = JsonConvert.SerializeObject(list);


            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase invoiceFile,[Bind(Include = "Id,BrandId,ProductModelId,Barcode,BranchId,UserId,DateAcquired,Warranty,FirmId,Status,Price,InvoiceURL,TypeId,StatusId,Currency")] Products products)
        {
            products.InvoiceURL = "";
            if (ModelState.IsValid)
            {
                var code = db.Types.First(x => x.Id == products.TypeId).Code;
                code += db.Brands.First(x => x.Id == products.BrandId).Code;
                code += db.ProductModels.First(x => x.Id == products.ProductModelId).Code;
                code += RandomStringGenerator.RandomInt();

                products.Barcode = code;
                products.BarcodeUrl = CreateBarcode(code);

                if (invoiceFile != null)
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

            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName", products.BranchId);
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "BrandName", products.BrandId);
            ViewBag.FirmId = new SelectList(db.Firms, "Id", "Name", products.FirmId);
            ViewBag.ProductModelId = new SelectList(db.ProductModels, "Id", "Name", products.ProductModelId);
            ViewBag.TypeId = new SelectList(db.Types, "Id", "Name", products.TypeId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstLastName", products.UserId);
            ViewBag.StatusId = new SelectList(db.Statuses, "Id", "Name", products.StatusId);
            ViewBag.Currency = new SelectList(new List<SelectListItem>
                               {
                                    new SelectListItem { Selected = true, Text = "₺ (TL) ", Value = "0"},
                                    new SelectListItem { Selected = false, Text = "$ (USD) ", Value = "1"},
                                    new SelectListItem { Selected = false, Text = "€ (EUR)", Value = "2"},
                                    new SelectListItem { Selected = false, Text = "£ (STG)", Value = "3"},
                               },
                    "Value", "Text", products.Currency);

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
            ViewBag.ProductModelId = new SelectList(db.ProductModels, "Id", "Name", products.ProductModelId);
            ViewBag.TypeId = new SelectList(db.Types, "Id", "Code", products.TypeId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstLastName", products.UserId);
            ViewBag.StatusId = new SelectList(db.Statuses, "Id", "Name", products.StatusId);
            ViewBag.Currency = new SelectList(new List<SelectListItem>
                               {
                                    new SelectListItem { Selected = true, Text = "₺ (TL) ", Value = "0"},
                                    new SelectListItem { Selected = false, Text = "$ (USD) ", Value = "1"},
                                    new SelectListItem { Selected = false, Text = "€ (EUR)", Value = "2"},
                                    new SelectListItem { Selected = false, Text = "£ (STG)", Value = "3"},
                               },
                    "Value", "Text", products.Currency);

            return View(products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BrandId,ProductModelId,Barcode,BranchId,UserId,DateAcquired,Warranty,FirmId,Status,Price,InvoiceURL,TypeId,StatusId,Currency")] Products products)
        {

            if (ModelState.IsValid)
            {
                var getProduct = db.Products.Find(products.Id);

                var changes = new Changes
                {
                    LocalIpAddress = LocalIPAddress.Get(),
                    Date = DateTime.Now.Date,
                    ProductId = products.Id,
                    Ip="???"
                };
                db.Changes.Add(changes);

                var code = db.Types.First(x => x.Id == products.TypeId).Code;
                code += db.Brands.First(x => x.Id == products.BrandId).Code;
                code += db.ProductModels.First(x => x.Id == products.ProductModelId).Code;

                var getOldBarcode = getProduct.Barcode.Substring(0, 6);

                if (getOldBarcode != code)
                {
                    code += RandomStringGenerator.RandomInt();
                    getProduct.BarcodeUrl = CreateBarcode(code);
                    db.ChangeDetails.Add(new ChangeDetails
                    {
                        Changes= changes,
                        Description = "Barcode değişiklik yapıldı. " + getProduct.Barcode + " --> " + code
                    });
                    getProduct.Barcode = code;
                }

                if (getProduct.BranchId != products.BranchId)
                {
                    var eskiSube = db.Branches.Find(getProduct.BranchId).BranchName;
                    var yeniSube = db.Branches.Find(products.BranchId).BranchName;

                    db.ChangeDetails.Add(new ChangeDetails
                    {
                        Changes = changes,
                        Description = "Şube değişiklik yapıldı. " + eskiSube + " --> " + yeniSube
                    });
                    getProduct.BranchId = products.BranchId;
                }

                if (getProduct.BrandId != products.BrandId)
                {
                    var eskiMarka = db.Brands.Find(getProduct.BrandId).BrandName;
                    var yeniMarka = db.Brands.Find(products.BrandId).BrandName;

                    db.ChangeDetails.Add(new ChangeDetails
                    {
                        Changes = changes,
                        Description = "Marka değişiklik yapıldı. " + eskiMarka + " --> " + yeniMarka
                    });
                    getProduct.BrandId = products.BrandId;
                }

                if (getProduct.FirmId != products.FirmId)
                {
                    var eskiFirma = db.Firms.Find(getProduct.FirmId).Name;
                    var yeniFirma = db.Firms.Find(products.FirmId).Name;

                    db.ChangeDetails.Add(new ChangeDetails
                    {
                        Changes = changes,
                        Description = "Firma değişiklik yapıldı. " + eskiFirma + " --> " + yeniFirma
                    });

                    getProduct.FirmId = products.FirmId;
                }

                if (getProduct.Price != products.Price)
                {
                    db.ChangeDetails.Add(new ChangeDetails
                    {
                        Changes = changes,
                        Description = "Fiyat değişiklik yapıldı. " + getProduct.Price + " --> " + products.Price
                    });

                    getProduct.Price = products.Price;
                }

                if (getProduct.TypeId != products.TypeId)
                {
                    var eskiTip = db.Types.Find(getProduct.TypeId).Name;
                    var yeniTip = db.Types.Find(products.TypeId).Name;

                    db.ChangeDetails.Add(new ChangeDetails
                    {
                        Changes = changes,
                        Description = "Tipi değişiklik yapıldı. " + eskiTip + " --> " + yeniTip
                    });
                    getProduct.TypeId = products.TypeId;
                }

                if (getProduct.UserId != products.UserId)
                {
                    var eskiKullanıcı = db.Users.Find(getProduct.UserId).FirstLastName;
                    var yeniKullanıcı = db.Users.Find(products.UserId).FirstLastName;

                    db.ChangeDetails.Add(new ChangeDetails
                    {
                        Changes = changes,
                        Description = "Kullanıcı değişiklik yapıldı. " + eskiKullanıcı + " --> " + yeniKullanıcı
                    });

                    getProduct.UserId = products.UserId;
                }

                if (getProduct.StatusId != products.StatusId)
                {
                    var eskiDurum = db.Statuses.Find(getProduct.StatusId).Name;
                    var yeniDurum = db.Statuses.Find(products.StatusId).Name;

                    db.ChangeDetails.Add(new ChangeDetails
                    {
                        Changes = changes,
                        Description = "Durumu değişiklik yapıldı. " + eskiDurum + " --> " + yeniDurum
                    });
                    getProduct.StatusId = products.StatusId;
                }

                if (getProduct.ProductModelId != products.ProductModelId)
                {
                    var eskiModel = db.ProductModels.Find(getProduct.ProductModelId).Name;
                    var yeniModel = db.ProductModels.Find(products.ProductModelId).Name;

                    db.ChangeDetails.Add(new ChangeDetails
                    {
                        Changes = changes,
                        Description = "Model değişiklik yapıldı. " + eskiModel + " --> " + yeniModel
                    });
                    getProduct.ProductModelId = products.ProductModelId;
                }

                if (getProduct.DateAcquired != products.DateAcquired)
                {
                    db.ChangeDetails.Add(new ChangeDetails
                    {
                        Changes = changes,
                        Description = "Teslim tarihi değişiklik yapıldı. " + getProduct.DateAcquired + " --> " + products.DateAcquired
                    });

                    getProduct.DateAcquired = products.DateAcquired;
                }

                if (getProduct.Currency != products.Currency)
                {
                    db.ChangeDetails.Add(new ChangeDetails
                    {
                        Changes = changes,
                        Description = "Kur tarihi değişiklik yapıldı. " + getProduct.Currency + " --> " + products.Currency
                    });

                    getProduct.Currency = products.Currency;
                }

                if (getProduct.Warranty != products.Warranty)
                {
                    db.ChangeDetails.Add(new ChangeDetails
                    {
                        Changes = changes,
                        Description = "Garanti tarihi değişiklik yapıldı. " + getProduct.Warranty + " --> " + products.Warranty
                    });

                    getProduct.Warranty = products.Warranty;
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName", products.BranchId);
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "Code", products.BrandId);
            ViewBag.FirmId = new SelectList(db.Firms, "Id", "Name", products.FirmId);
            ViewBag.ProductModelId = new SelectList(db.ProductModels, "Id", "Name", products.ProductModelId);
            ViewBag.TypeId = new SelectList(db.Types, "Id", "Code", products.TypeId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstLastName", products.UserId);
            ViewBag.StatusId = new SelectList(db.Statuses, "Id", "Name", products.StatusId);
            ViewBag.Currency = new SelectList(new List<SelectListItem>
                               {
                                    new SelectListItem { Selected = true, Text = "₺ (TL) ", Value = "0"},
                                    new SelectListItem { Selected = false, Text = "$ (USD) ", Value = "1"},
                                    new SelectListItem { Selected = false, Text = "€ (EUR)", Value = "2"},
                                    new SelectListItem { Selected = false, Text = "£ (STG)", Value = "3"},
                               },
                                "Value", "Text", products.Currency);

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
