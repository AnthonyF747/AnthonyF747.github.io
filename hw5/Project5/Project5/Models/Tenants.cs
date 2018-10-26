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

        [Required(ErrorMessage = "Please enter your first name")]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        [StringLength(25)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        [StringLength(10), Phone]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter your apartment name")]
        [StringLength(30)]
        public string ApartmentName { get; set; }

        [Required(ErrorMessage = "Please enter your unit number")]
        public int ApartmentNumber { get; set; }

        [Required(ErrorMessage = "Please enter a short description of the problem")]
        [StringLength(500)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public bool IsHome { get; set; }
    }
}