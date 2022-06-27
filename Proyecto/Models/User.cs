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

        public User(int Id, string Name, string Rut, string Password, int Phone, string Mail, Role Role) 
        {
            this.Id = Id;
            this.Name = Name;
            this.Rut = Rut;
            this.Password = Password;
            this.Phone = Phone;
            this.Mail = Mail;
            this.Role = Role;
        }
        public User() { }

        public User StartSession(string email, string password)
        {
            try
            {
                User user = new User();
                Role role = new Role();
                MySqlConnection conn = AvroDB.Conexion();
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Usuario WHERE correo LIKE '" + email + "' AND clave LIKE '" + password + "';", conn);
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
                        user.Role = role.SearchRoleById(Convert.ToInt32(reader["Rol_id"])); // Envia el parámetro recibido de ID hacia el método de búsqueda de ROL
                    }
                }
                conn.Close();
                return user;
            }
            catch (Exception)
            {
                throw;
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