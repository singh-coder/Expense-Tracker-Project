using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace ExpenseTrackerSystem.BusinessLogic.APIConsumerService
{
    public class RequestResponse
    {
        private RestClient client;
        private string _baseURL = string.Empty;
        public RequestResponse( string baseURL)
        {
            this._baseURL = baseURL;
            client = new RestClient(baseURL);
        }

        public IRestResponse SendRequestList(RestRequest request)
        {
            IRestResponse response = new RestResponse();
            try
            {
                if (!string.IsNullOrEmpty(this._baseURL))
                {
                    request.Timeout = int.MaxValue;
                    request.RequestFormat = DataFormat.Json;

                    response = client.Execute(request);
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        JObject o = new JObject();
                        o["Messasge"]= "Server unavailable, please try again later.";
                        response.Content = o.ToString();
                        response.StatusCode = HttpStatusCode.BadRequest;
                        response.ErrorMessage = "Server unavailable, please try again later.";
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                JObject o = new JObject();
                o["Message"] = ex.Message;

                response.Content = o.ToString();
                response.StatusCode = HttpStatusCode.ExpectationFailed;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }
    }
}