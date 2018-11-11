using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project6.Models.ModelView1
{
    public class PersonNameModelView
    {
        public PersonNameModelView()
            {
                this.PersonIDModelViews = new List<PersonIDModelView>();
            }
        [Display(Name="Enter a name: ")]
        public string NameOfPerson { get; set; }
        public List<PersonIDModelView> PersonIDModelViews { get; set; }
    }
    
}