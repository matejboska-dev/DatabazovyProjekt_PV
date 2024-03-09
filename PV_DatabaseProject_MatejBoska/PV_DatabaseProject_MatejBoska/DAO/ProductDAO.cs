using PV_DatabaseProject_MatejBoska.Interfaces;
using PV_DatabaseProject_MatejBoska.Singleton;
using PV_DatabaseProject_MatejBoska.Tabulky;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV_DatabaseProject_MatejBoska.DAO
{
    internal class ProductDAO : IDAO<Product>
    {
        public string TableName => "Products";

        public void Delete(Product product)
        {
            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                using (SqlCommand command = new SqlCommand($"DELETE FROM {TableName} WHERE product_id = @id", conn))
                {
                    command.Parameters.AddWithValue("@id", product.ProductID);
                    command.ExecuteNonQuery();
                    product.ProductID = 0;
                }
            }
        }

        public IEnumerable<Product> GetAll()
        {
            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                using (SqlCommand command = new SqlCommand($"SELECT * FROM {TableName}", conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new Product
                            {
                                ProductID = Convert.ToInt32(reader["product_id"]),
                                ProductName = reader["product_name"].ToString(),
                                Price = Convert.ToSingle(reader["price"]),
                                StockQuantity = Convert.ToInt32(reader["stock_quantity"]),
                                CategoryID = Convert.ToInt32(reader["category_id"])
                            };

                            yield return product;
                        }
                    }
                }
            }
        }

        public Product GetByID(int id)
        {
            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                using (SqlCommand command = new SqlCommand($"SELECT * FROM {TableName} WHERE product_id = @id", conn))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Product
                            {
                                ProductID = Convert.ToInt32(reader["product_id"]),
                                ProductName = reader["product_name"].ToString(),
                                Price = Convert.ToSingle(reader["price"]),
                                StockQuantity = Convert.ToInt32(reader["stock_quantity"]),
                                CategoryID = Convert.ToInt32(reader["category_id"])
                            };
                        }
                        return null;
                    }
                }
            }
        }

        public void Save(Product product)
        {
            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;

                    if (product.ProductID < 1)
                    {
                        command.CommandText = $"INSERT INTO {TableName} (product_name, price, stock_quantity, category_id) " +
                                              "VALUES (@name, @price, @stock_quantity, @category_id); " +
                                              "SELECT SCOPE_IDENTITY();";

                        command.Parameters.AddWithValue("@name", product.ProductName);
                        command.Parameters.AddWithValue("@price", product.Price);
                        command.Parameters.AddWithValue("@stock_quantity", product.StockQuantity);
                        command.Parameters.AddWithValue("@category_id", product.CategoryID);

                        product.ProductID = Convert.ToInt32(command.ExecuteScalar());
                    }
                    else
                    {
                        command.CommandText = $"UPDATE {TableName} SET product_name = @name, " +
                                              "price = @price, stock_quantity = @stock_quantity, " +
                                              "category_id = @category_id WHERE product_id = @id;";

                        command.Parameters.AddWithValue("@id", product.ProductID);
                        command.Parameters.AddWithValue("@name", product.ProductName);
                        command.Parameters.AddWithValue("@price", product.Price);
                        command.Parameters.AddWithValue("@stock_quantity", product.StockQuantity);
                        command.Parameters.AddWithValue("@category_id", product.CategoryID);

                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
