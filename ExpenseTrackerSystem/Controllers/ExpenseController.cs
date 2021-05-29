using ExpenseTrackerSystem.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpenseTrackerSystem.Controllers
{
    [Authorize]
    public class ExpenseController : Controller
    {
        ExpenseService expenseService = new ExpenseService();

        // GET: Expense
        [Authorize(Roles ="user, admin")]
        public ActionResult Index()
        {
            string errorMsg = string.Empty;
            var expenseTypes = expenseService.ExpenseTypes(out errorMsg);

            int userId = Convert.ToInt32(Session["UserId"]);
            var expensesList = expenseService.ExpensesByUser(userId, out errorMsg);
            return View(expensesList);
        }
    }
}