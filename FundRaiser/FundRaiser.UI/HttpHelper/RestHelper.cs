using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using FundRaiser.Model;
using RestSharp;

namespace FundRaiser.UI.HttpHelper
{
    public class RestHelper
    {
        RestClient restClient;
        public RestHelper()
        {
            restClient = new RestClient("http://localhost:49319/");
        }
      public IRestResponse<Entity> ExternalSignInAsync(Entity entity)
      {
          var request = new RestRequest("api/LogIn", Method.POST) { RequestFormat = DataFormat.Json };
          request.AddBody(entity);
          var response = restClient.Execute<Entity>(request);

          if (response.StatusCode != HttpStatusCode.OK)
              throw new Exception(response.ErrorMessage);
          return response;
      }
    }
}