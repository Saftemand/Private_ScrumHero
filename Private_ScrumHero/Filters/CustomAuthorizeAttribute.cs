using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Private_ScrumHero.Filters
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
                throw new ArgumentNullException("filterContext");
            if (OutputCacheAttribute.IsChildActionCacheActive(filterContext))
                throw new InvalidOperationException("MvcResources.AuthorizeAttribute_CannotUseWithinChildActionCache exception has been invoked");
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowOnlyAnonymousAttribute), true) ||
                filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowOnlyAnonymousAttribute), true))
                return;
            base.OnAuthorization(filterContext);
        }
    }
}