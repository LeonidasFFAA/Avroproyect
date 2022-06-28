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

        public Tool SearchTool(int idTool)
        {
            throw new NotImplementedException();
        }
    }
}