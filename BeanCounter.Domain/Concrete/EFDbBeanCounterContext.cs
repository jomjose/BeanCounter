using System.Data.Entity;
using BeanCounter.Domain.Entities;

namespace BeanCounter.Domain.Concrete
{
    public class EFDbBeanCounterContext:DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Expense> Expense { get; set; }
        public DbSet<Bank> Bank { get; set; }
        public DbSet<BankTransaction> BankTransaction { get; set; }
    }
}
