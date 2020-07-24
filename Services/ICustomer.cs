using ShopperApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopperApi.Services
{
    public interface ICustomer
    {
        //CRUD Operations
        IEnumerable<Customer> GetCustomers(string sort, string filter, int page);
        Customer GetCustomer(int id);
        void AddCustomer(Customer customer);
        void UpdCustomer(Customer customer);
        void DelCustomer(int id);
    }
}
