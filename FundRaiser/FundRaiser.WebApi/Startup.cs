using FundRaiser.DAL;
using FundRaiser.WebApi.Providers;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Practices.Unity;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

//********************************************************
// This is the OWIN start up class which configure OWIN setup
//********************************************************
[assembly: OwinStartup(typeof(FundRaiser.WebApi.Startup))]
namespace FundRaiser.WebApi
{
    public class Startup
    {
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }

        static Startup()
        {            
            OAuthBearerOptions = new OAuthBearerAuthenticationOptions();
        }

        public void Configuration(IAppBuilder app)
        {
            ConfigureOAuth(app, WebApiConfig.container.Resolve<IMyOAuthAuthorizationServerOptions>());  // use location service
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
        }

        public void ConfigureOAuth(IAppBuilder app, IMyOAuthAuthorizationServerOptions oAuthServerOptions)
        {
            // Token Generation
            app.UseOAuthAuthorizationServer(oAuthServerOptions.GetOptions());
            app.UseOAuthBearerAuthentication(OAuthBearerOptions);
        }

    }
}
