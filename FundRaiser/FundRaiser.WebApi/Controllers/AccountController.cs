using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using FundRaiser.Model;
using FundRaiser.DAL;

namespace FundRaiser.WebApi.Controllers
{
    [RoutePrefix("api")]
    public class AccountController : ApiController
    {
        private IRepository repository = null;

        public AccountController(IRepository repo)
        {
            repository = repo;
        }

        // POST api/register
        [HttpPost]
        [Route("Register")]
        public HttpResponseMessage Register(Entity userInfo)
        {
            var signedUp = repository.SignUp(userInfo.EmailID, userInfo.FirstName, userInfo.LastName, userInfo.UIN, userInfo.Password);
            if (signedUp)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/login
        [Obsolete]
        [HttpPost]
        [Route("Login")]
        public HttpResponseMessage Login(Entity userInfo)
        {
            //IDictionary<String, String> data = new Dictionary<String, String>
            //{
            //    { "email", email }
            //};
            //if (!repository.SignIn(userInfo.EmailID, userInfo.Password, userInfo.UIN))
            //{
            //    return Request.CreateResponse(HttpStatusCode.NotFound);
            //}
            
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, "test1"));
            claims.Add(new Claim(ClaimTypes.Email, "test2"));
            
            ClaimsIdentity oAuthIdentity = new ClaimsIdentity(claims, OAuthDefaults.AuthenticationType);            
            AuthenticationProperties properties = new AuthenticationProperties();
            AuthenticationTicket ticket = new AuthenticationTicket(oAuthIdentity, properties);
            ticket.Properties.ExpiresUtc = DateTime.Now.Add(TimeSpan.FromDays(1)).ToUniversalTime();
            var token = Startup.OAuthBearerOptions.AccessTokenFormat.Protect(ticket);            
            
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<object>(new
                {
                    UserName = userInfo.EmailID,
                    AccessToken = token,
                    ClaimsIdentity = oAuthIdentity
                }, Configuration.Formatters.JsonFormatter)
            };
        }
    }
}
