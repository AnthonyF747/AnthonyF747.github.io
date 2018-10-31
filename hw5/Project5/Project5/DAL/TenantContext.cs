/// Used for the connection to the database
/// 
/// Author: Anthony Franco
/// Date: October 30, 2018
/// Homework Assignment: Project5
/// Description: Create a DbContext object that will 
///              handle get/set to the database
using Project5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project5.DAL
{
    public class TenantContext : DbContext
    {
        public TenantContext() : base("name=FitItDb")         // Set the base to the database
        {
           
        }
        public virtual DbSet<Tenant> Tenants { get; set; }    // The virtual DbSet to get/set database objects
    }
}