using System.Web;
using System.Web.Mvc;

namespace UfoDataCenter.info
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}