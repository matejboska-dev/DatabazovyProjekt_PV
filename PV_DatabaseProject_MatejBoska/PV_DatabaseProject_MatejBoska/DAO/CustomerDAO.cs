
using PV_DatabaseProject_MatejBoska.Interfaces;
using PV_DatabaseProject_MatejBoska.Singleton;
using PV_DatabaseProject_MatejBoska.Tabulky;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PV_DatabaseProject_MatejBoska.DAO
{
    internal class CustomerDAO : IDAO<Customer>
    {
        public string TableName => "Customers";

        public void Delete(Customer customer)
        {
            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                using (SqlCommand command = new SqlCommand($"DELETE FROM {TableName} WHERE customer_id = @id", conn))
                {
                    command.Parameters.AddWithValue("@id", customer.CustomerID);
                    command.ExecuteNonQuery();
                    customer.CustomerID = 0;
                }
            }
        }

        public IEnumerable<Customer> GetAll()
        {
            List<Customer> customers = new List<Customer>();

            try
            {
                using (SqlConnection conn = DatabaseSingleton.GetInstance())
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    using (SqlCommand command = new SqlCommand($"SELECT * FROM {TableName}", conn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer customer = new Customer
                                {
                                    CustomerID = Convert.ToInt32(reader["customer_id"]),
                                    FirstName = reader["first_name"].ToString(),
                                    LastName = reader["last_name"].ToString(),
                                    Email = reader["email"].ToString(),
                                    PhoneNumber = reader["phone_number"].ToString()
                                };
                                customers.Add(customer);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                Console.WriteLine($"Error in GetAll: {ex.Message}");
            }

            return customers;
        }


        public Customer GetByID(int id)
        {
            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                using (SqlCommand command = new SqlCommand($"SELECT * FROM {TableName} WHERE customer_id = @id", conn))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Customer
                            {
                                CustomerID = Convert.ToInt32(reader["customer_id"]),
                                FirstName = reader["first_name"].ToString(),
                                LastName = reader["last_name"].ToString(),
                                Email = reader["email"].ToString(),
                                PhoneNumber = reader["phone_number"].ToString()
                            };
                        }
                        return null;
                    }
                }
            }
        }

        public void Save(Customer customer)
        {
            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;

                    if (customer.CustomerID < 1)
                    {
                        command.CommandText = $"INSERT INTO {TableName} (first_name, last_name, email, phone_number) " +
                                              "VALUES (@first_name, @last_name, @email, @phone_number); " +
                                              "SELECT SCOPE_IDENTITY();";

                        command.Parameters.AddWithValue("@first_name", customer.FirstName);
                        command.Parameters.AddWithValue("@last_name", customer.LastName);
                        command.Parameters.AddWithValue("@email", customer.Email);
                        command.Parameters.AddWithValue("@phone_number", customer.PhoneNumber);

                        customer.CustomerID = Convert.ToInt32(command.ExecuteScalar());
                    }
                    else
                    {
                        command.CommandText = $"UPDATE {TableName} SET first_name = @first_name, " +
                                              "last_name = @last_name, email = @email, phone_number = @phone_number " +
                                              "WHERE customer_id = @id;";

                        command.Parameters.AddWithValue("@id", customer.CustomerID);
                        command.Parameters.AddWithValue("@first_name", customer.FirstName);
                        command.Parameters.AddWithValue("@last_name", customer.LastName);
                        command.Parameters.AddWithValue("@email", customer.Email);
                        command.Parameters.AddWithValue("@phone_number", customer.PhoneNumber);

                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
