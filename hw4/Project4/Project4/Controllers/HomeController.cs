using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project4.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Converter()
        {
            double miles = double.Parse(Request.QueryString["MilesToConvert"]);
            var radbtn = Request.QueryString["Units"];
            double sum = 0;

           /* switch(radbtn)
            {
                case "millimeters":
                    sum = miles * 1609344;
                    break;
                case "centimeters":
                    sum = miles * 160934.4;
                    break;
                case "meters":
                    sum = miles * 1609.344;
                    break;
                case "kilometers":
                    sum = miles * 1.60934;
                    break;
                    
            }
            ViewBag.Message = miles + " miles is equal to " + sum + " " + radbtn;*/
            return View();
        }

        [HttpPost]
        public ActionResult Converter(int miles, string type)
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
    }
}