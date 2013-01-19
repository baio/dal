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
    [BlogFeedReaderAttribute]
    public class ProjectController : Controller
    {
        public ActionResult Index()
        {
            var model = new ProjectModel[]
            {
                new ProjectModel {
                    Title = "TwiTur.ru",
                    Description = "TwiTur",
                    Text = "Agile tour seracher",
                    Img = "img/work/bahia.jpg",
                    Url = "/Project/TwiTur"
                },
                new ProjectModel {
                    Title = "Zava.su",
                    Description = "Zava",
                    Text = "Portal for zavjalikha mountain ski resort",
                    Img = "img/work/zav3.jpg",
                    Url = "/Project/Zava"
                },
                new ProjectModel {
                    Title = "Prezek.org",
                    Description = "Prezek",
                    Text = "Find your election post in Moscow",
                    Img = "img/work/election2012.jpg",
                    Url = "/Project/Prezek"
                },
                new ProjectModel {
                    Title = "WinForms MVC",
                    Description = "WinForms MVC",
                    Text = "MVC Framework for WinForms",
                    Img = "img/work/winform.jpg",
                    Url = "/Project/WinForms"
                },
                new ProjectModel {
                    Title = "Ural SPA",
                    Description = "Ural",
                    Text = "MVC Framework for web applications",
                    Img = "img/work/ural.jpg",
                    Url = "/Project/Ural"
                },
                new ProjectModel {
                    Title = "Even More",
                    Description = "More",
                    Text = "More projects",
                    Img = "img/work/books.jpg",
                    Url = "/Project/More"
                },

            };
            
            return View(model);
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

            ViewBag.Slides = new ProjectSlideModel[] {
                        new ProjectSlideModel { Img = "/img/projects/twitur/bahia.jpg", Thumb =  "/img/projects/twitur/bahia-thumb.jpg", Title = "Landing Page"},
                        new ProjectSlideModel { Img = "/img/projects/twitur/twitur-home.jpg", Thumb =  "/img/projects/twitur/twitur-home-thumb.jpg", Title = "Home Page"},
                        new ProjectSlideModel { Img = "/img/projects/twitur/twitur-filter.jpg", Thumb =  "/img/projects/twitur/twitur-filter-thumb.jpg", Title = "Filter Page"},
                        new ProjectSlideModel { Img = "/img/projects/twitur/twitur-stored.jpg", Thumb =  "/img/projects/twitur/twitur-stored-thumb.jpg", Title = "Stored Filters"}
                    };

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

            ViewBag.Slides = new ProjectSlideModel[] {
                        new ProjectSlideModel { Img = "/img/projects/zava/zava-landing.jpg", Thumb =  "/img/projects/zava/zava-landing-thumb.jpg", Title = "Landing Page"},
                        new ProjectSlideModel { Img = "/img/projects/zava/zava-home.jpg", Thumb =  "/img/projects/zava/zava-home-thumb.jpg", Title = "Home Page"},
                        new ProjectSlideModel { Img = "/img/projects/zava/zava-news.jpg", Thumb =  "/img/projects/zava/zava-news-thumb.jpg", Title = "News Page"},
                        new ProjectSlideModel { Img = "/img/projects/zava/zava-faq.jpg", Thumb =  "/img/projects/zava/zava-faq-thumb.jpg", Title = "Faq Page"}
                    };

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

            ViewBag.Slides = new ProjectSlideModel[] {
                        new ProjectSlideModel { Img = "/img/projects/prezek/prezek-landing.jpg", Thumb =  "/img/projects/prezek/prezek-landing-thumb.jpg", Title = "Landing Page"},
                        new ProjectSlideModel { Img = "/img/projects/prezek/prezek-home.jpg", Thumb =  "/img/projects/prezek/prezek-home-thumb.jpg", Title = "Home Page"},
                        new ProjectSlideModel { Img = "/img/projects/prezek/prezek-selected.jpg", Thumb =  "/img/projects/prezek/prezek-selected-thumb.jpg", Title = "Selected election post"},
                        new ProjectSlideModel { Img = "/img/projects/prezek/prezek-found.jpg", Thumb =  "/img/projects/prezek/prezek-found-thumb.jpg", Title = "Nearby and similar posts"}
                    };

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

            ViewBag.Slides = new ProjectSlideModel[] {
                        new ProjectSlideModel { Img = "/img/projects/ural/ural.jpg", Thumb =  "/img/projects/ural/ural.jpg", Title = "Landing"},
                        new ProjectSlideModel { Img = "/img/projects/ural/ural-general.jpg", Thumb =  "/img/projects/ural/ural-general-thumb.jpg", Title = "List of items"}
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

            ViewBag.Slides = new ProjectSlideModel[] {
                        new ProjectSlideModel { Img = "/img/projects/winforms-mvc/winform.jpg", Thumb =  "/img/projects/winforms-mvc/winform.jpg", Title = "Landing"},
                        new ProjectSlideModel { Img = "/img/projects/winforms-mvc/winforms-mvc-home.jpg", Thumb =  "/img/projects/winforms-mvc/winforms-mvc-home-thumb.jpg", Title = "List of items"},
                        new ProjectSlideModel { Img = "/img/projects/winforms-mvc/winforms-mvc-manyopen.jpg", Thumb =  "/img/projects/winforms-mvc/winforms-mvc-manyopen-thumb.jpg", Title = "Children windows"},
                        new ProjectSlideModel { Img = "/img/projects/winforms-mvc/winforms-mvc-people.jpg", Thumb =  "/img/projects/winforms-mvc/winforms-mvc-people-thumb.jpg", Title = "Edit items"}
                    };

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
