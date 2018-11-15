using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WWImporters.Models.ViewModels
{
    public class GroupInfoView
    {
        public Person ThisPerson { get; set; }
        public Customer ThisCustomer { get; set; }
        public List<InvoiceLine> ThisInvoice { get; set; }
    }
}