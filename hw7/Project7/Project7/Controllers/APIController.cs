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

            if (commonWords.Contains(inputData.ToLower())) return Json(inputData, JsonRequestBehavior.AllowGet);
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

        private readonly List<string> commonWords = new List<string>
        {
            "a",
            "about",
            "after",
            "all",
            "also",
            "always",
            "am",
            "and",
            "another",
            "any",
            "anything",
            "around",
            "be",
            "because",
            "before",
            "begin",
            "behind",
            "between",
            "both",
            "by",
            "can't",
            "come",
            "do",
            "don't",
            "down",
            "for",
            "from",
            "get",
            "got",
            "had",
            "hadn't",
            "has",
            "hasn't",
            "have",
            "haven't",
            "if",
            "in",
            "inside",
            "is",
            "isn't",
            "it",
            "just",
            "kept",
            "never",
            "nor",
            "not",
            "other",
            "out",
            "outside",
            "over",
            "some",
            "sometime",
            "somewhere",
            "that",
            "the",
            "this",
            "through",
            "throughout",
            "to",
            "too",
            "under",
            "use",
            "up",
            "was",
            "wasn't",
            "who",
            "whose",
            "you",
            "your",
            "you're",
        };
    }
}