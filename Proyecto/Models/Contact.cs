using Proyecto.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Contact : IContact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public Order Order { get; set; }
        public Contact() { }
        public Contact(int id, string name, int phone, Order order)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Order = order;
        }

        public void AddContact()
        {
            throw new NotImplementedException();
        }

        public void DeleteContact()
        {
            throw new NotImplementedException();
        }

        public Contact GetContact()
        {
            throw new NotImplementedException();
        }

        public void UpdateContact()
        {
            throw new NotImplementedException();
        }
    }
}