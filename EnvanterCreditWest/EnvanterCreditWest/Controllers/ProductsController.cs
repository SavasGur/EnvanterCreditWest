using EnvanterCreditWest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnvanterCreditWest.Controllers
{
    public class ProductsController : Controller
    {
        public ActionResult test()
        {
            //db.Prosuıct.ToList();
            var x = new List<Products>
            {
                new Products{Id=1,Latitude="1",Longitude="1",Name="Deneme1" },
                new Products{Id=3,Latitude="1",Longitude="1",Name="Deneme2" },
                new Products{Id=2,Latitude="1",Longitude="1",Name="Deneme3" },
            };
            return View("Index",x);
        }
    }
}