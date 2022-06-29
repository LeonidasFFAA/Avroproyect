using MySql.Data.MySqlClient;
using Proyecto.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Models
{
    public class ConstructionCompany : IConstructionCompany
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Rut { get; set; }
        public string Order { get; set; }
        public SelectList constructionCompanies { get; set; }
        public ConstructionCompany() { }
        public ConstructionCompany(int id, string name, string rut, string order)
        {
            Id = id;
            Name = name;
            Rut = rut;
            Order = order;
        }

        public bool AddConstructionCompany(ConstructionCompany constructionCompany)
        {
            throw new NotImplementedException();
        }

        public void DeleteConstructionCompany(int constructionCompanyId)
        {
            throw new NotImplementedException();
        }

        public void ModifyConstructionCompany(int constructionCompanyId)
        {
            throw new NotImplementedException();
        }

        public ConstructionCompany GetConstructionCompany(int constructionCompanyId)
        {
            throw new NotImplementedException();
        }
        //Obtención de una lista de las Constructoras desde la base de datos
        public static SelectList GetConstructionCompanies()
        {
            List<ConstructionCompany> constructionCompanies = new List<ConstructionCompany>();
            try
            {
                MySqlConnection conn = AvroDB.Connection();
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Constructora;", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var constructionCompanyItem = new ConstructionCompany
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Name = Convert.ToString(reader["nombre"]),
                            Rut = Convert.ToString(reader["rut"]),
                            Order = Convert.ToString(reader["giro"])
                        };
                        constructionCompanies.Add(constructionCompanyItem);
                    }
                }
                conn.Close();
                ConstructionCompany constructionCompany = new ConstructionCompany
                {
                    constructionCompanies = new SelectList(constructionCompanies)
                };
                return constructionCompany.constructionCompanies;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        } 
    }
}