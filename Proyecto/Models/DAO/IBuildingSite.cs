using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Models.DAO
{
    internal interface IBuildingSite
    {
        bool AddBuildingSite(BuildingSite buildingSite);
        void DeleteBuildingSite(int buildingSiteId);
        void ModifyBuildingSite(int buildingSiteId);
        BuildingSite GetBuildingSite(int buildingSiteId);
    }
}
