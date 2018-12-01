/// Items controller will control methods associated 
/// with items in the database. Some methods may not 
/// be implemented but remain in case they are needed
/// at a later time. Methods were scaffolded.
/// 
/// Author: Anthony Franco
/// Date: November 30, 2018
/// Class: CS460 Software Engineering
/// Assignment: Homework 8
/// Description: Creating a web site with buyers, sellers,
/// items, and bids. The site has a database and will be
/// deployed to Azure.

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AuctionHouse.Models;
using AuctionHouse.Models.ModelViews;

namespace AuctionHouse.Controllers
{
    public class ItemsController : Controller
    {
        private readonly AuctionDbContext db = new AuctionDbContext();

        // GET: Items
        public ActionResult Index()
        {
            var items = db.Items.Include(i => i.Seller);
            return View(items.ToList());
        }

        // GET: Items/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Item item = db.Items.Find(id);

            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        /// <summary>
        /// BidDetails is for the live bid page that displays all
        /// bids as they occur. **This doesn't not fully work**
        /// </summary>
        /// <param name="id">The id of the item</param>
        /// <returns name="Json">JSON results of the search</returns>
        [HttpGet]
        public JsonResult BidDetails(int? id)                          // the item id to be viewed
        {
               var data = db.Bids.Where(i => i.Item.ItemID == id)      // store the matching item
                                                                       // select the buyer
                                 .Select(i => new { Buyer = i.Buyer.BuyerFullName, i.BidAmount })  
                                 .OrderByDescending(p => p.BidAmount)  // order bid amounts by descending order
                                 .ToList();                            // list the results
            return Json(data, JsonRequestBehavior.AllowGet);           // display the results of the search
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            ViewBag.SellerID = new SelectList(db.Sellers, "SellerID", "SellerFullName");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemID,ItemName,ItemDescription,SellerID")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SellerID = new SelectList(db.Sellers, "SellerID", "SellerFullName", item.SellerID);
            return View(item);
        }

        // GET: Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.SellerID = new SelectList(db.Sellers, "SellerID", "SellerFullName", item.SellerID);
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemID,ItemName,ItemDescription,SellerID")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SellerID = new SelectList(db.Sellers, "SellerID", "SellerFullName", item.SellerID);
            return View(item);
        }

        // GET: Items/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
