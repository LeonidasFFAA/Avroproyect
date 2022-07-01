using MySql.Data.MySqlClient;
using Proyecto.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class BuildingSite : IBuildingSite
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public Address Address { get; set; }
        public ConstructionCompany ConstructionCompany { get; set; }
        public BuildingSite() { }
        public BuildingSite(int id, string name, int phone, Address address, ConstructionCompany constructionCompany)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Address = address;
            ConstructionCompany = constructionCompany;
        }

        public bool AddBuildingSite(BuildingSite buildingSite)
        {
            throw new NotImplementedException();
        }

        public void DeleteBuildingSite(int buildingSiteId)
        {
            throw new NotImplementedException();
        }

        public void ModifyBuildingSite(int buildingSiteId)
        {
            throw new NotImplementedException();
        }

        public BuildingSite GetBuildingSite(int buildingSiteId)
        {
            //try
            //{
            //    BuildingSite buildingSite = new BuildingSite();
            //    MySqlConnection conn = AvroDB.Connection();
            //    conn.Open();
            //    MySqlCommand cmd = new MySqlCommand("SELECT * FROM Constructora WHERE id LIKE '"+buildingSiteId+"';", conn);
            //    object obj = cmd.ExecuteScalar();
            //    if (Convert.ToInt32(obj) != 0)
            //    {
            //        using (var reader = cmd.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {
            //                buildingSite.Id = Convert.ToInt32(reader["id"]);
            //                buildingSite.Name = Convert.ToString((string)reader["nombre"]);
            //                buildingSite.Phone = Convert.ToString((string)reader["rut"]);
            //                buildingSite.Password = Convert.ToString((string)reader["clave"]);
            //                buildingSite.Phone = Convert.ToInt32(reader["fono"]);
            //                buildingSite.Mail = Convert.ToString((string)reader["correo"]);
            //                buildingSite.Role = role.SearchRole(Convert.ToInt32(reader["Rol_id"])); // Envia el parámetro recibido de ID hacia el método de búsqueda de ROL
            //            }
            //        }
            //        conn.Close();
            //        return buildingSite;
            //    }
            //    else
            //    {
            //        return null;
            //    }
            //}
            //catch (MySqlException ex)
            //{
            //    Console.WriteLine("Error: " + ex.Message);
                return null;
            //}
        }
    }
}