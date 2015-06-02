using System;

namespace BeanCounter.Domain.Entities
{
    public class Expense
    {
        public long Id { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }
}
