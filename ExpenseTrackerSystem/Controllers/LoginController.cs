using ExpenseTrackerSystem.BusinessLogic;
using ExpenseTrackerSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpenseTrackerSystem.Controllers
{
    public class LoginController : Controller
    {
        LoginService loginService;
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [Route("logoutuser")]
        public ActionResult LogOut()
        {
            Session["isActive"] = null;
            Session["isAdmin"] = null;
            Session["Username"] = null;
            return View("Index");
        }
        [HttpGet]
        [Route("loginuser")]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("loginuser")]
        public ActionResult Login(LoginRequestViewModel user)
        {
            //user.Username = "jerry";
            //user.Password = "jerry123";
            string errorMessage = string.Empty;

            loginService = new LoginService();
            var result = loginService.AuthenticateUser(user,out errorMessage);
            ViewBag.Message = errorMessage;

            if(result.UserDetails != null && !string.IsNullOrEmpty(result.UserDetails.Username))
            {
                Session["GreetMsg"] = "Welcome "+ result.UserDetails.FirstName;

                if (!result.UserDetails.isActive)
                {
                    // show msg on Login window that user is not active, pls contact admin
                }                   
                else
                {
                    Session["isActive"] = result.UserDetails.isActive;
                    Session["isAdmin"] = result.UserDetails.isAdmin;
                    Session["Username"] = result.UserDetails.Username;
                }
                
            }
            else
            {
                ViewBag.ErrorMsg = "Invalid username or password.";
                return View("Login");
            }
            return RedirectToAction("Index","Home");
            //return RedirectToAction("Index", "Home", new { area = "Home" });
        }
    }

}