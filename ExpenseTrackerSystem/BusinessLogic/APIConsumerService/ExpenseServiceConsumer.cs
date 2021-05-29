using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace ExpenseTrackerSystem.BusinessLogic.APIConsumerService
{
    public class ExpenseServiceConsumer
    {
        private RequestResponse requestResponseHandler;
        private RestRequest requestParameter;
        readonly string endPoint = "api/expense/"; 
        readonly string endPointExpenseTypes = "api/expensetype/"; 
        //readonly string baseURL = "http://localhost:54953/";

        public ExpenseServiceConsumer()
        {
            this.requestResponseHandler = new RequestResponse();
        }

        //1. Get All Expenses of a user
        public IRestResponse GetAllExpensesByUserId(int id)
        {
            IRestResponse response = new RestResponse();
            try
            {
                requestParameter = new RestRequest(endPoint + "GetExpensesByUser/" + id, Method.GET);
                response = this.requestResponseHandler.SendRequestList(requestParameter);
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        // Expense Types & Subtypes
        public IRestResponse GetAllExpenseTypes()
        {
            IRestResponse response = new RestResponse();
            try
            {
                requestParameter = new RestRequest(endPointExpenseTypes, Method.GET);
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