using ExpenseTrackerSystem.BusinessLogic;
using ExpenseTrackerSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpenseTrackerSystem.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        // 1. GET: User
        UserService userService = new UserService();


        [Authorize(Roles ="admin")]
        public ActionResult Index()
        {
            string errorMessage = "";
            var usersList = userService.GetUsers(out errorMessage);
            ViewBag.Message = errorMessage;
            return View(usersList);
        }

        // 2. Get User by Id
        public ActionResult GetUserById(int id)
        {
            string errorMessage = "";
            var user = userService.GetUserById(id,out errorMessage);
            ViewBag.Message = errorMessage;
            return View(user);
        }

        // 3. Create new User

        [HttpGet]
        public ActionResult CreateUser()
        {
            return View();
        }

        // 4. Post new user
        [HttpPost]
        public ActionResult CreateUser(User user)
        {
            try
            {
                string errorMessage = "";
                var result = userService.CreateUser(user, out errorMessage);
                ViewBag.Message = errorMessage;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return ViewBag.Message = "Failed to create the user";
            }
        }

        // 5. Update new user
        public ActionResult UpdateUser(User user)
        {
            try
            {
                string errorMessage = "";
                var result = userService.UpdateUser(user, out errorMessage);
                ViewBag.Message = errorMessage;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return ViewBag.Message = "Failed to update the user";
            }
        }

        // 6. Delete the user
        public ActionResult DeleteUser(int id)
        {
            try
            {
                string errorMessage = "";
                var result = userService.DeleteUser(id, out errorMessage);
                ViewBag.Message = errorMessage;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return ViewBag.Message = "Failed to delete the user";
            }
        }
    }
}