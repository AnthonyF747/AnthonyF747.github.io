/// Auction House Home Controller is the main controller for the 
/// landing page and the CheckName/CheckBuyer methods that will 
///  control the registration of sellers/buyers that are not
///  in the database.
///  
/// Author: Anthony Franco
/// Date: November 30, 2018
/// Class: CS460 Software Engineering
/// Assignment: Homework 8
/// Description: Create a website for an auction house type
/// business which has buyers, sellers, items, and bids. The
/// site has a database to hold all the information. After
/// everything is working, the web site will be published to
/// Azure for deployment.

using AuctionHouse.Models;
using AuctionHouse.Models.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AuctionHouse.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Set up the database object to interact with
        /// it to pull/set data as needed.
        /// </summary>
        AuctionDbContext _auctionDb = new AuctionDbContext();

        /// <summary>
        /// Landing page controller 
        /// </summary>
        /// <returns name="List of Bids">Top 10 bids in descending order</returns>
        public ActionResult Index()
        {
            return View(_auctionDb.Bids.OrderByDescending(t => t.BidTimeStamp).Take(10).ToList());
        }

        /// <summary>
        /// Method for displaying the View page
        /// for the checkname method
        /// </summary>
        /// <returns name="View">CheckName view</returns>
        [HttpGet]
        public ActionResult CheckName()
        {
            return View();
        }
        /// <summary>
        /// CheckName is a method that verifies if a seller
        /// is in the database or not by using a phone number 
        /// as the check method.
        /// </summary>
        /// <param name="phoneNumber">The phone number of the seller</param>
        /// <returns name="redirect/item">Redirect to item create page if in database</returns>
        /// <returns name="redirect/seller">Redirect to seller page if not in database</returns>
        [HttpPost]
        public ActionResult CheckName(string phoneNumber)   // the phone number of the seller
        {
            foreach (var n in _auctionDb.Sellers)           // go through the list of sellers in the database
            {
                if (phoneNumber == n.SellerPhoneNumber)     // if the phone number is found,
                {
                    return Redirect("/Items/Create");       // send the seller to the items/create page
                }
            }
            return Redirect("/Sellers/Create");             // if not, redirect to the sellers/create page to register
        }

        /// <summary>
        /// Controller for the CheckBuyer view page
        /// </summary>
        /// <returns name="view page">The view for CheckBuyer</returns>
        [HttpGet]
        public ActionResult CheckBuyer()
        {
            return View();
        }

        /// <summary>
        /// CheckBuyer method is to verify if a buyer is in the database
        /// or not by using the buyer's phone number
        /// </summary>
        /// <param name="phoneNumber">The buyer's phone number</param>
        /// <returns name="Bids/Create">Redirect buyer to bids/create page if in database</returns>
        /// <returns name="Buyers/Create">Redirect buyer to buyers/create page if not in database</returns>
        [HttpPost]
        public ActionResult CheckBuyer(string phoneNumber)   // the buyer's phone number
        {
            foreach (var n in _auctionDb.Buyers)             // run through list of buyers in the database
            {
                if (phoneNumber == n.BuyerPhoneNumber)       // check if the phone number matches number in database
                {
                    return Redirect("/Bids/Create");         // if true, redirect buyer to bids/create page
                }
            }
            return Redirect("/Buyers/Create");               // if not, redirect buyer to buyers/create page to register
        }
    }
}

