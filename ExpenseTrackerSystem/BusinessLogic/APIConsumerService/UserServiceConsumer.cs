using ExpenseTrackerSystem.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace ExpenseTrackerSystem.BusinessLogic.APIConsumerService
{
    public class UserServiceConsumer
    {
        private RequestResponse requestResponseHandler;
        private RestRequest requestParameter;
        readonly string endPoint = "api/user";
        readonly string baseURL = "http://localhost:54953/";
        public UserServiceConsumer()
        {
            this.requestResponseHandler = new RequestResponse(baseURL);
        }

        // 1. Get All Users List
        public IRestResponse GetUsersList()
        {
            IRestResponse response = new RestResponse();
            try
            {
                requestParameter = new RestRequest(endPoint, Method.GET);
                response = this.requestResponseHandler.SendRequestList(requestParameter);
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        // 2. Get a particular user record based upon ID
        public IRestResponse GetUsersById(int id)
        {
            IRestResponse response = new RestResponse();
            try
            {
                requestParameter = new RestRequest(endPoint + "/" + id, Method.GET);
                response = this.requestResponseHandler.SendRequestList(requestParameter);
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        // 3. Create a new user record
        public IRestResponse CreateUser(User user)
        {
            IRestResponse response = new RestResponse();
            try
            {
                var JsonUserData = JsonConvert.SerializeObject(user);
                requestParameter = new RestRequest(endPoint + "/create", Method.POST);
                requestParameter.AddParameter("application/json", JsonUserData, ParameterType.RequestBody);
                response = this.requestResponseHandler.SendRequestList(requestParameter);
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        // 4. Update an existing user record
        public IRestResponse UpdateUser(User user)
        {
            IRestResponse response = new RestResponse();
            try
            {
                var JsonUserData = JsonConvert.SerializeObject(user);
                requestParameter = new RestRequest(endPoint + "/update", Method.PUT);
                requestParameter.AddParameter("application/json", JsonUserData, ParameterType.RequestBody);
                response = this.requestResponseHandler.SendRequestList(requestParameter);
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        // 5. Delete a user record from the database table
        public IRestResponse DeleteUser(int id)
        {
            IRestResponse response = new RestResponse();
            try
            {
                requestParameter = new RestRequest(endPoint + $"/delete/{id}", Method.DELETE);
                response = this.requestResponseHandler.SendRequestList(requestParameter);
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }
    }
}
