using ExpenseTrackerSystem.BusinessLogic;
using ExpenseTrackerSystem.Models;
using ExpenseTrackerSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ExpenseTrackerSystem.Controllers
{
    public class LoginController : Controller
    {
        LoginService loginService;
        UserService userService;
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [Route("logoutuser")]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            ModelState.Clear();
            return RedirectToAction("Login");
        }
        [HttpGet]
        [Route("loginuser")]
        public ActionResult Login()
        {
            var userModel = new LoginRequestViewModel();
            userModel.isNewUser = false;
            return View(userModel);
        }

        [HttpPost]
        [Route("loginuser")]
        public ActionResult Login(LoginRequestViewModel user)
        {            
            string errorMessage = string.Empty;

            loginService = new LoginService();
            var result = loginService.AuthenticateUser(user, out errorMessage);
            ViewBag.Message = errorMessage;

            if (result.UserDetails != null && !string.IsNullOrEmpty(result.UserDetails.Username))
            {
                FormsAuthentication.SetAuthCookie(result.UserDetails.Username, false);
                Session["UserId"] = result.UserDetails.Id;
            }
            else
            {
                ViewBag.ErrorMsg = "Invalid username or password.";
                return View("Login", user);
            }
            ModelState.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("signup")]
        public ActionResult SignUp()
        {
            var userModel = new LoginRequestViewModel();
            userModel.isNewUser = true;
            return View("Login", userModel);
        }

        [HttpPost]
        [Route("signup")]
        public ActionResult SignUp(LoginRequestViewModel userModel)
        {
            if (userModel != null)
            {
                string errorMessage = string.Empty;
                userService = new UserService();
                var user = new User();

                user.FirstName = userModel.FirstName;
                user.LastName = userModel.LastName;
                user.Email = userModel.Email;
                user.Phone = userModel.Phone;
                user.Username = userModel.Username;
                user.Password = userModel.Password;
                user.isActive = true;
                user.DateCreated = DateTime.Today;
                var NewUser = userService.CreateUser(user, out errorMessage);
                ViewBag.Message = errorMessage;
                if (NewUser != null)
                {
                    ModelState.Clear();                   
                    return RedirectToAction("Login");
                }

            }
            userModel.isNewUser = true;
            return View("Login", userModel);
        }
    }

}