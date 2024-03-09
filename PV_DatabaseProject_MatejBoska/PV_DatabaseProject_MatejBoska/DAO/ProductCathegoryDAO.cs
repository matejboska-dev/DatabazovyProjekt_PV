
using PV_DatabaseProject_MatejBoska.Interfaces;
using PV_DatabaseProject_MatejBoska.Singleton;
using PV_DatabaseProject_MatejBoska.Tabulky;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PV_DatabaseProject_MatejBoska.DAO
{
    internal class ProductCategoryDAO : IDAO<ProductCategory>
    {
        public string TableName => "ProductCategories";

        public void Delete(ProductCategory category)
        {
            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                using (SqlCommand command = new SqlCommand($"DELETE FROM {TableName} WHERE category_id = @id", conn))
                {
                    command.Parameters.AddWithValue("@id", category.CategoryID);
                    command.ExecuteNonQuery();
                    category.CategoryID = 0;
                }
            }
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                using (SqlCommand command = new SqlCommand($"SELECT * FROM {TableName}", conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProductCategory category = new ProductCategory
                            {
                                CategoryID = Convert.ToInt32(reader["category_id"]),
                                CategoryName = reader["category_name"].ToString()
                            };
                            yield return category;
                        }
                    }
                }
            }
        }

        public ProductCategory GetByID(int id)
        {
            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                using (SqlCommand command = new SqlCommand($"SELECT * FROM {TableName} WHERE category_id = @id", conn))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new ProductCategory
                            {
                                CategoryID = Convert.ToInt32(reader["category_id"]),
                                CategoryName = reader["category_name"].ToString()
                            };
                        }
                        return null;
                    }
                }
            }
        }

        public void Save(ProductCategory category)
        {
            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;

                    if (category.CategoryID < 1)
                    {
                        command.CommandText = $"INSERT INTO {TableName} (category_name) VALUES (@name); SELECT SCOPE_IDENTITY();";

                        command.Parameters.AddWithValue("@name", category.CategoryName);

                        category.CategoryID = Convert.ToInt32(command.ExecuteScalar());
                    }
                    else
                    {
                        command.CommandText = $"UPDATE {TableName} SET category_name = @name WHERE category_id = @id;";

                        command.Parameters.AddWithValue("@id", category.CategoryID);
                        command.Parameters.AddWithValue("@name", category.CategoryName);

                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
