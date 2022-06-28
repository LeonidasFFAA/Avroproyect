using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Category() { }
        public Category(int id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}