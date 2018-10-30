using Project5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Project5.DAL;
using System.Diagnostics;
using System.Net;

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
            return View(tc.Tenants.ToList());
        }

        // Get: Tenants/Create
        public ActionResult Create()
        {
            return View();
        }

        // Post: Tenants/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // Get: Tenants/Delete
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
            Tenant tenant = tc.Tenants.Find(id);
            if(tenant == null)
            {
                return HttpNotFound();
            }
            return View(tenant);
        }

        // Post: Tenant/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tenant tenant = tc.Tenants.Find(id);
            tc.Tenants.Remove(tenant);
            tc.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                tc.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}