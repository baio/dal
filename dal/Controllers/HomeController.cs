using dal.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace dal.Controllers
{
    [VersionFilterAttribute]
    [BlogFeedReaderAttribute]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.LatestTweets = Utils.ReadTweets().ToArray();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
