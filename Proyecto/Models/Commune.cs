using Proyecto.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Commune : ICommune
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Region Region { get; set; }
        public Commune() { }
        public Commune(int id, string name, Region region)
        {
            Id = id;
            Name = name;
            Region = region;
        }

        public bool AddCommune(Commune commune)
        {
            throw new NotImplementedException();
        }

        public void DeleteCommune(int communeId)
        {
            throw new NotImplementedException();
        }

        public void ModifyCommune(int communeId)
        {
            throw new NotImplementedException();
        }

        public Commune GetCommune(int communeId)
        {
            throw new NotImplementedException();
        }
    }
}