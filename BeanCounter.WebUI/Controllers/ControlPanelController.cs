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



    }
}