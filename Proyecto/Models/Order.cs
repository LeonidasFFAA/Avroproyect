using Proyecto.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Order : IOrder
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DeliveryGuide DeliveryGuide { get; set; }
        public Tool Tool { get; set; }
        public ConstructionCompany ConstructionCompany { get; set; }
        public Order() { }
        public Order(int id, string description, DeliveryGuide deliveryGuide, Tool tool, ConstructionCompany constructionCompany)
        {
            Id = id;
            Description = description;
            DeliveryGuide = deliveryGuide;
            Tool = tool;
            ConstructionCompany = constructionCompany;
        }

        public bool AddOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public void ModifyOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public Order GetOrder(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}