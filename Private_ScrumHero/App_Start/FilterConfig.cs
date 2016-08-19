using System.Web;
using System.Web.Mvc;
using Private_ScrumHero.Filters;

namespace Private_ScrumHero
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
