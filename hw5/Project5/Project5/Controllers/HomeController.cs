﻿using Project5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Project5.DAL;
using System.Diagnostics;

namespace Project5.Controllers
{
    public class HomeController : Controller
    {
        public TenantCollection tc = new TenantCollection();

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
    }
}