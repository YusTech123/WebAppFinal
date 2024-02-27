﻿using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace WebAppFinal.Models
{
    public class SupermarketContext : DbContext
    {
        public SupermarketContext(DbContextOptions<SupermarketContext> options)
        : base(options)
        { }

        public DbSet<Customer> Customers{ get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Basket> Baskets { get; set; }
    }
}
