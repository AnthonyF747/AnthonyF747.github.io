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
        private WWIDbContext wwiDb = new WWIDbContext();

        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<Person> people = wwiDb.People.FirstOrDefault().GetType()
            return View();
        }

        
    }
}