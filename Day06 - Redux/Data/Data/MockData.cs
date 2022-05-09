using System.Collections.Generic;
using Things.DAOs;
using Things.Models;

namespace Data
{
    public class MockData
    {
        public DAOProduct dao = new DAOProduct();

        public List<ProductCategory> allCategories = new List<ProductCategory>()
        {
            new ProductCategory(1,"Permanent"),
            new ProductCategory(2,"Fast Effect"),
            new ProductCategory(3,"Token"),
        };

        public List<ProductSubCategory> allSubCategories = new List<ProductSubCategory>()
        {
            new ProductSubCategory(1,1,"Land"),
            new ProductSubCategory(2,1,"Creature"),
            new ProductSubCategory(3,2,"Instant"),
            new ProductSubCategory(4,2,"Sorcery"),
            new ProductSubCategory(5,3,"Artifact"),
            new ProductSubCategory(6,3,"Emblem"),
        };

        public List<Product> allProducts = new List<Product>()
        {
            new Product(1,1,"Island","Colorless",18M),
            new Product(2,1,"Hallowed Fountain","Colorless",17M),
            new Product(3,1,"Tundra","Colorless",16M),
            new Product(4,2,"Dark Confidant","Black",15M),
            new Product(5,2,"Snapcaster Mage","Blue",14M),
            new Product(6,2,"Young Pyromancer","Red",13M),
            new Product(7,3,"Path to Exile","White",.12M),
            new Product(8,3,"Cryptic Command","Blue",11M),
            new Product(9,3,"Beast Within","Green",10M),
            new Product(10,4,"Day of Judgment","White",9M),
            new Product(11,4,"Time Warp","Blue",8M),
            new Product(12,4,"Chain Lightning","Red",7M),
            new Product(13,5,"Howling Mine","Colorless",6M),
            new Product(14,5,"Pithing Needle","Colorless",5M),
            new Product(15,5,"Black Lotus","Colorless",4M),
            new Product(16,6,"Domri Rade","Colorless",3M),
            new Product(17,6,"Garruk Wildspeaker","Colorless",2M),
            new Product(18,6,"Teferi, Hero of Dominaria","Colorless",1M)
        };
    }
}
