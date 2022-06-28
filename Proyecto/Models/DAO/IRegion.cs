using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Models.DAO
{
    internal interface IRegion
    {
        bool AddRegion(Region region);
        void DeleteRegion(int regionId);
        void ModifyRegion(Region region);
        Region GetRegion(int regionId);
    }
}
