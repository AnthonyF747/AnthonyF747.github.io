using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WWImporters.Models;
using WWImporters.Models.ViewModels;

namespace WWImporters.Controllers
{
    public class HomeController : Controller
    {
        private WWIDbContext _wwiDb = new WWIDbContext();

        public ActionResult Index(string query)
        {
            if (query == null || query == "")
            {
                ViewBag.show = false;
                return View();
            }
            else
            {
                ViewBag.show = true;
            }
            return View(_wwiDb.People.Where(p => p.FullName.ToLower().Contains(query.ToLower())).ToList());
        }

        public ActionResult PersonInfo(int? id)
        {
            GroupInfoView infoView = new GroupInfoView
            {
                ThisPerson = _wwiDb.People.Find(id)
            };
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person thisPerson = _wwiDb.People.Find(id);
            if(thisPerson == null)
            {
                return HttpNotFound();
            }
            return View("PersonInfo", infoView);
        }
    }
}