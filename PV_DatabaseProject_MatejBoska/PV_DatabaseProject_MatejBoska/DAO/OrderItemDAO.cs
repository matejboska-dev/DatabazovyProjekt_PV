using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using PV_DatabaseProject_MatejBoska.Interfaces;
using PV_DatabaseProject_MatejBoska.Singleton;
using PV_DatabaseProject_MatejBoska.Tabulky;

namespace PV_DatabaseProject_MatejBoska.DAO
{
    internal class OrderItemDAO : IDAO<OrderItem>
    {
        public string TableName => "OrderItems";

        public void Delete(OrderItem orderItem)
        {
            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                using (SqlCommand command = new SqlCommand($"DELETE FROM {TableName} WHERE order_item_id = @id", conn))
                {
                    command.Parameters.AddWithValue("@id", orderItem.OrderItemID);
                    command.ExecuteNonQuery();
                    orderItem.OrderItemID = 0;
                }
            }
        }

        public IEnumerable<OrderItem> GetAll()
        {
            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                using (SqlCommand command = new SqlCommand($"SELECT * FROM {TableName}", conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            OrderItem orderItem = new OrderItem
                            {
                                OrderItemID = Convert.ToInt32(reader["order_item_id"]),
                                OrderID = Convert.ToInt32(reader["order_id"]),
                                ProductID = Convert.ToInt32(reader["product_id"]),
                                Quantity = Convert.ToInt32(reader["quantity"]),
                                TotalPrice = Convert.ToSingle(reader["total_price"])
                            };
                            yield return orderItem;
                        }
                    }
                }
            }
        }

        public OrderItem GetByID(int id)
        {
            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                using (SqlCommand command = new SqlCommand($"SELECT * FROM {TableName} WHERE order_item_id = @id", conn))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new OrderItem
                            {
                                OrderItemID = Convert.ToInt32(reader["order_item_id"]),
                                OrderID = Convert.ToInt32(reader["order_id"]),
                                ProductID = Convert.ToInt32(reader["product_id"]),
                                Quantity = Convert.ToInt32(reader["quantity"]),
                                TotalPrice = Convert.ToSingle(reader["total_price"])
                            };
                        }
                        return null;
                    }
                }
            }
        }

        public void Save(OrderItem orderItem)
        {
            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;

                    if (orderItem.OrderItemID < 1)
                    {
                        command.CommandText = $"INSERT INTO {TableName} (order_id, product_id, quantity, total_price) " +
                                              "VALUES (@order_id, @product_id, @quantity, @total_price); " +
                                              "SELECT SCOPE_IDENTITY();";

                        command.Parameters.AddWithValue("@order_id", orderItem.OrderID);
                        command.Parameters.AddWithValue("@product_id", orderItem.ProductID);
                        command.Parameters.AddWithValue("@quantity", orderItem.Quantity);
                        command.Parameters.AddWithValue("@total_price", orderItem.TotalPrice);

                        orderItem.OrderItemID = Convert.ToInt32(command.ExecuteScalar());
                    }
                    else
                    {
                        command.CommandText = $"UPDATE {TableName} SET order_id = @order_id, " +
                                              "product_id = @product_id, quantity = @quantity, total_price = @total_price " +
                                              "WHERE order_item_id = @id;";

                        command.Parameters.AddWithValue("@id", orderItem.OrderItemID);
                        command.Parameters.AddWithValue("@order_id", orderItem.OrderID);
                        command.Parameters.AddWithValue("@product_id", orderItem.ProductID);
                        command.Parameters.AddWithValue("@quantity", orderItem.Quantity);
                        command.Parameters.AddWithValue("@total_price", orderItem.TotalPrice);

                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
