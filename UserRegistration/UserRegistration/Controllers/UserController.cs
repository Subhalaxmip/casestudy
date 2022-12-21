using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserRegistration.Models;

namespace UserRegistration.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            user userModel = new user();
            return View(userModel);
        }

        [HttpPost]
        public ActionResult AddOrEdit(user userModel)
        {
            using (DbModels1 dbModel = new DbModels1())
            {
                if(dbModel.users.Any(x => x.Username == userModel.Username))
                {
                    ViewBag.DuplicateMessage = "Username already exist.";
                    return View("AddOrEdit", userModel);
                }

                dbModel.users.Add(userModel);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successful.";
            return View("AddOrEdit", new user());
        }


    }
}