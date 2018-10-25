using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project5.Models
{
    public class Tenants
    {
        public int ID { get; set; }

        [Required, StringLength(20)]
        public string FirstName { get; set; }

        [Required, StringLength(25)]
        public string LastName { get; set; }

        [Required, StringLength(10)]
        public string PhoneNumber { get; set; }

        [Required, StringLength(30)]
        public string ApartmentName { get; set; }

        [Required]
        public int ApartmentNumber { get; set; }

        [Required, StringLength(500)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public bool IsHome { get; set; }
    }
}