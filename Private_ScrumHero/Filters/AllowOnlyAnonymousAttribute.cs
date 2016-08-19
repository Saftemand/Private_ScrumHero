using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;
using System.Web.WebPages;

namespace Private_ScrumHero.Filters
{
    //Problem: The attribute is being called by all routes
    [AttributeUsage(AttributeTargets.Method)]
    public class AllowOnlyAnonymousAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    {"controller", "Home"},
                    {"action", "Index"}
                });
            }
        }
    }
}