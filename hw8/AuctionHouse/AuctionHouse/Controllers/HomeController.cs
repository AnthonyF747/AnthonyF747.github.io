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
        AuctionDbContext _auctionDb = new AuctionDbContext();

        public ActionResult Index()
        {
            return View(_auctionDb.Bids.OrderByDescending(t => t.BidTimeStamp).Take(10).ToList());
        }

        [HttpGet]
        public ActionResult CheckName()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckName(string phoneNumber)
        {
            foreach (var n in _auctionDb.Sellers)
            {
                if (phoneNumber == n.SellerPhoneNumber)
                {
                    return Redirect("/Items/Create");
                }
            }
            return Redirect("/Sellers/Create");
        }

        [HttpGet]
        public ActionResult CheckBuyer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckBuyer(string phoneNumber)
        {
            foreach (var n in _auctionDb.Buyers)
            {
                if (phoneNumber == n.BuyerPhoneNumber)
                {
                    return Redirect("/Bids/Create");
                }
            }
            return Redirect("/Buyers/Create");
        }
    }
}

