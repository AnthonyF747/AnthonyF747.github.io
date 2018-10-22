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

        /// <summary>
        /// The controller for the mile to metric converter. Takes numeric input from the user and will return the equivilent
        /// distance in millimeters, centimeters, meters, and kilometers depending on the selected radio button.
        /// </summary>
        /// <returns>The Converter view with converted distance</returns>
        public ActionResult Converter()
        {
            var mile = Request.QueryString["MilesToConvert"];  // mile is used to hold the miles entered by the user in the textbox
            string radbtn = Request.QueryString["Units"];      // radbtn is to hold the radio button selected from the Converter view
            double miles = 0;                                  // miles will hold the converted string to a double
            double sum = 0;                                    // sum will hold the end value of the conversion
            Regex regex = new Regex(@"\d+(\.\d)?|\.\d+");      // Regex pattern for matching numeric data input with decimals

            if (mile != null)                                  // Check if mile is not null and has something in it
            {
                if (regex.IsMatch(mile))                       // mile is compared with regex pattern
                {
                    miles = Double.Parse(mile);                // if it is, parse mile and store the result in miles
                }
                else                                           // else,
                {
                    ViewBag.RegexMessage = "Please enter a number";  // Send a message to the user to enter a number
                }


                switch (radbtn)                                // if the number was parsed to a double, it hits the switch
                {
                    case "millimeters":                        // if the radio button is millimeters, 
                        sum = miles * 1609344;                 // multiply miles to 1609344
                        break;                                 // break
                    case "centimeters":                        // if the radio button is centimeters,
                        sum = miles * 160934.4;                // multiply miles to 160934.4
                        break;                                 // break
                    case "meters":                             // if the radio button is meters,
                        sum = miles * 1609.344;                // multiply miles to 1609.344
                        break;                                 // break
                    case "kilometers":                         // if the radio button is kilometers,
                        sum = miles * 1.60934;                 // multiply miles to 1.60934
                        break;                                 // break
                }
                // send a message back to the client with the original miles entered,
                // the result after the conversion, and what conversion took place
                ViewBag.Message = miles + " miles is equal to " + sum + " " + radbtn;
            }
            return View();                                     // return the Converter view
        }
    }
}