using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsAgain.Models
{
    public class ProductCategory
    {
        // parameter names should be camelcases (i.e. id, name)
        public ProductCategory(int Id, string Name)
        {
            CategoryId = Id;
            CategoryName = Name;
        }

        public int CategoryId { get; }
        public string CategoryName { get; }
    }
}
