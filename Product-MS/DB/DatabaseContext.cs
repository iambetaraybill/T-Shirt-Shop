using Microsoft.EntityFrameworkCore;
using Product_MS.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_MS.DB
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-2C1ONKU\\SQLSERVER2019;Initial Catalog=ShirtShopData;User Id=sa;Password=arpan@1998;Integrated Security=false; ");
        //}

    }
}
