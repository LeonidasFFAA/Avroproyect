using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Models.DAO
{
    internal interface ICommune
    {
        bool AddCommune(Commune commune);
        void DeleteCommune(int communeId);
        void ModifyCommune(int communeId);
        Commune GetCommune(int communeId);
    }
}
