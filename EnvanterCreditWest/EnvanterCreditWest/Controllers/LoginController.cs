using EnvanterCreditWest.Models;
using EnvanterCreditWest.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnvanterCreditWest.Controllers
{
    public class LoginController : Controller
    {
        EnvanterCreditWestContext db = new EnvanterCreditWestContext();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Auth([Bind(Include = "Username,Password")] Users user)
        {

            if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
            {
                ViewBag.Error = "Lütfen boşukları doldurunuz.";
                return View("Index", user);
            }

            var getUser = db.Users.FirstOrDefault(x => x.Username == user.Username);
            if (getUser != null)
            {
                if (getUser.Password == Hash256.Hash(user.Password))
                {
                    Session["Auth"] = 1;
                    Session["Role"] = getUser.Admin;
                    Session["Id"] = getUser.Id;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Error = "Girmiş olduğunuz şifre yanlıştır.";
                }
            }
            else
                ViewBag.Error = "Kullanıcı mevcut değildir.";

            return View("Index");
        }
        public ActionResult Logout()
        {
            Session["Auth"] = 0;
            return RedirectToAction("Index","Login");
        }
    }
}