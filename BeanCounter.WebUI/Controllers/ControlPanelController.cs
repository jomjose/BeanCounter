using BeanCounter.Domain.Entities;
using BeanCounter.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeanCounter.WebUI.Controllers
{
    public class ControlPanelController : Controller
    {
        // GET: ControlPanel
        public ActionResult Index()
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

        #region Category

        [HttpPost]
        public JsonResult AddNewCategory(Category category)
        {
            return Json(ControlPanelViewModel.AddNewCategory(category.ExpenseCategory));
        }

        [HttpPost]
        public JsonResult UpdateCategory(Category category)
        {
            return Json(ControlPanelViewModel.UpdateCategory(category));
        }

        [HttpPost]
        public JsonResult DeleteCategory(Category category)
        {
            return Json(ControlPanelViewModel.DeleteCategory(category.ExpenseCategoryId));
        } 
        #endregion


        #region Bank
        [HttpPost]
        public JsonResult AddNewBank(Bank Bank)
        {
            return Json(ControlPanelViewModel.AddNewBank(Bank));
        }

        [HttpPost]
        public JsonResult UpdateBank(Bank Bank)
        {
            return Json(ControlPanelViewModel.UpdateBank(Bank));
        }

        [HttpPost]
        public JsonResult DeleteBank(Bank Bank)
        {
            return Json(ControlPanelViewModel.DeleteBank(Bank.Id));
        } 
        #endregion
    }
}