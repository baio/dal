using dal.Filters;
using dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dal.Controllers
{
    [VersionFilterAttribute]
    public class ProjectController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult TwiTur()
        {
            ViewBag.ProjectTitle = "TwiTur";

            ViewBag.ProjectSummary = new ProjectSummaryModel { 
                Company = "Data-Avail",
                WebsiteUrl = "http://twitur.ru",
                WebsiteCaption = "twitur.ru",
                SourceCaption = "github", 
                SourceUrl = "#",
                Challenges = "Project designed and built as single web page application.<br/>Large volumes of data to work with.",
                Features = "Service allow find tours by criteria, store filters, invoke notifications when new tours found and contact to tour sellers.",
                Duration = 5,
                Team = new [] {"Maxim Putilov - Project Lead, Programmer"}
            };

            ViewBag.Body = Resource_Projects.TwiTur;

            return View("Item");
        }

        public ActionResult Zava()
        {
            ViewBag.ProjectTitle = "Zava";

            ViewBag.ProjectSummary = new ProjectSummaryModel
            {
                Company = "Data-Avail",
                WebsiteUrl = "http://zava.su",
                WebsiteCaption = "zava.su",
                SourceCaption = "github",
                SourceUrl = "#",
                Challenges = "Rapid development on the base of ASP.NET MVC.",
                Features = "Web portal for mountain sky resort Zavjalikha.",
                Duration = 1,
                Team = new[] { "Maxim Putilov - Project Lead, Programmer" }
            };

            ViewBag.Body = Resource_Projects.TwiTur;

            return View("Item");
        }

        public ActionResult Prezek()
        {
            ViewBag.ProjectTitle = "Prezek";

            ViewBag.ProjectSummary = new ProjectSummaryModel
            {
                Company = "Data-Avail",
                WebsiteUrl = "http://prezek.org",
                WebsiteCaption = "prezek.org",
                SourceCaption = "github",
                SourceUrl = "#",
                Challenges = "Rapid development on the base of ASP.NET MVC.",
                Features = "Find Moscow's poll stations online.",
                Duration = 1,
                Team = new[] { "Maxim Putilov - Project Lead, Programmer" }
            };

            ViewBag.Body = Resource_Projects.Prezek;

            return View("Item");
        }

        public ActionResult Ural()
        {
            ViewBag.ProjectTitle = "Ural";

            ViewBag.ProjectSummary = new ProjectSummaryModel
            {
                Company = "Data-Avail",
                WebsiteUrl = "#",
                WebsiteCaption = "Ural",
                SourceCaption = "github",
                SourceUrl = "#",
                Challenges = "Development of full feathered application framework which is a core for variety of other client applications.",
                Features = "Advanced single page application framework.",
                Duration = 6,
                Team = new[] { "Maxim Putilov - Project Lead, Programmer" }
            };

            ViewBag.Body = Resource_Projects.Ural;

            return View("Item");
        }

        public ActionResult WinForms()
        {
            ViewBag.ProjectTitle = "WinForms";

            ViewBag.ProjectSummary = new ProjectSummaryModel
            {
                Company = "Data-Avail",
                WebsiteUrl = "#",
                WebsiteCaption = "WinForms",
                SourceCaption = "github",
                SourceUrl = "#",
                Challenges = "Development of full feathered application framework which is a core for variety of other client applications.",
                Features = "MV* framework on the base of .Net WinForm libraries.",
                Duration = 10,
                Team = new[] { "Maxim Putilov - Project Lead, Programmer" }
            };

            ViewBag.Body = Resource_Projects.WinForms;

            return View("Item");

        }

        public ActionResult More()
        {
            ViewBag.ProjectTitle = "More Projects";

            ViewBag.Body = Resource_Projects.More;

            return View("Item");

        }


    }
}
