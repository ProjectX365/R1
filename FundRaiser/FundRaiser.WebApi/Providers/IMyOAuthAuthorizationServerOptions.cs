using System;
namespace FundRaiser.WebApi.Providers
{
    public interface IMyOAuthAuthorizationServerOptions
    {
        Microsoft.Owin.Security.OAuth.OAuthAuthorizationServerOptions GetOptions();
    }
}
