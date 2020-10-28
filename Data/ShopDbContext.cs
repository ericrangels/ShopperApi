using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyModel;
using ShopperApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopperApi.Data
{
    public class ShopDbContext : IdentityDbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext>options):base(options)
        {

        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
