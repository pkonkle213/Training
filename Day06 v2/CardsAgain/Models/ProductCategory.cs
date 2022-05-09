using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsAgain.Models
{
    public class ProductCategory
    {
        public ProductCategory(int Id, string Name)
        {
            CategoryId = Id;
            CategoryName = Name;
        }

        public int CategoryId { get; }
        public string CategoryName { get; }
    }
}
