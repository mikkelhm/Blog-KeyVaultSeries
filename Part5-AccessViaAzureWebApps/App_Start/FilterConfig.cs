using System.Web;
using System.Web.Mvc;

namespace Part5_AccessViaAzureWebApps
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
