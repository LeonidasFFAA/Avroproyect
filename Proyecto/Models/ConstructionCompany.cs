using Proyecto.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class ConstructionCompany : IConstructionCompany
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Rut { get; set; }
        public string Order { get; set; }
        public ConstructionCompany() { }
        public ConstructionCompany(int id, string name, string rut, string order)
        {
            Id = id;
            Name = name;
            Rut = rut;
            Order = order;
        }

        public bool AddConstructionCompany(ConstructionCompany constructionCompany)
        {
            throw new NotImplementedException();
        }

        public void DeleteConstructionCompany(int constructionCompanyId)
        {
            throw new NotImplementedException();
        }

        public void ModifyConstructionCompany(int constructionCompanyId)
        {
            throw new NotImplementedException();
        }

        public ConstructionCompany GetConstructionCompany(int constructionCompanyId)
        {
            throw new NotImplementedException();
        }
    }
}