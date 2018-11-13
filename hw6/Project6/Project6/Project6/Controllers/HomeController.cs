using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project6.Models;

namespace Project6.Controllers
{
    public class HomeController : Controller
    {
        private WWIDbContext _wwiDb = new WWIDbContext();

        public ActionResult Index(string query)
        {
            if(query != null)
            {
                ViewBag.show = true;
                return View(_wwiDb.People.Where(p => p.FullName.ToLower().Contains(query.ToLower())).ToList());
            }
            else
            {
                ViewBag.hide = false;
            }
            return View();
        }

       

    }
}