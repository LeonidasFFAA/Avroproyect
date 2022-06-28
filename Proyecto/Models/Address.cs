using Proyecto.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Address : IAddress
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Commune Commune { get; set; }

        public bool AddAddress(Address address)
        {
            throw new NotImplementedException();
        }

        public void DeleteAddress(int addressId)
        {
            throw new NotImplementedException();
        }

        public Address GetAddress(int addressId)
        {
            throw new NotImplementedException();
        }

        public void ModifyAddress(int addressId)
        {
            throw new NotImplementedException();
        }
    }
}