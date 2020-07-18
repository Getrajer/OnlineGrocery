﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public class AppDbContext : DbContext
    {


        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {

        }

        public DbSet<UserModel> Users { get; set; }

        public DbSet<ProductModel> Products { get; set; }

        public DbSet<CMSIndexPageModel> IndexPageModel { get; set; }

        public DbSet<SuppliersModel> Suppliers { get; set; }

        public DbSet<OrderModel> Orders { get; set; }
    }
}
