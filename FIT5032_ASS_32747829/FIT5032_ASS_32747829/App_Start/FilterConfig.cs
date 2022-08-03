using System.Web;
using System.Web.Mvc;

namespace FIT5032_ASS_32747829
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
