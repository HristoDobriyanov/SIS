using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using CakesWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CakesWebApp.Data
{
    public class CakesDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products{ get; set; }

        public DbSet<Order> Orders{ get; set; }

        public DbSet<OrderProduct> OrderProducts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();

            optionsBuilder.UseSqlServer(@"Server=DESKTOP-R4OGD90\SQLEXPRESS;
            Database=Cakes;
            Integrated Security=True");
        }
    }
}
