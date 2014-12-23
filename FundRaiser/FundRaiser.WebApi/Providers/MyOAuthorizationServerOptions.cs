using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FundRaiser.WebApi.Providers
{
    public class MyOAuthAuthorizationServerOptions : IMyOAuthAuthorizationServerOptions
    {
        private IOAuthAuthorizationServerProvider _provider;
        private IAuthenticationTokenProvider _tokenProvider;

        public MyOAuthAuthorizationServerOptions(IOAuthAuthorizationServerProvider provider, IAuthenticationTokenProvider tokenProvider)
        {
            _provider = provider;
            _tokenProvider = tokenProvider;
        }

        public OAuthAuthorizationServerOptions GetOptions()
        {
            return new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/Token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                //AuthorizeEndpointPath = new PathString("/api/Login"),  //????
                Provider = _provider,
                RefreshTokenProvider = _tokenProvider
            };
        }
    }
}