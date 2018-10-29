using Project5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Project5.DAL;
using System.Diagnostics;
using Project5.Models;

namespace Project5.Controllers
{
    public class HomeController : Controller
    {
        public TenantContext tc = new TenantContext();

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
        public ViewResult TenantView(Tenant tenant)
        {
            if(ModelState.IsValid)
            {
                tc.Tenants.Add(tenant);
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
            foreach(var t in tc.Tenants )
            {
                Debug.WriteLine(t);
            }
            return View();
        }

        // Get: Tenants/Create
        public ActionResult Create()
        {
            return View();
        }

        // Post: Tenants/Create
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,PhoneNumber,ApartmentName,ApartmentNumber,FixDescription")]Tenant tenant)
        {
            if(ModelState.IsValid)
            {
                tc.Tenants.Add(tenant);
                tc.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tenant);
        }
    }
}