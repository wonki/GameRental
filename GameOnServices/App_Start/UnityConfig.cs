using GameOnServices.ProxyServices;
using GameOnServices.Services;
using System.Web.Http;
using Unity;

namespace GameOnServices.App_Start
{
    public class UnityConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<ISearchService, SearchService>();
            container.RegisterType<IApiHelper, ApiHelper>();
            config.DependencyResolver = new App_Start.UnityResolver(container);


        }
    }
}