using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection formObj)
        {
            User user = new User();
            string email = formObj["email"];
            string password= formObj["password"];
            user = user.StartSession(email, password);
            if(user!=null)
            {
                if (user.Role.Id == 2)
                {
                    return RedirectToAction("Menu", "ChiefMenu");
                } else if (user.Role.Id == 3)
                {
                    return RedirectToAction("Index"); //Debe redirigir a las vistas de técnico
                }
            }
            return RedirectToAction("Index");
        }
    }
}