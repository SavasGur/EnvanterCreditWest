﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnvanterCreditWest.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NotFound()
        {
            return View();
        }
        public ActionResult Interval()
        {
            return View();
        }
    }
}