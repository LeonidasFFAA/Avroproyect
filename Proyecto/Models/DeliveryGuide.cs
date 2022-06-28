using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class DeliveryGuide
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime Expiration { get; set; }
        public User user { get; set; }
        public PayMethod payMethod { get; set; }
        public DeliveryGuide() { }
        public DeliveryGuide(int id, DateTime date, DateTime expiration, User user, PayMethod payMethod)
        {
            Id = id;
            Date = date;
            Expiration = expiration;
            this.user = user;
            this.payMethod = payMethod;
        }
    }
}