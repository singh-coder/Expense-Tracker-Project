using ExpenseTrackerSystem.BusinessLogic.APIConsumerService;
using ExpenseTrackerSystem.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpenseTrackerSystem.BusinessLogic
{
    public class UserService
    {
        UserServiceConsumer UserServiceConsumer = null;
        public List<User> GetUsers(out string errorMessage)
        {
            var usersList = new List<User>();
            try
            {
                UserServiceConsumer = new UserServiceConsumer();
                var result = UserServiceConsumer.GetUsersList();
                if(result.StatusCode== System.Net.HttpStatusCode.OK)
                {
                    errorMessage = string.Empty;
                    usersList = JsonConvert.DeserializeObject<List<User>>(result.Content);
                }
                else
                {
                    JObject s = JObject.Parse(result.Content);
                    errorMessage = (string)s["Message"];
                }
                return usersList;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return usersList;
            }
        }

        //Get User By Id
        public User GetUserById(int id, out string errorMessage)
        {
            var user = new User();
            try
            {
                UserServiceConsumer = new UserServiceConsumer();
                var result = UserServiceConsumer.GetUsersById(id);
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    errorMessage = string.Empty;
                    user = JsonConvert.DeserializeObject<User>(result.Content);
                }
                else
                {
                    JObject s = JObject.Parse(result.Content);
                    errorMessage = (string)s["Message"];
                }
                return user;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return user;
            }
        }

        // Post user
        public User CreateUser(User user, out string errorMessage)
        {
            try
            {
                UserServiceConsumer = new UserServiceConsumer();
                var result = UserServiceConsumer.CreateUser(user);
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    errorMessage = string.Empty;
                    user = JsonConvert.DeserializeObject<User>(result.Content);
                }
                else
                {
                    JObject s = JObject.Parse(result.Content);
                    errorMessage = (string)s["Message"];
                }
                return user;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return user;
            }
        }

        // Update user
        public User UpdateUser(User user,out string errorMessage)
        {
            try
            {
                UserServiceConsumer = new UserServiceConsumer();
                var result = UserServiceConsumer.UpdateUser(user);
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    errorMessage = string.Empty;
                    user = JsonConvert.DeserializeObject<User>(result.Content);
                }
                else
                {
                    JObject s = JObject.Parse(result.Content);
                    errorMessage = (string)s["Message"];
                }
                return user;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return user;
            }
        }

        // Delete User
        public bool DeleteUser(int id, out string errorMessage)
        {
            bool isDeleted = false;
            try
            {
                UserServiceConsumer = new UserServiceConsumer();
                var result = UserServiceConsumer.DeleteUser(id);
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    errorMessage = string.Empty;
                    isDeleted = true;
                }
                else
                {
                    isDeleted = false;
                    errorMessage = (string)s["Message"];
                }
                return isDeleted;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}