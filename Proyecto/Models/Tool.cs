using MySql.Data.MySqlClient;
using Proyecto.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Tool : ITool
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime LastModifyDate { get; set; }
        public string Observation { get; set; }
        public Category Category { get; set; }
        public State State { get; set; }
        public Tool() { }
        public Tool(int id, string name, string brand, DateTime entryDate, DateTime lastModifyDate, string observation, Category category, State state)
        {
            Id = id;
            Name = name;
            Brand = brand;
            EntryDate = entryDate;
            LastModifyDate = lastModifyDate;
            Observation = observation;
            Category = category;
            State = state;
        }

        public bool AddTool(Tool tool)
        {
            throw new NotImplementedException();
        }

        public void RemoveTool(int idTool)
        {
            throw new NotImplementedException();
        }

        public void DisableTool(int idTool)
        {
            throw new NotImplementedException();
        }

        public void ModifyTool(Tool tool)
        {
            throw new NotImplementedException();
        }

        public void DeleteTool(int idTool)
        {
            throw new NotImplementedException();
        }

        public Tool GetTool(int idTool)
        {
            try
            {
                Tool tool = new Tool();
                MySqlConnection conn = AvroDB.Connection();
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Herramienta WHERE id LIKE '" + idTool + "';", conn);
                object obj = cmd.ExecuteScalar();
                if (Convert.ToInt32(obj) != 0)
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tool.Id = Convert.ToInt32(reader["id"]);
                            tool.Name = Convert.ToString((string)reader["nombre"]);
                            tool.Brand = Convert.ToString((string)reader["marca"]);
                            //tool.EntryDate = Convert.ToDateTime(reader["fechaingreso"]);
                            //tool.LastModifyDate = Convert.ToDateTime(reader["ultima_modificacion"]);
                            //tool.Observation = Convert.ToString((string)reader["observacion"]);
                            tool.Category = Category.GetCategory(Convert.ToInt32(reader["Categoria_id"]));
                            tool.State = State.GetState(Convert.ToInt32(reader["Estado_id"]));
                        }
                    }
                    conn.Close();
                    return tool;
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