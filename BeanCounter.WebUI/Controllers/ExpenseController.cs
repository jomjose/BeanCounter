using BeanCounter.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeanCounter.WebUI.Controllers
{
    public class ExpenseController : Controller
    {
        // GET: Expense
        public ActionResult AddExpenses()
        {
            if (Session["User"] != null)
            {
                return View(ControlPanelViewModel.GetAllCategories());
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
    }
}