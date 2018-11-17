/// HomeController for Homework 6
/// This controller contains a private database object that
/// will be used to collect information from the remote database.
/// 
/// Author: Anthony Franco
/// Date: November 16, 2018
/// Class: CS460 Software Engineering I
/// Assignment: Homework 6
/// Description: Learning to retrieve information from an 
///              existing database using LINQ and Entity
///              Framework.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WWImporters.Models;
using WWImporters.Models.ViewModels;

namespace WWImporters.Controllers
{
    public class HomeController : Controller
    {
        private WWIDbContext _wwiDb = new WWIDbContext();  // database object

        /// <summary>
        /// Gather input from the user via textbox to search for a 
        /// name in the database.
        /// </summary>
        /// <param name="query">The name to search for; can be partial name</param>
        /// <returns return="listofitems">A list of items that match the given input</returns>
        public ActionResult Index(string query)            // query is input from the textbox
        {
            if (query == null || query == "")              // check if the query is null or empty;
            {
                ViewBag.show = false;                      // if true, return false
                return View();                             // return original page
            }
            else                                           // else,
            {
                ViewBag.show = true;                       // return true
            }
                                                           // return a list of names containing input "query" from textbox
            return View(_wwiDb.People.Where(p => p.FullName.ToLower().Contains(query.ToLower())).ToList());
        }

        /// <summary>
        /// Used to retrieve specific information from the database
        /// using LINQ queries. Once the information needed is found,
        /// send it to the "PersonInfo" view.
        /// </summary>
        /// <param name="id">The id of the person being searched</param>
        /// <returns return="PersonInfo">The view containing specific client information</returns>
        public ActionResult PersonInfo(int? id)              // the id of the person being searched for
        {
            GroupInfoView infoView = new GroupInfoView       // getters-setters for person, customer, and invoice objects
            {
                ThisPerson = _wwiDb.People.Find(id)          // ThisPerson will equal the person in the database with the matching id
            };

            if (id == null)                                   // if the id is null,
            {
                                                             // return badrequest error
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Person thisPerson = _wwiDb.People.Find(id);      // a person object matching person selected from the textbox list

            if(thisPerson == null)                           // if the person returns null,
            {
                return HttpNotFound();                       // throw not found error
            }

            ViewBag.SetFlag = false;                         // flag for primary contact person

            if (infoView.ThisPerson.Customers2.Count() > 0)  // check if the customer2 column is greater than 0, which means they 
            {
                ViewBag.SetFlag = true;                      // if greater than 0, set flag to true

                                                             // check the person's customer2 column and get the first customer id
                                                             // and put it in an int variable 
                int custID = infoView.ThisPerson.Customers2.FirstOrDefault().CustomerID;

                                                             // set a customer view with the results of the query
                                                             // this will be sent to the PersonInfo view
                infoView.ThisCustomer = _wwiDb.Customers.Find(custID);

                                                             // set a viewbag to hold gross sales value
                ViewBag.Sales = infoView.ThisCustomer.Orders.SelectMany(s => s.Invoices)
                                                            .SelectMany(c => c.InvoiceLines)
                                                            .Sum(t => t.ExtendedPrice);

                                                            // set a viewbag to hold gross profit value
                ViewBag.Profit = infoView.ThisPerson.Orders.SelectMany(s => s.Invoices)
                                                           .SelectMany(c => c.InvoiceLines)
                                                           .Sum(t => t.LineProfit);

                                                            // create a view to sent to PersonInfo
                infoView.ThisInvoice = infoView.ThisCustomer.Orders.SelectMany(i => i.Invoices)
                                                                   .SelectMany(l => l.InvoiceLines)
                                                                   .OrderByDescending(p => p.LineProfit)
                                                                   .Take(10)
                                                                   .ToList();
            }

            return View("PersonInfo", infoView);             // return PersonInfo view 
        }
    }
}