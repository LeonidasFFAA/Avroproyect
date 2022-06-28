using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Models.DAO
{
    internal interface IOrder
    {
        bool AddOrder(Order order);
        void DeleteOrder(int orderId);
        void ModifyOrder(int orderId);
        Order GetOrder(int orderId);
    }
}
