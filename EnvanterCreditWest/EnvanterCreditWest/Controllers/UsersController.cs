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
    public class UsersController : Controller
    {
        private EnvanterCreditWestContext db = new EnvanterCreditWestContext();

        // GET: Users
        public ActionResult Index()
        {
            

            return View(db.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstLastName,Username,Password,Admin")] Users users)
        {
            if (ModelState.IsValid)
            {
                var getUser = db.Users.ToList();
                var checkUser = getUser.FirstOrDefault(x => x.Username == users.Username && x.Id != users.Id);
                if (checkUser != null)
                {
                    ViewBag.SError = "Girmiş olduğunuz kullanıcı adı sisteme mevcuttur";
                    ViewBag.Error = "Girmiş olduğunuz kullanıcı adı sisteme mevcuttur";
                    return View(users);
                }
                users.Password = Hash256.Hash(users.Password);
                db.Users.Add(users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(users);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Users.Find(id);
            users.Password = "";
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string oldPassword,[Bind(Include = "Id,FirstLastName,Username,Password,Admin")] Users users)
        {
            var getAllUsers = db.Users.ToList();
            var checkUser = getAllUsers.FirstOrDefault(x => x.Username == users.Username && x.Id != users.Id);
            if (checkUser != null)
            {
                ViewBag.Error = "Girmiş olduğunuz kullanıcı adı sisteme mevcuttur";
                return View(users);
            }

            var getUser = db.Users.Find(users.Id);
            if(getUser.Password!= Hash256.Hash(oldPassword))
            {
                ViewBag.ErrorOldPassword = "Girmiş olduğunuz eski şifreniz yanlıştır.";
                return View(users);
            }
            
            if (ModelState.IsValid)
            {
                getUser.Password = Hash256.Hash(users.Password);
                getUser.Username = users.Username;
                getUser.Admin = users.Admin;
                getUser.FirstLastName = users.FirstLastName;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(users);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {

            if(id == (int)Session["Id"])
                return RedirectToAction("Index", "Home");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }


        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Users users = db.Users.Find(id);
            db.Users.Remove(users);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                if (ex.Message == "An error occurred while updating the entries. See the inner exception for details.")
                {
                    ViewBag.Error = "Silmek istediğiniz şubeye kayıtlı ürün/ürünler bulunmaktadır. Silme işlemi gerçekleştirilemedi. Lütfen ürün/ürünler üzerinde şube değişikliği yapınız.";
                    ViewBag.SError = "Silmek istediğiniz şubeye kayıtlı ürün/ürünler bulunmaktadır. Silme işlemi gerçekleştirilemedi. Lütfen ürün/ürünler üzerinde şube değişikliği yapınız.";
                    return View("Delete", users);
                }

            }
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
