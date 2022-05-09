using CardsAgain.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsAgain.DAOs
{
    public class DAOLogic : ILogic
    {
        private string connection;

        public DAOLogic(string connectionstring)
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

        public IEnumerable<Product> GetProducts(int subCategoryId, decimal? lowPrice = null, decimal? highPrice = null)
        {

            List<Product> allProducts = new List<Product>();
            string sql = "SELECT ProductID, ProductSubcategoryID, Name, Color, ListPrice " +
                "FROM Production.Product " +
                "WHERE (Color IS NOT NULL)";
            if(subCategoryId > 0)
            {
                sql += " AND (ProductSubcategoryID = @subCategoryId)";
            }

            if (lowPrice != null && highPrice != null)
            {
                if (lowPrice > highPrice)
                {
                    throw new ArithmeticException();
                }
            }

            if (lowPrice != null)
            {
                sql += " AND (@lowPrice <= ListPrice)";
            }

            if (highPrice != null)
            {
                sql+= " AND (ListPrice <= @highPrice)";
            }

            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@subCategoryId", subCategoryId);

                    if (lowPrice != null)
                    {
                        command.Parameters.AddWithValue("@lowPrice", lowPrice);
                    }

                    if (highPrice != null)
                    {
                        command.Parameters.AddWithValue("@highPrice", highPrice);
                    }

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

        public IEnumerable<ProductSubCategory> GetProductSubCategories(int categoryId, string nameStartsWith = null)
        {
            List<ProductSubCategory> allSubCategories = new List<ProductSubCategory>();
            string sql = "SELECT ProductSubcategoryID, ProductCategoryID, Name " +
                "FROM Production.ProductSubcategory ";

            if(categoryId > 0)
            {
                sql+="WHERE (ProductCategoryID = @categoryId)";
            }
                
            if (nameStartsWith != null)
            {
                sql += " AND (Name LIKE '@nameStartsWith%')";
            }
                
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    if (categoryId > 0)
                    {
                        command.Parameters.AddWithValue("@categoryId", categoryId);
                    }

                    if (nameStartsWith != null)
                    {
                        command.Parameters.AddWithValue("@nameStartsWith", nameStartsWith);
                    }

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
