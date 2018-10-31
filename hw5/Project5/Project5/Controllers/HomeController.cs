/// Controller page for Project 6
/// 
/// Author: Anthony Franco
/// Date: October 30, 2018
/// Homework Assignment: Project5
/// Description: Use ASP.NET MVC 5 to gather data from a 
///              form and enter it into a database.
using Project5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Project5.DAL;
using System.Diagnostics;
using System.Net;

namespace Project5.Controllers
{
    public class HomeController : Controller
    {
        public TenantContext tc = new TenantContext();   // DbContext to get/send data to the database

        // GET
        public ActionResult Index()
        {
            return View();
        }

        // Not Used
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        // Not Used
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        /// View for the form page.
        /// </summary>
        /// <returns>Form View</returns>
        [HttpGet]
        public ViewResult TenantView()
        {
            return View();
        }

        /// <summary>
        /// Posts data from the form into the database,
        /// redirects user to "thank you" page
        /// </summary>
        /// <param name="tenant">All the items that make up a tenant object</param>
        /// <returns>Tenant name and message</returns>
        // Post: Tenants/Create
        [HttpPost]
        public ViewResult TenantView([Bind(Include = "ID,FirstName,LastName,PhoneNumber,ApartmentName,ApartmentNumber,FixDescription")]Tenant tenant)
        {
            if(ModelState.IsValid)               // Check to see if the model is valid
            {
                tc.Tenants.Add(tenant);          // If model is valid, add the tenant form information into the database
                tc.SaveChanges();                // Save the changes to the database
                return View("Thanks", tenant);   // Return the tenant's name on a "thank you" page
            }
            else
            {
                return View(tenant);             // If model is invalid, validation issue and just return tenant information
            }
        }

        /// <summary>
        /// LookupView was used to generate list display of model items
        /// Used as a debugger 
        /// </summary>
        /// <returns>List view of model items</returns>
        public ViewResult LookupView()
        {
            foreach (var t in tc.Tenants)        // Iterate through the objects in the database
            {
                Debug.WriteLine(t);              // Write to 'console'-debug line
            }
            return View(tc.Tenants.ToList());    // Return a list of tenant objects
        }

        /// <summary>
        /// Get the id number from the database item to be deleted 
        /// </summary>
        /// <param name="id">The tenant's id number</param>
        /// <returns>View of tenant objects</returns>
        /// <exception cref="HttpStatusCodeResult">HttpStatusCode.BadRequest</exception>
        // Get: Tenants/Delete
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);   // If no id, throw 400 BadRequest Error
            }
           
            Tenant tenant = tc.Tenants.Find(id);               // Store the tenant by id 
            if(tenant == null)                                 // If there is no tenant, 
            {
                return HttpNotFound();                         // throw 400 HttpNotFound error
            }
            return View(tenant);                               // Return tenant objects
        }

        /// <summary>
        /// Takes the tenant id, looks in database, removes tenant object 
        /// from the database and saves changes 
        /// </summary>
        /// <param name="id">The tenant's id number</param>
        /// <returns>Redirect to home page</returns>
        // Post: Tenant/Delete
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Tenant tenant = tc.Tenants.Find(id);               // Store the tenant by id 
            tc.Tenants.Remove(tenant);                         // Remove the tenant from the database
            tc.SaveChanges();                                  // Save the changes to the database
            return RedirectToAction("Index");                  // Send user back to the home page
        }

        /// <summary>
        /// Trash collection
        /// </summary>
        /// <param name="disposing">True or false</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing)                                      // If true, 
            {
                tc.Dispose();                                  // throw trash away
            }
            base.Dispose(disposing);                           // Base item
        }
    }
}