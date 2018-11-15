using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WWImporters.Models.ViewModels
{
    public class PersonInfoView
    {
        [DisplayName("Person ID:")]
        public int PersonID { get; set; }
        [DisplayName("Full Name:")]
        public string FullName { get; set; }
        [DisplayName("Preferred Name:")]
        public string PreferredName { get; set; }
        [DisplayName("Phone Number:")]
        public string PhoneNumber { get; set; }
        [DisplayName("Fax Number:")]
        public string FaxNumber { get; set; }
        [DisplayName("Email Address:")]
        public string EmailAddress { get; set; }
        [DisplayName("Valid From:")]
        public DateTime ValidFrom { get; set; }
        [DisplayName("Photo:")]
        public byte[] Photo { get; set; }
        public Person ThisPerson { get; set; }
        public Customer ThisCustomer { get; set; }
        public List<InvoiceLine> ThisInvoice { get; set; }
    }
}