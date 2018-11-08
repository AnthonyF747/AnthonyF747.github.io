using Project6.DAL;
using Project6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project6.Controllers
{
    public class HomeController : Controller
    {
        private readonly WWIDbContext _wwiDb = new WWIDbContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        
    }
}