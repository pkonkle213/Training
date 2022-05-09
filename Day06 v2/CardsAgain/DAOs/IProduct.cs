using CardsAgain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsAgain.DAOs
{
    public interface IProduct
    {
        List<ProductCategory> GetProductCategories();
        List<ProductSubCategory> GetProductSubcategories(string subCategoryName);
        List<Product> GetProducts(string subCategoryName);
        Product GetProduct(int productId);
    }
}
