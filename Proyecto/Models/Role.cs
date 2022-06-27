using MySql.Data.MySqlClient;
using Proyecto.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{

    public class Role : IRole
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Role SearchRoleById(int Id)
        {
            Role role = new Role();
            try
            {
                MySqlConnection conn = AvroDB.Conexion();
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Rol WHERE id LIKE '" + Id+ "';", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        role.Id = Convert.ToInt32(reader["id"]);
                        role.Description = Convert.ToString((string)reader["descripcion"]);
                    }
                }
                conn.Close();
                return role;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}