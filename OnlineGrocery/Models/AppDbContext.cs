﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public class AppDbContext : IdentityDbContext<UserModel>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {

        }

        public DbSet<ShoppingCartItemModel> ShoppingCartItems { get; set; }

        public DbSet<ProductModel> Products { get; set; }

        public DbSet<CMSIndexPageModel> IndexPageModel { get; set; }

        public DbSet<SuppliersModel> Suppliers { get; set; }

        public DbSet<OrderModel> Orders { get; set; }

        public DbSet<OrderItemModel> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
