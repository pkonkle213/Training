using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TrainingApp.Models;

namespace TrainingApp.DAOs
{
    // a class like this should be in a separate project
    public class DAO
    {
        private string connection = "Data Source=USC-W-CRCTV93-A;Initial Catalog=AdventureWorks2019;Integrated Security=True";

        // it's best to return a more generic type. in this case, you could define IEnumerable<string> as the return type and a list (or even better, list.ToArray()) could be returned.
        // IEnumerable returns an immutable collection, that cannot be added to
        public List<string> GetColors()
        {
            List<string> colors = new List<string>();

            // I like that you capitalize SQL command/reserved words
            // if you use the @ in front of your string, you can have a single string that spans multiple lines without needing to concatenate
            string sql = "SELECT DISTINCT Color " +
                "FROM Production.Product " +
                "WHERE Color IS NOT NULL";

            // really nice that you're using the 'using' block (using the using is from the Department of Redundancy Department)
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // avoid using the Convert functions. They were implemented as a means of converting from VB 6.
                            colors.Add(Convert.ToString(reader["Color"]));  // in this instance, I think you could just say .Add(reader["Color"].ToString()
                        }
                    }
                }
            }

            return colors;
        }

        public List<string> GetProducts(string color)
        {
            List<string> products = new List<string>();

            if (color != null)
            {
                string sql = "SELECT Name " +
                    "FROM Production.Product " +
                    "WHERE Color = @Color";

                using (SqlConnection conn = new SqlConnection(connection))
                {
                    conn.Open();

                    using (SqlCommand command = new SqlCommand(sql, conn))
                    {
                        command.Parameters.AddWithValue("@Color", color);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                products.Add(Convert.ToString(reader["Name"]));
                            }
                        }
                    }
                }
            }
            else
            {
                products.Add("No color selected");
            }

            // avoid having excessive blank space
            return products;
        }

        public List<WorkLoad> GetWorkLoads(string name)
        {
            List<WorkLoad> workLoads = new List<WorkLoad>();

            string sql = "SELECT w.StartDate, w.DueDate, w.OrderQty " +
                "FROM Production.WorkOrder w " +
                "INNER JOIN Production.Product p ON p.ProductID = w.ProductID " +
                "WHERE p.Name = @ProductName";

            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@ProductName", name);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            WorkLoad workLoad = new WorkLoad();

                            workLoad.StartDate = Convert.ToDateTime(reader["StartDate"]);
                            workLoad.DueDate = Convert.ToDateTime(reader["DueDate"]);
                            workLoad.OrderQty = Convert.ToInt32(reader["OrderQty"]);

                            workLoads.Add(workLoad);
                        }
                    }
                }
            }

            return workLoads;
        }

    }
}