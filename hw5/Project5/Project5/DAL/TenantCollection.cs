/// DAL collection to hold test objects to return in list form
/// 
/// Author: Anthony Franco
/// Date: October 30, 2018
/// Homework Assignment: Project5
/// Description: Used to create a mock list of tenant objects
///              to return a list of those objects
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project5.Models;

namespace Project5.DAL
{
    public class TenantCollection
    {
        public List<Tenant> Tenants;               // A list of tenant object

        public TenantCollection()
        {
            // Create new tenants
            Tenants = new List<Tenant>
            {
                new Tenant {FirstName="Juliet", LastName="Lewis", PhoneNumber="5555555555", ApartmentName="Tall Pine Apts", ApartmentNumber=20, FixDescription="Carpet is frayed and ripping apart", IsHome=true },
                new Tenant {FirstName="Robin", LastName="Williams", PhoneNumber="5555555556", ApartmentName="Highland Manor", ApartmentNumber=409, FixDescription="Paint is chipping", IsHome=false },
                new Tenant {FirstName="Art", LastName="Carney", PhoneNumber="5555555557", ApartmentName="Clock Tower Apts", ApartmentNumber=46, FixDescription="Leaky roof", IsHome=true },
                new Tenant {FirstName="Lindsay", LastName="Wagner", PhoneNumber="5555555558", ApartmentName="Rushgore Manor", ApartmentNumber=284, FixDescription="Stove doesn't work", IsHome=true },
                new Tenant {FirstName="Jackie", LastName="Gleason", PhoneNumber="5555555559", ApartmentName="Singing Oaks Apts", ApartmentNumber=123, FixDescription="Heater isn't working", IsHome=false },
            };
        }

        /// <summary>
        /// Add new tenant objects to the list
        /// </summary>
        /// <param name="tenant"></param>
        public void AddTenant(Tenant tenant)
        {
            Tenants.Add(tenant);
        }
    }
}