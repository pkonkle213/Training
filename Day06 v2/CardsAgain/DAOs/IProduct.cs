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
        // should return IEnumerable<> instead of List<>
        List<ProductCategory> GetProductCategories();

        // when possible, you should always do queries based on an id, not a name. this ties to my comment on the UI about populating dropdowns with display text and id values
        List<ProductSubCategory> GetProductSubcategories(string subCategoryName);
        List<Product> GetProducts(string subCategoryName);
        Product GetProduct(int productId);
    }
}
