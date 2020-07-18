using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int Quantity { get; set; }
        public string Type { get; set; }
        public string ImgPath { get; set; }

        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
    }
}
