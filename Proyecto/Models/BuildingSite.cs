using Proyecto.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class BuildingSite : IBuildingSite
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public Address Address { get; set; }
        public ConstructionCompany ConstructionCompany { get; set; }
        public BuildingSite() { }
        public BuildingSite(int id, string name, int phone, Address address, ConstructionCompany constructionCompany)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Address = address;
            ConstructionCompany = constructionCompany;
        }

        public bool AddBuildingSite(BuildingSite buildingSite)
        {
            throw new NotImplementedException();
        }

        public void DeleteBuildingSite(int buildingSiteId)
        {
            throw new NotImplementedException();
        }

        public void ModifyBuildingSite(int buildingSiteId)
        {
            throw new NotImplementedException();
        }

        public BuildingSite GetBuildingSite(int buildingSiteId)
        {
            throw new NotImplementedException();
        }
    }
}