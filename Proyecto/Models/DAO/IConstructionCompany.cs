using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Models.DAO
{
    internal interface IConstructionCompany
    {
        bool AddConstructionCompany(ConstructionCompany constructionCompany);
        void DeleteConstructionCompany(int constructionCompanyId);
        void ModifyConstructionCompany(int constructionCompanyId);
        ConstructionCompany GetConstructionCompany(int constructionCompanyId);

    }
}
