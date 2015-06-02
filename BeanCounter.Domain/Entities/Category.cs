using System.ComponentModel.DataAnnotations;
namespace BeanCounter.Domain.Entities
{
    public class Category
    {
        //public enum Categories
        //{
        //    //Food,
        //    //Stationary,
        //    //Clothing,
        //    //FootWears,
        //    //Home,
        //    //Vehicle,
        //    //Computer,
        //    //Mobile,
        //    //Recharge,
        //    //Others
        //};
        [Key]
        public int ExpenseCategoryId { get; set; }
        public string ExpenseCategory { get; set; }
    }
}
