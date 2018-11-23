using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Project7.Controllers
{
    public class APIController : Controller
    {
        private readonly string _myGiphyKey = System.Web.Configuration.WebConfigurationManager.AppSettings["AdminGiphy"];

        // GET: API
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetGif(string inputData)
        {
            string _myGiphyURL = "http://api.giphy.com/v1/stickers/translate?api_key=" + _myGiphyKey + "&s=" + inputData;

            WebRequest createURL = WebRequest.Create(_myGiphyURL);
            HttpWebResponse response = (HttpWebResponse)createURL.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string formResponse = reader.ReadToEnd();
            var serializeData = new System.Web.Script.Serialization.JavaScriptSerializer();
            var jsonResponse = serializeData.DeserializeObject(formResponse);

            reader.Close();
            dataStream.Close();
            response.Close();
            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }
    }
}