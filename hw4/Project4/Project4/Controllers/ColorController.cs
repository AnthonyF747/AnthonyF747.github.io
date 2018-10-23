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
        public ActionResult ColorChooser(FormCollection frm)
        {
            string firstColor = frm["firstColor"].ToString();
            string secondColor = frm["secondColor"].ToString();
            Regex regex = new Regex("^#[A-Fa-f0-9]{6, 8} | [A-Fa-f0-9]{3}");

            Debug.WriteLine(firstColor);
            Debug.WriteLine(secondColor);

            if(regex.IsMatch(firstColor) && regex.IsMatch(secondColor))
            {
                Color colorOne = ColorTranslator.FromHtml(firstColor);
                Color colorTwo = ColorTranslator.FromHtml(secondColor);

                byte r1 = colorOne.R;
                byte g1 = colorOne.G;
                byte b1 = colorOne.B;

                byte r2 = colorTwo.R;
                byte g2 = colorTwo.G;
                byte b2 = colorTwo.B;

                //Color newColor = (r1 + r2)(g1 + g2)(b1 + b2);

                ViewBag.NewColor = "it matches";
            }
            else
            {
                ViewBag.RegexFail = "The value entered was not is proper form. Try #AABBCC pattern";
            }
            return View();
        }
    }
}