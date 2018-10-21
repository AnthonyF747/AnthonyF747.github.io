using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project4.Controllers
{
    public class ColorController : Controller
    {
        // GET: Color
        public ActionResult ColorChooser()
        {
            ViewBag.Message = "Where am I";
            return View();
        }

        [HttpPost]
        public ActionResult ColorChooser(string colorOne, string colorTwo)
        {
            if(colorOne == null || colorTwo == null)
            {
                ViewBag.Message = "Nothing is in here";
            }
            else
            {
                //colorOne = Int32.Parse(firstcolor.Text, System.Globalization.NumberStyles.HexNumber);
                //colorTwo = Int32.Parse(secondcolor.Text, System.Globalization.NumberStyles.HexNumber);
                Debug.WriteLine(colorOne.GetType());
                Debug.WriteLine(colorTwo.GetType());
            }
            if (ViewBag.Message != null)
            {
                ViewBag.Message = "something is here" + colorOne + " " + colorTwo;
            }
            else
            {
                ViewBag.Message = "There's nothing here";
            }
            return View();
        }
    }
}