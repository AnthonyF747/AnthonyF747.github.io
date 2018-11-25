using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuctionHouse.Controllers
{
    public class HomeController : Controller
    {
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
        public ActionResult CheckName(string phoneNumber)
        {
            Seller seller;
            foreach (var n in _auctionDb.Sellers)
            {
                if (phoneNumber == n.PhoneNumber)
                {
                    seller = _auctionDb.Sellers.Find(n.SellerID);
                    ViewBag.SellerId = seller;
                    return Redirect("/Items/Create");
                }
            }
            return Redirect("/Sellers/Create");
        }
    }
}