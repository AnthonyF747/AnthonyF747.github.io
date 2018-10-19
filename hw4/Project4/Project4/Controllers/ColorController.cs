using System;
using System.Collections.Generic;
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
    }
}