using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project6.Controllers
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
