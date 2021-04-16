using GameOnServices.App_Start;
using Newtonsoft.Json.Serialization;
using System;
using System.Web.Http;
using System.Web.Http.WebHost;

namespace GameOnServices
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // //temp solution since there is no DB, enable session state
            //https://www.wiliam.com.au/wiliam-blog/enabling-session-state-in-web-api
            var httpControllerRouteHandler = typeof(HttpControllerRouteHandler).GetField("_instance",
         System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);

            if (httpControllerRouteHandler != null)
            {
                httpControllerRouteHandler.SetValue(null,
                    new Lazy<HttpControllerRouteHandler>(() => new SessionHttpControllerRouteHandler(), true));
            }
            // end temp solution

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional,controller="Search" }
            );
        }

        public static void RegisterSerialization(HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver(); // force camelCasing

        }
    }
}
