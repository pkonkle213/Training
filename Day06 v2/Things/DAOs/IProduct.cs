using System.Collections.Generic;
using Things.Models;

namespace Things.DAOs
{
    public interface IProduct
    {
        public List<ProductCategory> GetProductCategories();
        public List<ProductSubCategory> GetProductSubcategories(int categoryId);
        public List<Product> GetProducts(int subcategoryId);
        public Product GetProduct(int productId);
    }
}
