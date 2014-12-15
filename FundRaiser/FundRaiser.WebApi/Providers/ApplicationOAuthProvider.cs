using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser.WebApi.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            bool isValidUser = false;

            var data = await context.Request.ReadFormAsync();
            var UIN = data.Where(x => x.Key == "UIN").FirstOrDefault().Value;

            if (UIN != null)
            {
                string UINstr = UIN.First().ToString();
                //TODO:  Check UIN in system to make sure user is register with 3rd party OAuth 
                isValidUser = true;
            }
            else
            {
                //TODO: Check User/Password in system to make sure it's register in local sys 
                if (context.UserName == "test" && context.Password == "test")
                {
                    isValidUser = true;
                }
            }

            if (!isValidUser)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }


            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            //identity.AddClaim(new Claim("sub", context.UserName)); 
            //identity.AddClaim(new Claim("role", "admin")); 

            context.Validated(identity);
        }
    }
}
