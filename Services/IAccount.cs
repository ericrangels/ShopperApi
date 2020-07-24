using ShopperApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopperApi.Services
{
    public interface IAccount
    {
        //CRUD Operations
        IEnumerable<Account> GetAccounts(string sort, string filter, int page);
        Account GetAccount(int id);
        void AddAccount(Account account);
        void UpdAccount(Account account);
        void DelAccount(int id);
    }
}
