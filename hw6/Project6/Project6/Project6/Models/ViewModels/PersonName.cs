using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Project6.Models.ViewModels
{
    public class PersonName
    {
        [DisplayName("Enter a name")]
        public string NameOfPerson { get; set; }

        public IEnumerable<Person> PersonSearch { get; set; } 
    }
}