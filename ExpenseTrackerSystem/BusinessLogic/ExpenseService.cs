using ExpenseTrackerSystem.BusinessLogic.APIConsumerService;
using ExpenseTrackerSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ExpenseTrackerSystem.BusinessLogic
{
    public class ExpenseService
    {
        ExpenseServiceConsumer ServiceConsumer = new ExpenseServiceConsumer();

        public List<Expense> ExpensesByUser(int id, out string errorMessage)
        {
            var ExpensesList = new List<Expense>();
            try
            {
                var result = ServiceConsumer.GetAllExpensesByUserId(id);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    errorMessage = string.Empty;
                    ExpensesList = JsonConvert.DeserializeObject<List<Expense>>(result.Content);
                }
                else
                {
                    JObject s = JObject.Parse(result.Content);
                    errorMessage = (string)s["Message"];
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            return ExpensesList;
        }

        // Expense Types
        public List<ExpenseType> ExpenseTypes(out string errorMessage)
        {
            var expenseTypes = new List<ExpenseType>();
            try
            {
                var result = ServiceConsumer.GetAllExpenseTypes();
                if (result.StatusCode == HttpStatusCode.OK)
                {
                    errorMessage = string.Empty;
                    expenseTypes = JsonConvert.DeserializeObject<List<ExpenseType>>(result.Content);
                }
                {
                    JObject s = JObject.Parse(result.Content);
                    errorMessage = (string)s["Message"];
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            return expenseTypes;
        }
    }
}