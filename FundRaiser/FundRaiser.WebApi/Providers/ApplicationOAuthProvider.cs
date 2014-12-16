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

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
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
    }
}
