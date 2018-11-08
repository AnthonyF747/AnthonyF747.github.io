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
        private WWINameRepository repository = new WWINameRepository();

        [HttpGet]
        public ActionResult Index()
        {

            return View(repository.People);
        }

        
    }
}