using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

using BeanCounter.Domain.Abstract;
using BeanCounter.Domain.Entities;
using BeanCounter.Domain.Helpers;

namespace BeanCounter.Domain.Concrete
{
    public class EFCategoryRepository:IAddExpenses
    {
        private EFDbBeanCounterContext context = new EFDbBeanCounterContext();

        public IEnumerable<Category> GetCategories()
        {
            try
            {
                return context.Category.ToList();
            }
            catch
            {
                return null;
            }
        }

        public Category AddCategory(Category category)
        {
            try
            {
                var existingCategory = context.Category.FirstOrDefault(x => x.ExpenseCategory == category.ExpenseCategory);
                if (existingCategory == null)
                {
                    context.Category.Add(category);
                    context.SaveChanges();
                    return category;
                }
                category.ExpenseCategoryId = -1;
                return category;
            }
            catch
            {
                return null;
            }

        }

        public int UpdateCategory(Category category)
        {
            try
            {

                var existingCategory = context.Category.FirstOrDefault(x => x.ExpenseCategory == category.ExpenseCategory);
                if (existingCategory == null)
                {
                    existingCategory = context.Category.FirstOrDefault(x => x.ExpenseCategoryId == category.ExpenseCategoryId);
                    existingCategory.ExpenseCategory = category.ExpenseCategory;
                    context.SaveChanges();
                    return 1;
                }
                return 0;


            }
            catch
            {
                return -1;
            }

        }

        public bool DeleteCategory(int id)
        {
            try
            {
                var existingCategory = context.Category.FirstOrDefault(x => x.ExpenseCategoryId == id);
                context.Category.Remove(existingCategory);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
