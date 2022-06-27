using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Models.DAO
{
    internal interface IUser
    {
        User StartSession(string email, string password);
        void StopSession();
        User SeeInformation();
    }
}
