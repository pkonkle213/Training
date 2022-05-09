using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TrainingApp.Models;

namespace TrainingApp.DAOs
{
    public class DAO
    {
        private string connection = "Data Source=USC-W-CRCTV93-A;Initial Catalog=AdventureWorks2019;Integrated Security=True";

        public List<string> GetColors()
        {
            List<string> colors = new List<string>();

            string sql = "SELECT DISTINCT Color " +
                "FROM Production.Product " +
                "WHERE Color IS NOT NULL";

            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            colors.Add(Convert.ToString(reader["Color"]));
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