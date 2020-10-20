using Cart_MS.DB.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cart_MS.DB
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> op) : base(op)
        {
                
        }
        public DbSet<Cart> Carts { get; set; }
    }
}

