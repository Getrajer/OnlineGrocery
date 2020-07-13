using System;
using System.Collections.Generic;
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

        public ProductModel Update(ProductModel edit_product)
        {
            var user = context.Products.Attach(edit_product);
            user.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return edit_product;
        }
    }
}
