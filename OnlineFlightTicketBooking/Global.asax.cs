using ExceptionFilterInMVC.App_Start;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace OnlineFlightTicketBooking
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalFilters.Filters.Add(new HandleErrorAttribute());
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //calling RegisterGlobalFilters to register filters globally
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

        }
        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                if (authTicket != null && !authTicket.Expired)
                {
                    var roles = authTicket.UserData.Split(',');
                    HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(new FormsIdentity(authTicket), roles);
                }
            }
        }
    }
}
