using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Controllers.Chief_of_Warehouse
{
    public class ChiefMenuController : Controller
    {
        // GET: ChiefMenu
        public ActionResult Menu()
        {
            return View();
        }

        public ActionResult Rent()
        {
            return View();
        }

        public ActionResult Change()
        {
            return View();
        }

        public ActionResult Finished()
        {
            return View();
        }

        public ActionResult Inventory()
        {
            return View();
        }

        public ActionResult DeliveryGuide()
        {
            return View();
        }
    }
}