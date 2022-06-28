using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Models.DAO
{
    internal interface IMaintenance
    {
        bool AddMaintenance(Maintenance maintenance);
        void ModifyMaintenance(Maintenance maintenance);
        Maintenance GetMaintenance(int id);

    }
}
