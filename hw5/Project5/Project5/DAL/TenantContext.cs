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
        public TenantContext() : base("name=FitItDb")
        {
           
        }
        public virtual DbSet<Tenant> Tenants { get; set; }
    }
}