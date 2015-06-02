using System.Collections.Generic;
using BeanCounter.Domain.Entities;

namespace BeanCounter.Domain.Abstract
{
    public interface IAddExpenses
    {
        IEnumerable<Category> GetCategories();
        Category AddCategory(Category category);
        int UpdateCategory(Category category);
        bool DeleteCategory(int id);
    }
}
