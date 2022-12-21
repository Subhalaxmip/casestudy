using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AuthenticateMVC.Models;
using System.Linq;

namespace AuthenticateMVC.Controllers
{
    public class AccountsController : Controller
    {
        
        LOGIN_DBEntities1 entity = new LOGIN_DBEntities1();
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel Credentials)
        {
            bool userExist = entity.UsersTb1.Any(x => x.Email == Credentials.Email && x.Passcode == Credentials.Password);
            UsersTb1 u = entity.UsersTb1.FirstOrDefault(x => x.Email == Credentials.Email && x.Passcode == Credentials.Password);

            if (userExist) 
            {
                FormsAuthentication.SetAuthCookie(u.Username, false);
                return RedirectToAction("Index", "Home");

            }

            ModelState.AddModelError("", "Username or Password is wrong");

            return View();
        }

        [HttpPost]
        public ActionResult Signup(UsersTb1 userinfo)
        {
            entity.UsersTb1.Add(userinfo);  
            entity.SaveChanges();
            return RedirectToAction("Login");
        }

        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}