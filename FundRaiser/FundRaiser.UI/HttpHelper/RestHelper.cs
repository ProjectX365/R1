using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using RestSharp;

namespace FundRaiser.UI.HttpHelper
{
    public class RestHelper
    {
        RestClient restClient = new RestClient("http://localhost:49319/");
        //public RestHelper()
        //{

        //}
      public Task ExternalSignInAsync(string userName,string password, string userId)
      {
          var request = new RestRequest("api/LogIn", Method.GET) { RequestFormat = DataFormat.Json };
      }
    }
}