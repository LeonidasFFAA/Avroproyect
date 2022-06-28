using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Models.DAO
{
    internal interface IAddress
    {
        bool AddAddress(Address address);
        void DeleteAddress(int addressId);
        void ModifyAddress(int addressId);
        Address GetAddress(int addressId);
    }
}
