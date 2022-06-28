using Proyecto.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Region : IRegion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Region() { }
        public Region(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public bool AddRegion(Region region)
        {
            throw new NotImplementedException();
        }

        public void DeleteRegion(int regionId)
        {
            throw new NotImplementedException();
        }

        public void ModifyRegion(Region region)
        {
            throw new NotImplementedException();
        }

        public Region GetRegion(int regionId)
        {
            throw new NotImplementedException();
        }
    }
}