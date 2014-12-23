using FundRaiser.DAL;
using FundRaiser.WebApi.Providers;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Practices.Unity;
using System.Web.Http;

namespace FundRaiser.WebApi
{
    public static class WebApiConfig
    {
        public static IUnityContainer container = new UnityContainer();

        public static void Register(HttpConfiguration config)
        {
            //Register for unity            
            container.RegisterType<IRepository, MockDataProvider>(new HierarchicalLifetimeManager());
            container.RegisterType<IOAuthAuthorizationServerProvider, ApplicationOAuthProvider>(new HierarchicalLifetimeManager());
            container.RegisterType<IMyOAuthAuthorizationServerOptions, MyOAuthAuthorizationServerOptions>(new HierarchicalLifetimeManager());
            container.RegisterType<IAuthenticationTokenProvider, RefereshTokenProvider>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
