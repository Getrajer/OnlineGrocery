using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.ViewModels
{
    public class ProductCreateViewModel
    {
        public int Id { get; set; }
        [Required, MaxLength(60)]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required, MaxLength(100)]
        public string Description { get; set; }
        [Required]
        public int Quantity { get; set; }
        public IFormFile Photo { get; set; }
    }
}
