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
    }
}