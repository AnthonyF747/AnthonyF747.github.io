using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Project4.Controllers
{
    public class ColorController : Controller
    {
        // GET: Color
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ColorChooser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ColorChooser(string x, string y)
        {
            Color colorOne;
            Color colorTwo;
            Regex regex = new Regex("^#[A-Fa-f0-9]{6} | [A-Fa-f0-9]{3}");

            if(regex.IsMatch(x) && regex.IsMatch(y))
            {
                colorOne = ColorTranslator.FromHtml(x);
                colorTwo = ColorTranslator.FromHtml(y);

                Debug.WriteLine(colorOne.ToString());
                Debug.WriteLine(colorTwo.ToString());

                ViewBag.NewColor = "it matches";
            }
            else
            {
                ViewBag.RegexFail = "The value entered was not is proper form. Try #AABBCC pattern";
            }

            
            //Color newColor = colorOne + colorTwo;

            return View();
        }
    }
}