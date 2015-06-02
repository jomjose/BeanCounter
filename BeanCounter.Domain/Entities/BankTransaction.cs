using System;

namespace BeanCounter.Domain.Entities
{
    public class BankTransaction
    {
        public long Id { get; set; }
        public int BankId { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public bool IsCredit { get; set; }

    }
}
