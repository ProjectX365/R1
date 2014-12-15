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
        IRepository repository = null;
        public AccountController()
        {
            //TODO: remove when IOC added
        }

        public AccountController(IRepository repo)
        {
            repository = repo;
        }

        // POST api/register
        [HttpPost]
        [Route("Register")]
        public HttpResponseMessage Register(string email, string password, string UIN)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/login
        [HttpPost]
        [Route("Login")]
        public HttpResponseMessage Login(LoginInfo loginInfo)
        {
            //IDictionary<String, String> data = new Dictionary<String, String>
            //{
            //    { "email", email }
            //};

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
                    UserName = loginInfo.Email,
                    AccessToken = token
                }, Configuration.Formatters.JsonFormatter)
            };
        }
    }
}
