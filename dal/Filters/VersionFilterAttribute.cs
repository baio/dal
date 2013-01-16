using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace dal.Filters
{
    [AttributeUsage(AttributeTargets.Class)]
    public class VersionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            filterContext.Controller.ViewBag.Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            base.OnActionExecuting(filterContext);
        }
    }
}