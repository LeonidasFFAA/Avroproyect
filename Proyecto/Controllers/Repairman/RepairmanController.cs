using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Controllers.Repairman
{
    public class RepairmanController : Controller
    {
        // GET: Repairman
        public ActionResult Menu()
        {
            return View();
        }
        public ActionResult DetailRep()
        {
            return View();
        }
        public ActionResult InventoryRep()
        {
            return View();
        }
        public ActionResult MaintenanceRep()
        {
            return View();
        }
    }
}