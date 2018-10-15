using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Converter()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult ColorChooser()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}