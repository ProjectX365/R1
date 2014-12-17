using FundRaiser.DAL;
using Microsoft.Owin.Security.OAuth;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FundRaiser.WebApi.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private IRepository repository = null;

        public ApplicationOAuthProvider(IRepository repo)
        {
            repository = repo;
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var allowedOrigin = context.OwinContext.Get<string>("as:clientAllowedOrigin");

            if (allowedOrigin == null) allowedOrigin = "*";

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });
            bool isValidUser = false;

            //Get UIN
            var data = await context.Request.ReadFormAsync();
            var UINstr = data.Where(x => x.Key == "UIN").FirstOrDefault().Value;
            string UIN = null;
            if (UINstr != null)
            {
                UIN = UINstr.First().ToString();
            }

            if (repository.SignIn(context.UserName, context.Password, UIN))
            {
                isValidUser = true;
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

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId = string.Empty;
            string clientSecret = string.Empty;
          
            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                context.TryGetFormCredentials(out clientId, out clientSecret);
            }

            if (context.ClientId == null && context.ClientId=="TestApp")
            {
                context.Validated();
                context.SetError("invalid_clientId", "ClientId should be sent.");
                return Task.FromResult<object>(null);
            }

            if (string.IsNullOrWhiteSpace(clientSecret))
            {
                context.SetError("invalid_clientId", "Client secret should be sent.");
                return Task.FromResult<object>(null);
            }
            else
            {
                if (clientSecret != "secret")
                {
                    context.SetError("invalid_clientId", "Client secret is invalid.");
                    return Task.FromResult<object>(null);
                }
            }

            context.OwinContext.Set<string>("as:clientAllowedOrigin", @"http://localhost:17396/");
            context.Validated();

            return Task.FromResult<object>(null);
        }
    }
}
