using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        [Required, MaxLength(60)]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required, MaxLength(100)]
        public string Description { get; set; }
        public string ImgPath { get; set; }
    }
}
