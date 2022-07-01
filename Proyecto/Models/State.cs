using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class State
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public State() { }
        public State(int id, string description)
        {
            Id = id;
            Description = description;
        }

        public static State GetState(int stateId)
        {
            try
            {
                State state = new State();
                MySqlConnection conn = AvroDB.Connection();
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Estado WHERE id LIKE '" + stateId+ "';", conn);
                object obj = cmd.ExecuteScalar();
                if (Convert.ToInt32(obj) != 0)
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            state.Id = Convert.ToInt32(reader["id"]);
                            state.Description = Convert.ToString((string)reader["descripcion"]);
                        }                        
                    }
                    conn.Close();
                    return state;
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