﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WWImporters.Models;

namespace WWImporters.Controllers
{
    public class HomeController : Controller
    {
        private WWIDbContext _wwiDb = new WWIDbContext();

        public ActionResult Index(string query)
        {
            if (query != null || query != "")
            {
                return View(_wwiDb.People.Where(p => p.FullName.ToLower().Contains(query.ToLower())).ToList());
            }
            return View();
        }
    }
}