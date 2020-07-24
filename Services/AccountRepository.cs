using ShopperApi.Data;
using ShopperApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ShopperApi.Services
{
    public class AccountRepository : IAccount
    {
        private ShopDbContext shopDbContext;

        public AccountRepository(ShopDbContext _accountDbContext)
        {
            shopDbContext = _accountDbContext;
        }

        public IEnumerable<Account> GetAccounts(string sort, string filter, int page = 1)
        {
            IQueryable<Account> accounts;

            int pageSize = 3;

            switch (sort)
            {
                case "desc":
                    accounts = shopDbContext.Accounts.OrderByDescending(a => a.login);
                    break;

                case "asc":
                    accounts = shopDbContext.Accounts.OrderBy(a => a.login);
                    break;

                default:
                    accounts = shopDbContext.Accounts;
                    break;
            }

            var items = accounts.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            if (filter != null)
            {
                items = items.Where(a => a.login.StartsWith(filter)).ToList();
            }

            return items;
        }

        public Account GetAccount(int id)
        {
            var account = shopDbContext.Accounts.SingleOrDefault(a => a.id == id);
            return account;
        }

        public void AddAccount(Account account)
        {

            account.pwd = ToHashMd5Hexadecimal(account.pwd);

            shopDbContext.Accounts.Add(account);
            shopDbContext.SaveChanges(true);
        }

        public void UpdAccount(Account account)
        {
            account.pwd = ToHashMd5Hexadecimal(account.pwd);

            shopDbContext.Accounts.Update(account);
            shopDbContext.SaveChanges(true);
        }

        public void DelAccount(int id)
        {
            var account = shopDbContext.Accounts.Find(id);

            shopDbContext.Accounts.Remove(account);
            shopDbContext.SaveChanges(true);
        }

        //Example - Hashpwd Function
        private static string ToHashMd5Hexadecimal(string value)
        {
            using (var md5 = MD5.Create())
            {
                var data = Encoding.UTF8.GetBytes(value);
                var hashBytes = md5.ComputeHash(data);
                var hashHex = BitConverter.ToString(hashBytes);
                var result = hashHex.Replace("-", string.Empty).ToLowerInvariant();
                return result;
            }
        }

    }
}
