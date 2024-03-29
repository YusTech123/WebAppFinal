﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebAppFinal.Models;
using WebAppFinal;

namespace WebAppFinal.Models
{
    public class SupermarketContext : IdentityDbContext<IdentityUser>
    {
        public SupermarketContext(DbContextOptions<SupermarketContext> options)
        : base(options)
        { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        
        // public DbSet<WebAppFinal.RoleManagementModel> RoleManagementModel { get; set; } = default!;
    }
}

