
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
        public IEnumerable<Bank> GetCategories()
        {
            try
            {
                return DbConnector.context.Bank.ToList();
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

                DbConnector.context.Bank.Add(bank);
                DbConnector.context.SaveChanges();

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

                var existingBank = DbConnector.context.Bank.FirstOrDefault(x => x.Id == bank.Id);
                existingBank = bank;
                DbConnector.context.SaveChanges();
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
                var existingBank = DbConnector.context.Bank.FirstOrDefault(x => x.Id == id);
                DbConnector.context.Bank.Remove(existingBank);
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
