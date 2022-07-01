using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Models.DAO
{
    internal interface ITool
    {
        bool AddTool(Tool tool);
        void RemoveTool(int idTool);
        void DisableTool(int idTool);
        void ModifyTool(Tool tool);
        void DeleteTool(int idTool);
        Tool GetTool(int idTool);
    }
}
