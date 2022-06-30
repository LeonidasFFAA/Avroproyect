using MySql.Data.MySqlClient;
using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
            //Agrgar lista de CONSTRUCTORAS a dropdownlist

            MySqlConnection con = Models.AvroDB.Connection();
            con.Open();
            using (MySqlCommand comando = new MySqlCommand("Select * from Constructora", con))
            {
                MySqlDataAdapter sda = new MySqlDataAdapter(comando);
                DataSet ds = new DataSet();
                sda.Fill(ds);

                ViewBag.Constructoras = ds.Tables[0];
                List<SelectListItem> getconstructioncompany = new List<SelectListItem>();
                foreach (System.Data.DataRow dr in ViewBag.Constructoras.Rows)
                {
                    getconstructioncompany.Add(new SelectListItem { Text = @dr["nombre"].ToString(), Value = @dr["id"].ToString() });
                }
                ViewBag.getconstructioncompany = getconstructioncompany;
            }

            //Agrgar lista de OBRAS a dropdownlist

            using (MySqlCommand comando = new MySqlCommand("Select * from Obra", con))
            {
                MySqlDataAdapter sda = new MySqlDataAdapter(comando);
                DataSet ds = new DataSet();
                sda.Fill(ds);

                ViewBag.Obras = ds.Tables[0];
                List<SelectListItem> getBuildingSite = new List<SelectListItem>();
                foreach (System.Data.DataRow dr in ViewBag.Obras.Rows)
                {
                    getBuildingSite.Add(new SelectListItem { Text = @dr["obra"].ToString(), Value = @dr["id"].ToString() });
                }
                ViewBag.getBuildingSite = getBuildingSite;
            }

            //Agrgar lista de CONTACTOS a dropdownlist

            using (MySqlCommand comando = new MySqlCommand("Select * from Contacto", con))
            {
                MySqlDataAdapter sda = new MySqlDataAdapter(comando);
                DataSet ds = new DataSet();
                sda.Fill(ds);

                ViewBag.Contactos = ds.Tables[0];
                List<SelectListItem> getContacts = new List<SelectListItem>();
                foreach (System.Data.DataRow dr in ViewBag.Contactos.Rows)
                {
                    getContacts.Add(new SelectListItem { Text = @dr["nombre"].ToString(), Value = @dr["id"].ToString() });
                }
                ViewBag.getContacts = getContacts;
            }

            //Agrgar lista de FORMAS DE PAGOS a dropdownlist

            using (MySqlCommand comando = new MySqlCommand("Select * from Formapago", con))
            {
                MySqlDataAdapter sda = new MySqlDataAdapter(comando);
                DataSet ds = new DataSet();
                sda.Fill(ds);

                ViewBag.Formapago = ds.Tables[0];
                List<SelectListItem> getPayMethod = new List<SelectListItem>();
                foreach (System.Data.DataRow dr in ViewBag.Formapago.Rows)
                {
                    getPayMethod.Add(new SelectListItem { Text = @dr["descripcion"].ToString(), Value = @dr["id"].ToString() });
                }
                ViewBag.getPayMethod = getPayMethod;
            }

            //Agrgar lista de CATEGORIAS DE HERRAMIENTAS a dropdownlist

            using (MySqlCommand comando = new MySqlCommand("Select * from Categoria", con))
            {
                MySqlDataAdapter sda = new MySqlDataAdapter(comando);
                DataSet ds = new DataSet();
                sda.Fill(ds);

                ViewBag.Categoria = ds.Tables[0];
                List<SelectListItem> getCategory = new List<SelectListItem>();
                foreach (System.Data.DataRow dr in ViewBag.Categoria.Rows)
                {
                    getCategory.Add(new SelectListItem { Text = @dr["descripcion"].ToString(), Value = @dr["id"].ToString() });
                }
                ViewBag.getCategory = getCategory;
            }

            //Agrgar lista de HERRAMIENTAS DISPONIBLES a dropdownlist

            using (MySqlCommand comando = new MySqlCommand("Select * from Herramienta", con))
            {
                MySqlDataAdapter sda = new MySqlDataAdapter(comando);
                DataSet ds = new DataSet();
                sda.Fill(ds);

                ViewBag.Herramientas = ds.Tables[0];
                List<SelectListItem> getTools = new List<SelectListItem>();
                foreach (System.Data.DataRow dr in ViewBag.Herramientas.Rows)
                {
                    getTools.Add(new SelectListItem { Text = @dr["nombre"].ToString(), Value = @dr["id"].ToString() });
                }
                ViewBag.getTools = getTools;
            }

            con.Close();

            return View();
        }

        public ActionResult Change()
        {
            //Agrgar lista de CONSTRUCTORAS a dropdownlist

            MySqlConnection con = Models.AvroDB.Connection();
            con.Open();
            using (MySqlCommand comando = new MySqlCommand("Select * from Constructora", con))
            {
                MySqlDataAdapter sda = new MySqlDataAdapter(comando);
                DataSet ds = new DataSet();
                sda.Fill(ds);

                ViewBag.Constructoras = ds.Tables[0];
                List<SelectListItem> getconstructioncompany = new List<SelectListItem>();
                foreach (System.Data.DataRow dr in ViewBag.Constructoras.Rows)
                {
                    getconstructioncompany.Add(new SelectListItem { Text = @dr["nombre"].ToString(), Value = @dr["id"].ToString() });
                }
                ViewBag.getconstructioncompany = getconstructioncompany;
            }

            //Agrgar lista de OBRAS a dropdownlist

            using (MySqlCommand comando = new MySqlCommand("Select * from Obra", con))
            {
                MySqlDataAdapter sda = new MySqlDataAdapter(comando);
                DataSet ds = new DataSet();
                sda.Fill(ds);

                ViewBag.Obras = ds.Tables[0];
                List<SelectListItem> getBuildingSite = new List<SelectListItem>();
                foreach (System.Data.DataRow dr in ViewBag.Obras.Rows)
                {
                    getBuildingSite.Add(new SelectListItem { Text = @dr["obra"].ToString(), Value = @dr["id"].ToString() });
                }
                ViewBag.getBuildingSite = getBuildingSite;
            }

            //Agrgar lista de CONTACTOS a dropdownlist

            using (MySqlCommand comando = new MySqlCommand("Select * from Contacto", con))
            {
                MySqlDataAdapter sda = new MySqlDataAdapter(comando);
                DataSet ds = new DataSet();
                sda.Fill(ds);

                ViewBag.Contactos = ds.Tables[0];
                List<SelectListItem> getContacts = new List<SelectListItem>();
                foreach (System.Data.DataRow dr in ViewBag.Contactos.Rows)
                {
                    getContacts.Add(new SelectListItem { Text = @dr["nombre"].ToString(), Value = @dr["id"].ToString() });
                }
                ViewBag.getContacts = getContacts;
            }

            //Agrgar lista de FORMAS DE PAGOS a dropdownlist

            using (MySqlCommand comando = new MySqlCommand("Select * from Formapago", con))
            {
                MySqlDataAdapter sda = new MySqlDataAdapter(comando);
                DataSet ds = new DataSet();
                sda.Fill(ds);

                ViewBag.Formapago = ds.Tables[0];
                List<SelectListItem> getPayMethod = new List<SelectListItem>();
                foreach (System.Data.DataRow dr in ViewBag.Formapago.Rows)
                {
                    getPayMethod.Add(new SelectListItem { Text = @dr["descripcion"].ToString(), Value = @dr["id"].ToString() });
                }
                ViewBag.getPayMethod = getPayMethod;
            }

            //Agrgar lista de CATEGORIAS DE HERRAMIENTAS a dropdownlist

            using (MySqlCommand comando = new MySqlCommand("Select * from Categoria", con))
            {
                MySqlDataAdapter sda = new MySqlDataAdapter(comando);
                DataSet ds = new DataSet();
                sda.Fill(ds);

                ViewBag.Categoria = ds.Tables[0];
                List<SelectListItem> getCategory = new List<SelectListItem>();
                foreach (System.Data.DataRow dr in ViewBag.Categoria.Rows)
                {
                    getCategory.Add(new SelectListItem { Text = @dr["descripcion"].ToString(), Value = @dr["id"].ToString() });
                }
                ViewBag.getCategory = getCategory;
            }

            //Agrgar lista de HERRAMIENTAS DISPONIBLES a dropdownlist

            using (MySqlCommand comando = new MySqlCommand("Select * from Herramienta", con))
            {
                MySqlDataAdapter sda = new MySqlDataAdapter(comando);
                DataSet ds = new DataSet();
                sda.Fill(ds);

                ViewBag.Herramientas = ds.Tables[0];
                List<SelectListItem> getTools = new List<SelectListItem>();
                foreach (System.Data.DataRow dr in ViewBag.Herramientas.Rows)
                {
                    getTools.Add(new SelectListItem { Text = @dr["nombre"].ToString(), Value = @dr["id"].ToString() });
                }
                ViewBag.getTools = getTools;
            }

            con.Close();

            return View();
        }

        public ActionResult Finished()
        {
            //Agrgar lista de CONSTRUCTORAS a dropdownlist

            MySqlConnection con = Models.AvroDB.Connection();
            con.Open();
            using (MySqlCommand comando = new MySqlCommand("Select * from Constructora", con))
            {
                MySqlDataAdapter sda = new MySqlDataAdapter(comando);
                DataSet ds = new DataSet();
                sda.Fill(ds);

                ViewBag.Constructoras = ds.Tables[0];
                List<SelectListItem> getconstructioncompany = new List<SelectListItem>();
                foreach (System.Data.DataRow dr in ViewBag.Constructoras.Rows)
                {
                    getconstructioncompany.Add(new SelectListItem { Text = @dr["nombre"].ToString(), Value = @dr["id"].ToString() });
                }
                ViewBag.getconstructioncompany = getconstructioncompany;
            }

            //Agrgar lista de OBRAS a dropdownlist

            using (MySqlCommand comando = new MySqlCommand("Select * from Obra", con))
            {
                MySqlDataAdapter sda = new MySqlDataAdapter(comando);
                DataSet ds = new DataSet();
                sda.Fill(ds);

                ViewBag.Obras = ds.Tables[0];
                List<SelectListItem> getBuildingSite = new List<SelectListItem>();
                foreach (System.Data.DataRow dr in ViewBag.Obras.Rows)
                {
                    getBuildingSite.Add(new SelectListItem { Text = @dr["obra"].ToString(), Value = @dr["id"].ToString() });
                }
                ViewBag.getBuildingSite = getBuildingSite;
            }

            //Agrgar lista de CONTACTOS a dropdownlist

            using (MySqlCommand comando = new MySqlCommand("Select * from Contacto", con))
            {
                MySqlDataAdapter sda = new MySqlDataAdapter(comando);
                DataSet ds = new DataSet();
                sda.Fill(ds);

                ViewBag.Contactos = ds.Tables[0];
                List<SelectListItem> getContacts = new List<SelectListItem>();
                foreach (System.Data.DataRow dr in ViewBag.Contactos.Rows)
                {
                    getContacts.Add(new SelectListItem { Text = @dr["nombre"].ToString(), Value = @dr["id"].ToString() });
                }
                ViewBag.getContacts = getContacts;
            }

            //Agrgar lista de FORMAS DE PAGOS a dropdownlist

            using (MySqlCommand comando = new MySqlCommand("Select * from Formapago", con))
            {
                MySqlDataAdapter sda = new MySqlDataAdapter(comando);
                DataSet ds = new DataSet();
                sda.Fill(ds);

                ViewBag.Formapago = ds.Tables[0];
                List<SelectListItem> getPayMethod = new List<SelectListItem>();
                foreach (System.Data.DataRow dr in ViewBag.Formapago.Rows)
                {
                    getPayMethod.Add(new SelectListItem { Text = @dr["descripcion"].ToString(), Value = @dr["id"].ToString() });
                }
                ViewBag.getPayMethod = getPayMethod;
            }

            //Agrgar lista de CATEGORIAS DE HERRAMIENTAS a dropdownlist

            using (MySqlCommand comando = new MySqlCommand("Select * from Categoria", con))
            {
                MySqlDataAdapter sda = new MySqlDataAdapter(comando);
                DataSet ds = new DataSet();
                sda.Fill(ds);

                ViewBag.Categoria = ds.Tables[0];
                List<SelectListItem> getCategory = new List<SelectListItem>();
                foreach (System.Data.DataRow dr in ViewBag.Categoria.Rows)
                {
                    getCategory.Add(new SelectListItem { Text = @dr["descripcion"].ToString(), Value = @dr["id"].ToString() });
                }
                ViewBag.getCategory = getCategory;
            }

            //Agrgar lista de HERRAMIENTAS DISPONIBLES a dropdownlist

            using (MySqlCommand comando = new MySqlCommand("Select * from Herramienta", con))
            {
                MySqlDataAdapter sda = new MySqlDataAdapter(comando);
                DataSet ds = new DataSet();
                sda.Fill(ds);

                ViewBag.Herramientas = ds.Tables[0];
                List<SelectListItem> getTools = new List<SelectListItem>();
                foreach (System.Data.DataRow dr in ViewBag.Herramientas.Rows)
                {
                    getTools.Add(new SelectListItem { Text = @dr["nombre"].ToString(), Value = @dr["id"].ToString() });
                }
                ViewBag.getTools = getTools;
            }

            con.Close();

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