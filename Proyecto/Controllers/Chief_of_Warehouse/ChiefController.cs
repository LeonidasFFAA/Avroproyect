using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Controllers.Chief_of_Warehouse
{
    public class ChiefController : Controller
    {
        // GET: ChiefMenu
        public ActionResult Menu()
        {
            return View();
        }

        public ActionResult Rent()
        {
            //Obtenemos la lista de las constructoras para ingresarlas a la vista
            ConstructionCompany constructionCompany = new ConstructionCompany();
            constructionCompany.constructionCompanies = ConstructionCompany.GetConstructionCompanies();
            return View(constructionCompany);
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