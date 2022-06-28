using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class PayMethod
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public PayMethod() { }
        public PayMethod(int id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}