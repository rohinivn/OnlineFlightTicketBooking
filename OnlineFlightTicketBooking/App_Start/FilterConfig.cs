using System.Web.Mvc;
using ExceptionFilterInMVC.Models;
namespace ExceptionFilterInMVC.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new LogCustomExceptionFilter());
        }
    }
}