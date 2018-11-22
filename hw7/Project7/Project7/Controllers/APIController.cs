﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project7.Controllers
{
    public class APIController : Controller
    {
        private readonly string _myGiphyKey = System.Web.Configuration.WebConfigurationManager.AppSettings["AdminGiphy"];
        private readonly string _myGiphyURL = System.Web.Configuration.WebConfigurationManager.AppSettings["GiphyURL"];

        // GET: API
        public ActionResult Index()
        {
            return View();
        }
    }
}