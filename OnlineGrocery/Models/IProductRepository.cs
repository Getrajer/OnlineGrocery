using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public interface IProductRepository
    {
        ProductModel GetProduct(int Id);

        IEnumerable<ProductModel> GetAllProducts();

        ProductModel Add(ProductModel productModel);

        ProductModel Delete(int Id);

        ProductModel Update(ProductModel edit_product);
    }
}
