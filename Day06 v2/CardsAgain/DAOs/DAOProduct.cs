using CardsAgain.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsAgain.DAOs
{
    public class DAOProduct : IProduct
    {
        private string connection;

        public DAOProduct(string connectionstring)
        {
            this.connection = connectionstring;
        }

        public List<ProductCategory> GetProductCategories()
        {
            List<ProductCategory> allCategories = new List<ProductCategory>();
            string sql = "SELECT ProductCategoryID, Name " +
                "FROM Production.ProductCategory";

            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            allCategories.Add(
                                new ProductCategory(
                                    Convert.ToInt32(reader["ProductCategoryID"]),
                                    Convert.ToString(reader["Name"])
                                )
                            );
                        }
                    }
                }
            }

            return allCategories;   // I've been told that arrays are better than lists for performance, so return allCategories.ToArray()
        }

        // I find it better to group all private methods in a class at the bottom of the file, instead of interspersing public and private methods.
        // I also like using #region statements for code organization, but I know other developers HATE #region statements lol
        private List<ProductSubCategory> GetAllSubCategories()
        {
            List<ProductSubCategory> allSubCategories = new List<ProductSubCategory>();
            string sql = "SELECT ProductSubcategoryID, ProductCategoryID, Name " +
                "FROM Production.ProductSubCategory";

            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            allSubCategories.Add(
                                new ProductSubCategory(
                                    Convert.ToInt32(reader["ProductSubcategoryID"]),
                                    Convert.ToInt32(reader["ProductCategoryID"]),
                                    Convert.ToString(reader["Name"])
                                )
                            );
                        }
                    }
                }
            }

            return allSubCategories;
        }

        private List<Product> GetAllProducts()
        {
            List<Product> allProducts = new List<Product>();
            string sql = "SELECT ProductID, ProductSubcategoryID, Name, Color, ListPrice " +
                "FROM Production.Product " +
                "WHERE ProductSubcategoryID IS NOT NULL AND Color IS NOT NULL";

            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            allProducts.Add(
                                new Product(
                                    Convert.ToInt32(reader["ProductID"]),
                                    Convert.ToInt32(reader["ProductSubcategoryID"]),
                                    Convert.ToString(reader["Name"]),
                                    Convert.ToString(reader["Color"]),
                                    Convert.ToDecimal(reader["ListPrice"])
                                )
                            );
                        }
                    }
                }
            }

            return allProducts;
        }

        private int FindCategoryId(string categoryName)
        {
            // better to use LINQ to limit the collection you need to iterate over.
            // if you do GetProductCategories().Where(pc => pc.CategoryName == categoryName), you could completely eliminate the if within the loop
            foreach (ProductCategory category in GetProductCategories())
            {
                if (category.CategoryName == categoryName)
                {
                    return category.CategoryId;
                }
            }

            return -1;
        }

        private int FindSubcategoryId(string subCategory)
        {
            foreach(ProductSubCategory subcategory in GetAllSubCategories())
            {
                if (subcategory.SubCategoryName == subCategory)
                {
                    return subcategory.SubCategoryId;
                }
            }

            return -1;
        }

        public List<ProductSubCategory> GetProductSubcategories(string subCategoryName)
        {
            List<ProductSubCategory> subCategories = new List<ProductSubCategory>();
            foreach (ProductSubCategory subCategory in GetAllSubCategories())   // GetAllSubCategories().Where(sc => sc.CategoryId == subCategoryId)
            {
                if (subCategory.CategoryId == FindCategoryId(subCategoryName))
                {
                    subCategories.Add(subCategory);
                }
            }

            return subCategories;
        }

        public List<Product> GetProducts(string subCategoryName)
        {
            List<Product> products = new List<Product>();
            foreach (Product product in GetAllProducts())
            {
                if (product.SubCategoryId == FindSubcategoryId(subCategoryName))
                {
                    products.Add(product);
                }
            }

            return products;
        }
    
        public Product GetProduct(int productId)
        {
            foreach (Product product in GetAllProducts())   // GetAllProduct().Where(pr => pr.ProductId == productId)
            {
                if (product.ProductId == productId)
                {
                    return product;
                }
            }

            return null;
        }
    }
}
