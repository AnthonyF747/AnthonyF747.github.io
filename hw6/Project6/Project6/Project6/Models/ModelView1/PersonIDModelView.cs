using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project6.Models.ModelView1
{
    public class PersonIDModelView
    {
        public int IdOfPerson { get; set; }
        public string InfoOfPerson { get; set; }
        public PersonNameModelView PersonNameModelView { get; set; }
    }
}