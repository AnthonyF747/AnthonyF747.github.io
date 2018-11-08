using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project6.Models.ViewModels
{
    public class PersonName
    {
        public string NameOfPerson { get; set; }

        public IEnumerable<PersonID> PersonSearch { get; set; } 
    }
}