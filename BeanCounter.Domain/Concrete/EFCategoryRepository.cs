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

        public IEnumerable<Category> GetCategories()
        {
            try
            {
                return DbConnector.context.Category.ToList();
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
                var existingCategory = DbConnector.context.Category.FirstOrDefault(x => x.ExpenseCategory == category.ExpenseCategory);
                if (existingCategory == null)
                {
                    DbConnector.context.Category.Add(category);
                    DbConnector.context.SaveChanges();
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

                var existingCategory = DbConnector.context.Category.FirstOrDefault(x => x.ExpenseCategory == category.ExpenseCategory);
                if (existingCategory == null)
                {
                    existingCategory = DbConnector.context.Category.FirstOrDefault(x => x.ExpenseCategoryId == category.ExpenseCategoryId);
                    existingCategory.ExpenseCategory = category.ExpenseCategory;
                    DbConnector.context.SaveChanges();
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
                var existingCategory = DbConnector.context.Category.FirstOrDefault(x => x.ExpenseCategoryId == id);
                DbConnector.context.Category.Remove(existingCategory);
                DbConnector.context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
