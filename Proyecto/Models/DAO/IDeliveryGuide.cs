using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Models.DAO
{
    internal interface IDeliveryGuide
    {
        bool AddDeliveryGuide(DeliveryGuide deliveryGuide);
        void DeleteDeliveryGuide(int deliveryGuideId);
        void ModifyDeliveryGuide(int deliveryGuideId);
        DeliveryGuide GetDeliveryGuide(int deliveryGuideId);

    }
}
