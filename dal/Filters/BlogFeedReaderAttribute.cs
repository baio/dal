using dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace dal.Filters
{
    [AttributeUsage(AttributeTargets.Class)]
    public class BlogFeedReaderAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.BlogFeed = Utils.ReadBlogFeed();

            base.OnActionExecuting(filterContext);
        }
    }

}