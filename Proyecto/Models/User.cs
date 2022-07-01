using MySql.Data.MySqlClient;
using Proyecto.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class User : IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Rut { get; set; }
        public string Password { get; set; }
        public int Phone { get; set; }
        public string Mail { get; set; }
        public Role Role { get; set; }

        public User(int id, string name, string rut, string password, int phone, string mail, Role role) 
        {
            Id = id;
            Name = name;
            Rut = rut;
            Password = password;
            Phone = phone;
            Mail = mail;
            Role = role;
        }
        public User() { }

        public User StartSession(string email, string password)
        {
            try
            {
                User user = new User();
                Role role = new Role();
                MySqlConnection conn = AvroDB.Connection();
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Usuario WHERE correo LIKE '" + email + "' AND clave LIKE '" + password + "';", conn);
                object obj = cmd.ExecuteScalar();
                if (Convert.ToInt32(obj) != 0)
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            user.Id = Convert.ToInt32(reader["id"]);
                            user.Name = Convert.ToString((string)reader["nombre"]);
                            user.Rut = Convert.ToString((string)reader["rut"]);
                            user.Password = Convert.ToString((string)reader["clave"]);
                            user.Phone = Convert.ToInt32(reader["fono"]);
                            user.Mail = Convert.ToString((string)reader["correo"]);
                            user.Role = role.SearchRole(Convert.ToInt32(reader["Rol_id"])); // Envia el parámetro recibido de ID hacia el método de búsqueda de ROL
                        }
                    }
                    conn.Close();
                    return user;
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

        public void StopSession()
        {
            throw new NotImplementedException();
        }

        public User SeeInformation()
        {
            throw new NotImplementedException();
        }
    }
}