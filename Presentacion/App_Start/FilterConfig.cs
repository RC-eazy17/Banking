using System.Web;
using System.Web.Mvc;
using Presentacion.Models.Filter;

namespace Presentacion
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new Models.Filter.VerificarSession());
        }
    }
}
