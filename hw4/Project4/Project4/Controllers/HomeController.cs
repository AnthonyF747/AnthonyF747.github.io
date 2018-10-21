using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Project4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Converter()
        {
            var mile = Request.QueryString["MilesToConvert"];
            string radbtn = Request.QueryString["Units"];
            double miles = 0;
            double sum = 0;
            Regex regex = new Regex(@"^\d+(\.\d*)?|\.\d+");

            if (mile != null)
            {
                if (regex.IsMatch(mile))
                {
                    miles = Double.Parse(mile);
                }
                else
                {
                    ViewBag.RegexMessage = "Please enter a number";
                }


                switch (radbtn)
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
                ViewBag.Message = miles + " miles is equal to " + sum + " " + radbtn;
            }
            /*else
            {
                ViewBag.Message = "Nothing is in here";
            }*/
            return View();
        }
    }
}