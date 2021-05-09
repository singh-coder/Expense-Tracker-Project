using ExpenseTrackerSystem.BusinessLogic.APIConsumerService;
using ExpenseTrackerSystem.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpenseTrackerSystem.BusinessLogic
{
    public class LoginService
    {
        LoginServiceConsumer loginServiceConsumer = null;

        
        public LoginResponseViewModel AuthenticateUser(LoginRequestViewModel loginData, out string errorMessage)
        {
            LoginResponseViewModel response = new LoginResponseViewModel();
            try
            {
                loginServiceConsumer = new LoginServiceConsumer();
                var responseData = loginServiceConsumer.AuthenticateUser(loginData);
                if(responseData.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    response = JsonConvert.DeserializeObject<LoginResponseViewModel>(responseData.Content);
                    errorMessage = string.Empty;
                }
                else
                {
                    JObject s = JObject.Parse(responseData.Content);
                    errorMessage = (string)s["Message"];
                }
                return response;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return response;
            }
        }
    }
}