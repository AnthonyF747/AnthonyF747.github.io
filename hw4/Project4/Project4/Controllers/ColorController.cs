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
            return View();
        }

        [HttpPost]
        public ActionResult ColorChooser(string firstcolor, string secondcolor)
        {
            if(firstcolor == null || secondcolor == null)
            {
                @ViewBag.Message = "Nothing is in here";
            }
            else
            {
                Debug.WriteLine(firstcolor);
                Debug.WriteLine(secondcolor);
                @ViewBag.Message = "something is here" + firstcolor + " " + secondcolor;
            }
            if (@ViewBag.Message != null)
            {
                @ViewBag.Message = "something is here" + firstcolor + " " + secondcolor;
            }
            else
            {
                @ViewBag.Message = "There's nothing here";
            }
            return View();
        }
    }
}