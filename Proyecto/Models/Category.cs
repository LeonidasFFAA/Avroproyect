using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Prize { get; set; }
        public Category() { }
        public Category(int id, string description, int prize)
        {
            Id = id;
            Description = description;
            Prize = prize;
        }

        public static Category GetCategory(int categoryId)
        {
            try
            {
                Category category = new Category();
                MySqlConnection conn = AvroDB.Connection();
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Categoria WHERE id LIKE '" + categoryId + "';", conn);
                object obj = cmd.ExecuteScalar();
                if (Convert.ToInt32(obj) != 0)
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            category.Id = Convert.ToInt32(reader["id"]);
                            category.Description = Convert.ToString((string)reader["descripcion"]);
                            category.Prize = Convert.ToInt32(reader["precio"]);
                        }
                    }
                    conn.Close();
                    return category;
                }
                else
                {
                    return null;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }
    }
}