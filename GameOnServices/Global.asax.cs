using GameOnServices.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace GameOnServices
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            WebApiConfig.RegisterSerialization(GlobalConfiguration.Configuration);
            GlobalConfiguration.Configure(UnityConfig.Register);

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error(object sender, EventArgs e) {
            
            var exception = Server.GetLastError();
            Console.WriteLine("Message: "+ exception.Message);
            Console.WriteLine("Stack Trace: " + exception.StackTrace);
        }
    }
}
