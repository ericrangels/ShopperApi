using ShopperApi.Data;
using ShopperApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopperApi.Services
{
    public class CustomerRepository :ICustomer
    {
        private ShopDbContext shopDbContext;

        public CustomerRepository(ShopDbContext _customerDbContext)
        {
            shopDbContext = _customerDbContext;
        }

        public IEnumerable<Customer> GetCustomers(string sort, string filter, int page)
        {
            IQueryable<Customer> customers;

            int pageSize = 3;

            switch (sort)
            {
                case "desc":
                    customers = shopDbContext.Customers.OrderByDescending(c => c.name);
                    break;

                case "asc":
                    customers = shopDbContext.Customers.OrderBy(c => c.name);
                    break;

                default:
                    customers = shopDbContext.Customers;
                    break;
            }

            var items = customers.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            if (filter != null)
            {
                items = items.Where(c => c.name.StartsWith(filter)).ToList();
            }

            return items;
        }
        public Customer GetCustomer(int id)
        {
            var coustomer = shopDbContext.Customers.SingleOrDefault(c => c.id == id);
            return coustomer;
        }

        public void AddCustomer(Customer customer)
        {
            shopDbContext.Customers.Add(customer);
            shopDbContext.SaveChanges(true);
        }

        public void UpdCustomer(Customer customer)
        {
            shopDbContext.Customers.Update(customer);
            shopDbContext.SaveChanges(true);
        }

        public void DelCustomer(int id)
        {
            var customer = shopDbContext.Customers.Find(id);

            shopDbContext.Customers.Remove(customer);
            shopDbContext.SaveChanges(true);
        }
    }
}
