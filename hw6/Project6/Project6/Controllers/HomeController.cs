using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using. Project6.Models;
using. Project6.DAL;

namespace Project6.Controllers
{
public class NameController : Controller
    {
        private IPersonRepository repository;
        
        public NameController(IPersonRepository personRepository)
        {
            this.repository = personRepository;
        }

        public ViewResult List()
        {
            return View(repository.People);
        }

        public void SetPersonEnum(Person person)
        {
            IEnumerable<Person> people =
                Enum.GetValues(typeof(Person))
                .Cast<Person>();

            IEnumerable<SelectListItem> items =
                from p in people
                select new SelectListItem
                {
                    Selected = p == person,
                };
            ViewBag.NameOfPerson = items;
        }
    }
}
