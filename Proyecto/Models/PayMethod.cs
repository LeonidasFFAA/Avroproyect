using MySql.Data.MySqlClient;
using Proyecto.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class PayMethod : IPayMethod
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public PayMethod() { }
        public PayMethod(int id, string description)
        {
            Id = id;
            Description = description;
        }

        public void AddPayMethod()
        {
            throw new NotImplementedException();
        }

        public PayMethod GetPayMethod(int payMethodId)
        {
            try
            {
                PayMethod payMethod = new PayMethod();
                MySqlConnection conn = AvroDB.Connection();
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Formapago WHERE id LIKE '"+payMethodId+"';", conn);
                object obj = cmd.ExecuteScalar();
                if (Convert.ToInt32(obj) != 0)
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            payMethod.Id = Convert.ToInt32(reader["id"]);
                            payMethod.Description = Convert.ToString((string)reader["descripcion"]);
                        }
                    }
                    conn.Close();
                    return payMethod;
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