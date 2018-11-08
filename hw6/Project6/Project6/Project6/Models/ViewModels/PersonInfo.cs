using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project6.Models.ViewModels
{
    public class PersonInfo
    {
        [DisplayName("Full Name")]
        public string FullName { get; set; }

        [DisplayName("Preferred Name")]
        public string PreferredName { get; set; }

        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [DisplayName("Fax Number")]
        public string FaxNumber { get; set; }

        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }

        [DisplayName("Start Date")]
        public DateTime ValidFrom { get; set; }

        [DisplayName("Photo")]
        public byte[] Photo { get; set; }
    }
}