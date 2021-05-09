using ExpenseTrackerSystem.ViewModels;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpenseTrackerSystem.BusinessLogic.APIConsumerService
{
    public class LoginServiceConsumer
    {
        private RequestResponse requestResponseHandler;
        private RestRequest requestParameter;
        readonly string endPoint = "api/login";
        readonly string baseURL = "http://localhost:54953/";
        public LoginServiceConsumer()
        {
            this.requestResponseHandler = new RequestResponse(baseURL);
        }

        //Method to Authenticate user
        public IRestResponse AuthenticateUser(LoginRequestViewModel userLogin)
        {
            IRestResponse response = new RestResponse();
            try
            {
                var JsonLoginData = JsonConvert.SerializeObject(userLogin);
                requestParameter = new RestRequest(endPoint, Method.POST);
                requestParameter.AddParameter("application/json", JsonLoginData, ParameterType.RequestBody);
                response = this.requestResponseHandler.SendRequestList(requestParameter);
            }
            catch (Exception ex)
            {
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }
    }
}