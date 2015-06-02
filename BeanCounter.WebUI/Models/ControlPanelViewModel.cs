using System.Collections.Generic;

using BeanCounter.Domain.Entities;
using BeanCounter.Domain.Abstract;
using BeanCounter.WebUI.Infrastructure;

namespace BeanCounter.WebUI.Models
{
    public class ControlPanelViewModel
    {

        #region Category
        public static IEnumerable<Category> GetAllCategories()
        {
            var resolver = IoCResolver.Resolve<IAddExpenses>();
            var categories= resolver.GetCategories();
            IoCResolver.Release(resolver);
            return categories;
        }

        public static Category AddNewCategory(string category)
        {
            if (!string.IsNullOrEmpty(category))
            {
                var newCategory = new Category
                {
                    ExpenseCategory = category
                };
                var resolver = IoCResolver.Resolve<IAddExpenses>();
                newCategory = resolver.AddCategory(newCategory);
                IoCResolver.Release(resolver);
                return newCategory;
            }
            return null;
        }

        public static int UpdateCategory(Category category)
        {
            var resolver = IoCResolver.Resolve<IAddExpenses>();
            var result = resolver.UpdateCategory(category);
            IoCResolver.Release(resolver);
            return result;
        }

        public static bool DeleteCategory(int id)
        {
            var resolver = IoCResolver.Resolve<IAddExpenses>();
            var isDeleted = resolver.DeleteCategory(id);
            IoCResolver.Release(resolver);
            return isDeleted;
        }

        #endregion Category

   
    }
}