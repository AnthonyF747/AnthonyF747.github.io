using AuctionHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuctionHouse.Controllers
{
    public class HomeController : Controller
    {
        AuctionDbContext _auctionDb = new AuctionDbContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CheckName()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckName(string fullName)
        {
            Seller seller;
            foreach (var n in _auctionDb.Sellers)
            {
                if (fullName == n.SellerFullName)
                {
                    seller = _auctionDb.Sellers.Find(n.SellerFullName);
                    ViewBag.SellerId = seller;
                    return Redirect("/Items/Create");
                }
            }
            return Redirect("/Sellers/Create");
        }
    }
}