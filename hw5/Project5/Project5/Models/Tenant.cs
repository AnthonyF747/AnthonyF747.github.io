/// Model for tenant form objects. All the getters/setters
/// 
/// Author: Anthony Franco
/// Date: October 30, 2018
/// Homework Assignment: Project5
/// Description: Getters and setters for the tenant form objects
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project5.Models
{
    public class Tenant
    {

        /// <summary>
        /// The tenant request's id number auto generated
        /// in the database
        /// </summary>
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// The tenant object's first name
        /// </summary>
        [Required(ErrorMessage = "Please enter your first name")]
        [StringLength(20)]
        [Display(Name ="First Name:")]
        public string FirstName { get; set; }

        /// <summary>
        /// The tenant object's last name
        /// </summary>
        [Required(ErrorMessage = "Please enter your last name")]
        [StringLength(25)]
        [Display(Name ="Last Name:")]
        public string LastName { get; set; }

        /// <summary>
        /// The tenant object's phone number
        /// </summary>
        [Required(ErrorMessage = "Please enter your phone number")]
        [StringLength(10), Phone]
        [Display(Name ="Phone Number:")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The tenant object's apartment name
        /// </summary>
        [Required(ErrorMessage = "Please enter your apartment name")]
        [StringLength(30)]
        [Display(Name ="Apartment Name:")]
        public string ApartmentName { get; set; }

        /// <summary>
        /// The tenant object's apartment number
        /// </summary>
        [Required(ErrorMessage = "Please enter your unit number")]
        [Display(Name ="Apartment Number:")]
        public int ApartmentNumber { get; set; }

        /// <summary>
        /// A description of the repair/maintenance required by the tenant
        /// </summary>
        [Required(ErrorMessage = "Please enter a short description of the problem")]
        [StringLength(500)]
        [DataType(DataType.MultilineText)]
        [Display(Name ="Description:")]
        public string FixDescription { get; set; }

        /// <summary>
        /// A check box to let the management know if you will be home or not
        /// </summary>
        public bool IsHome { get; set; }

        /// <summary>
        /// Override ToString to return tenant object elements
        /// </summary>
        /// <returns>The element of tenant objects</returns>
        public override string ToString()
        {
        return $"{base.ToString()}: {FirstName} {LastName} {PhoneNumber} {ApartmentName} {ApartmentNumber} {FixDescription} {IsHome}";
        }
    }
}