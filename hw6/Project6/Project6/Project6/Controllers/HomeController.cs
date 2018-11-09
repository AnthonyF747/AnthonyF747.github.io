using Project6.DAL;
using Project6.Models;
using Project6.Models.ViewModels;
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

        
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(PersonName personName)
        {
            personName.PersonSearch = _wwiDb.People
                .Where(p => p.FullName.Contains(personName.NameOfPerson))
                .Select(p => new PersonID
                {
                    IdOfPerson = p.PersonID,
                    InfoOfPerson = p.FullName
                }).ToList();

            _wwiDb.Dispose();

            return View(personName);
        }

        
    }
}