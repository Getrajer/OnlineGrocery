using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public class SQLProductRepository : IProductRepository
    {
        private readonly AppDbContext context;

        public SQLProductRepository(AppDbContext context)
        {
            this.context = context;
        }

        public ProductModel Add(ProductModel productModel)
        {
            context.Products.Add(productModel);
            context.SaveChanges();
            return productModel;
        }

        public ProductModel Delete(int Id)
        {
            ProductModel product = context.Products.Find(Id);

            if(product != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }

            return product;
        }

        public IEnumerable<ProductModel> GetAllProducts()
        {
            return context.Products;
        }

        public ProductModel GetProduct(int Id)
        {
            return context.Products.Find(Id);
        }

        public List<ProductModel> GetProductsOfSupplier(string supplier)
        {
            List<ProductModel> products = context.Products.ToList();
            List<ProductModel> sorted_products = new List<ProductModel>();

            for (int i = 0; i < products.Count; i++)
            {
                if(products[i].SupplierName == supplier)
                {
                    sorted_products.Add(products[i]);
                }
            }

            return sorted_products;
        }

        /// <summary>
        /// If stock of items is lower than 10 it showcases low stock in admin window
        /// </summary>
        /// <returns></returns>
        public int LowStockProductsNumber()
        {
            List<ProductModel> Products = context.Products.ToList();
            Products.RemoveAll(o => o.Quantity > 10);
            return Products.Count();
        }

        public ProductModel Update(ProductModel edit_product)
        {
            var product = context.Products.Attach(edit_product);
            product.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return edit_product;
        }

        
    }
}
