﻿using Microsoft.AspNetCore.Http;
using OnlineGrocery.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.ViewModels
{
    public class EditProductViewModel
    {
        public string Title { get; set; }

        public int Id { get; set; }

        [Required, MaxLength(60)]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required, MaxLength(100)]
        public string Description { get; set; }
        [Required]
        public int Quantity { get; set; }
        public string Type { get; set; }
        public string PhotoPath { get; set; }
        public IFormFile Photo { get; set; }

        public string SupplierName { get; set; }
        public int SupplierId { get; set; }
        public List<SuppliersModel> Suppliers = new List<SuppliersModel>();

    }
}
