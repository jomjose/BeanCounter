using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BeanCounter.WebUI.Models;

namespace BeanCounter.WebUI.Controllers
{
    public class AccountController : Controller
    {

        // GET: Account
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult SignIn(AccountViewModel details)
        {
            if (details.AuthenticateUser())
            {
                return RedirectToAction("Dashboard", "Home");
            }
            return View("Login");
        }

        [HttpPost]
        public JsonResult SignUp(AccountViewModel details)
        {
            return Json(details.CreateUser());
        }


    }
}