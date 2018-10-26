using Project5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project5.Controllers
{
    public class HomeController : Controller
    { 
        // GET
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ViewResult TenantView()
        {
            return View();
        }

        [HttpPost]
        public ViewResult TenantView(Tenants tenant)
        {
            if(ModelState.IsValid)
            {
                return View("Thanks", tenant);
            }
            else
            {
                // validation issue
                return View();
            }
        }

        public ViewResult LookupView()
        {
            return View();
        }


    }
}