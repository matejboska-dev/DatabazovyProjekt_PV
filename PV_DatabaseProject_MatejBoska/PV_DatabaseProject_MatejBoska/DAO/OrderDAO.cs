
using PV_DatabaseProject_MatejBoska.Interfaces;
using PV_DatabaseProject_MatejBoska.Singleton;
using PV_DatabaseProject_MatejBoska.Tabulky;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PV_DatabaseProject_MatejBoska.DAO
{
    internal class OrderDAO : IDAO<Order>
    {
        public string TableName => "Orders";

        public void Delete(Order order)
        {
            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                using (SqlCommand command = new SqlCommand($"DELETE FROM {TableName} WHERE order_id = @id", conn))
                {
                    command.Parameters.AddWithValue("@id", order.OrderID);
                    command.ExecuteNonQuery();
                    order.OrderID = 0;
                }
            }
        }

        public IEnumerable<Order> GetAll()
        {
            List<Order> orders = new List<Order>();

            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                using (SqlCommand command = new SqlCommand($"SELECT * FROM {TableName}", conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Order order = new Order
                            {
                                OrderID = Convert.ToInt32(reader["order_id"]),
                                CustomerID = Convert.ToInt32(reader["customer_id"]),
                                OrderDate = Convert.ToDateTime(reader["order_date"])
                            };
                            orders.Add(order);
                        }
                    }
                }
            }

            return orders;
        }


        public Order GetByID(int id)
        {
            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                using (SqlCommand command = new SqlCommand($"SELECT * FROM {TableName} WHERE order_id = @id", conn))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Order
                            {
                                OrderID = Convert.ToInt32(reader["order_id"]),
                                CustomerID = Convert.ToInt32(reader["customer_id"]),
                                OrderDate = Convert.ToDateTime(reader["order_date"])
                            };
                        }
                        return null;
                    }
                }
            }
        }

        public void Save(Order order)
        {
            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;

                    if (order.OrderID < 1)
                    {
                        command.CommandText = $"INSERT INTO {TableName} (customer_id, order_date) VALUES (@customer_id, @order_date); SELECT SCOPE_IDENTITY();";

                        command.Parameters.AddWithValue("@customer_id", order.CustomerID);
                        command.Parameters.AddWithValue("@order_date", order.OrderDate);

                        order.OrderID = Convert.ToInt32(command.ExecuteScalar());
                    }
                    else
                    {
                        command.CommandText = $"UPDATE {TableName} SET customer_id = @customer_id, order_date = @order_date WHERE order_id = @id;";

                        command.Parameters.AddWithValue("@id", order.OrderID);
                        command.Parameters.AddWithValue("@customer_id", order.CustomerID);
                        command.Parameters.AddWithValue("@order_date", order.OrderDate);

                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
