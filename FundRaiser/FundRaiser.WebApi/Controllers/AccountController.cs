using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FundRaiser.WebApi.Controllers
{
    public class AccountController : ApiController
    {
        public async Task<IHttpActionResult> Register(string email, string password, string UIN)
        {
            await Task.Delay(1000);
            return Ok();
        }

        public async Task<IHttpActionResult> Login(string email, string password, string UIN)
        {
            await Task.Delay(1000);
            return Ok();
        }
    }
}
