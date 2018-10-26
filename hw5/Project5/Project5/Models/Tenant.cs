using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project5.Models
{
    public class Tenant
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter your first name")]
        [StringLength(20)]
        [Display(Name ="First Name:")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        [StringLength(25)]
        [Display(Name ="Last Name:")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        [StringLength(10), Phone]
        [Display(Name ="Phone Number:")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter your apartment name")]
        [StringLength(30)]
        [Display(Name ="Apartment Name:")]
        public string ApartmentName { get; set; }

        [Required(ErrorMessage = "Please enter your unit number")]
        [Display(Name ="Apartment Number:")]
        public int ApartmentNumber { get; set; }

        [Required(ErrorMessage = "Please enter a short description of the problem")]
        [StringLength(500)]
        [DataType(DataType.MultilineText)]
        [Display(Name ="Description:")]
        public string Description { get; set; }

        public bool IsHome { get; set; }
    }

    /*public override string ToString()
    {
        return $"{base.ToString()} : {FirstName} {LastName} {PhoneNumber} {ApartmentName} {ApartmentNumber} {Description} {IsHome}";
    }*/
}