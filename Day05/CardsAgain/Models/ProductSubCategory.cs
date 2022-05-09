using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsAgain.Models
{
    public class ProductSubCategory
    {

        public ProductSubCategory(int subId, int categoryId, string categoryName)
        {
            SubCategoryId = subId;
            CategoryId = categoryId;
            SubCategoryName = categoryName;
        }

        public int SubCategoryId { get; }
        public int CategoryId { get; }
        public string SubCategoryName { get; }
    }
}