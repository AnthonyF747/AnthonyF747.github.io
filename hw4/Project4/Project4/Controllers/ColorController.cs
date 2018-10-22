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
            Regex regex = new Regex("^#[A-Fa-f0-9]{6} | [A-Fa-f0-9]{3}");

            if(regex.IsMatch(firstColor) && regex.IsMatch(secondColor))
            {
                Color colorOne = ColorTranslator.FromHtml(firstColor);
                Color colorTwo = ColorTranslator.FromHtml(secondColor);

               // Color newColor = colorOne + colorTwo;

                ViewBag.NewColor = "it matches";
            }
            else
            {
                ViewBag.RegexFail = "The value entered was not is proper form. Try #AABBCC pattern";
            }
            Debug.WriteLine(firstColor);
            Debug.WriteLine(secondColor);

            return View();
        }
    }
}