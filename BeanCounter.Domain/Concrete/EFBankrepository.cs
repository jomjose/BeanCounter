
using System;
using System.Collections.Generic;
using System.Linq;

using BeanCounter.Domain.Abstract;
using BeanCounter.Domain.Entities;
using BeanCounter.Domain.Helpers;

namespace BeanCounter.Domain.Concrete
{
    public class EFBankrepository : IBankRepository
    {
        private EFDbBeanCounterContext context = new EFDbBeanCounterContext();
        public IEnumerable<Bank> GetCategories()
        {
            try
            {
                return context.Bank.ToList();
            }
            catch
            {
                return null;
            }
        }

        public Bank AddBank(Bank bank)
        {
            try
            {

                context.Bank.Add(bank);
                context.SaveChanges();

                return bank;
            }
            catch
            {
                return null;
            }

        }

        public int UpdateBank(Bank bank)
        {
            try
            {

                var existingBank = context.Bank.FirstOrDefault(x => x.Id == bank.Id);
                existingBank = bank;
                context.SaveChanges();
                return 1;
            }
            catch
            {
                return -1;
            }

        }

        public bool DeleteBank(int id)
        {
            try
            {
                var existingBank = context.Bank.FirstOrDefault(x => x.Id == id);
                context.Bank.Remove(existingBank);
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
