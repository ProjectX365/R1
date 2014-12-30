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
            //Use this if nneed to debug service
            //restClient = new RestClient("http://localhost.fiddler:8081/");
            restClient = new RestClient("http://localhost:8081/");
        }
        public IRestResponse<Entity> SignInAsync(Entity entity)
        {
            var request = new RestRequest("Token", Method.POST) { RequestFormat = DataFormat.Json };
            request.AddParameter("application/x-www-form-urlencoded", "grant_type=password&UIN=" + entity.UIN + "&client_id=testApp&client_secret=secret", ParameterType.RequestBody);
            var response = restClient.Execute<Entity>(request);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.ErrorMessage);
            return response;
        }
    }
}