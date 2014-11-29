using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TMBF.Controllers
{
    public class AdminR : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
         
            var session = filterContext.HttpContext.Session;
            if (session["Role"] != null)
            if (session["Role"].ToString() == "Admin")
                return;

    
            var redirectTarget = new RouteValueDictionary { { "action", "Index" }, { "controller", "Home" } };
            filterContext.Result = new RedirectToRouteResult(redirectTarget);
        }
    }
    public class SalesRepR : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            var session = filterContext.HttpContext.Session;
           if(session["Role"]!=null)
            if (session["Role"].ToString() == "SalesRep")
                return;


            var redirectTarget = new RouteValueDictionary { { "action", "Index" }, { "controller", "Home" } };
            filterContext.Result = new RedirectToRouteResult(redirectTarget);
        }
    }
    public class CustomerR : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            var session = filterContext.HttpContext.Session;
            if (session["Role"] != null)
            if (session["Role"].ToString() == "Customer")
                return;

   
            var redirectTarget = new RouteValueDictionary { { "action", "Index" }, { "controller", "Home" } };
            filterContext.Result = new RedirectToRouteResult(redirectTarget);
        }
    }

}