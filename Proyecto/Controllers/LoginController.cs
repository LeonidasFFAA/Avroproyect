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
            string email = formObj["email"];
            string password= formObj["password"];
            if(AccessQuery(email, password))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // Método que ejecuta la consulta en base de datos para comprobar si existe el usuario.
        protected bool AccessQuery(string email, string password)
        {
            MySqlConnection conn = AvroDB.Conexion();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Usuario WHERE email LIKE " + email + " AND password LIKE " + password + ";", conn);
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}