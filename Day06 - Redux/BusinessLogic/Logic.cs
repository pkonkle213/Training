using CardsAgain.DAOs;
using CardsAgain.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Logic : ILogic
    {
        private string connection;

        public Logic(string connectionstring)
        {
            this.connection = connectionstring;
        }
        public Product GetProduct(int productId)
        {
            Product product = null;
            string sql = "SELECT ProductID, ProductSubcategoryID, Name, Color, ListPrice " +
                "FROM Production.Product " +
                "WHERE ProductID = @productId";

            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@productId", productId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            product =
                                new Product(
                                    Convert.ToInt32(reader["ProductID"]),
                                    Convert.ToInt32(reader["ProductSubcategoryID"]),
                                    Convert.ToString(reader["Name"]),
                                    Convert.ToString(reader["Color"]),
                                    Convert.ToDecimal(reader["ListPrice"])
                                );
                        }
                    }
                }
            }

            return product;
        }

        public IEnumerable<ProductCategory> GetProductCategories()
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

            return allCategories;
        }

        public IEnumerable<Product> GetProducts(int subCategoryId, decimal? lowPrice = decimal.MinValue, decimal? highPrice = decimal.MaxValue)
        {
            List<Product> allProducts = new List<Product>();
            string sql = "SELECT ProductID, ProductSubcategoryID, Name, Color, ListPrice " +
                "FROM Production.Product " +
                "WHERE (ProductSubcategoryID = @subCategoryId) AND (Color IS NOT NULL) AND (@lowPrice <= ListPrice) AND (ListPrice <= @highPrice)";

            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@subCategoryId", subCategoryId);
                    command.Parameters.AddWithValue("@lowPrice", lowPrice);
                    command.Parameters.AddWithValue("@highPrice", highPrice);

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

        public IEnumerable<ProductSubCategory> GetProductSubCategories(int categoryId, string nameStartsWith = "")
        {
            List<ProductSubCategory> allSubCategories = new List<ProductSubCategory>();
            string sql = "SELECT ProductSubcategoryID, ProductCategoryID, Name " +
                "FROM Production.ProductSubcategory " +
                "WHERE(ProductCategoryID = @categoryId) AND(Name LIKE '@nameStartsWith%')";

            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@categoryId", categoryId);
                    command.Parameters.AddWithValue("@nameStartsWith", nameStartsWith);

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
    }
}
