using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

using BeanCounter.WebUI.Models;
using BeanCounter.Domain.Entities;

namespace BeanCounter.WebUI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Dashboard()
        {
            if (Session["User"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult Summary()
        {
            if (Session["User"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }


    }
}