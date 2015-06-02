using System.Collections.Generic;

using BeanCounter.Domain.Entities;

namespace BeanCounter.Domain.Abstract
{
    public interface IBankRepository
    {
        IEnumerable<Bank> GetCategories();
        Bank AddBank(Bank Bank);
        int UpdateBank(Bank Bank);
        bool DeleteBank(int id);
    }
}
