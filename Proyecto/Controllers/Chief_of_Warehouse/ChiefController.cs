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

            MySqlConnection con = AvroDB.Connection();
            con.Open();
            using (MySqlCommand comando = new MySqlCommand("Select * from Constructora", con))
            {
                MySqlDataAdapter sda = new MySqlDataAdapter(comando);
                DataSet ds = new DataSet();
                sda.Fill(ds);

                ViewBag.Constructoras = ds.Tables[0];
                List<SelectListItem> getconstructioncompany = new List<SelectListItem>();
                foreach (DataRow dr in ViewBag.Constructoras.Rows)
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
                foreach (DataRow dr in ViewBag.Obras.Rows)
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
                foreach (DataRow dr in ViewBag.Contactos.Rows)
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
                foreach (DataRow dr in ViewBag.Formapago.Rows)
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
                foreach (DataRow dr in ViewBag.Categoria.Rows)
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
                foreach (DataRow dr in ViewBag.Herramientas.Rows)
                {
                    getTools.Add(new SelectListItem { Text = @dr["nombre"].ToString(), Value = @dr["id"].ToString() });
                }
                ViewBag.getTools = getTools;
            }

            con.Close();

            return View();
        }
        [HttpPost]
        public ActionResult Rent(FormCollection formObj)
        {
            ConstructionCompany constructionCompany = new ConstructionCompany();
            constructionCompany = constructionCompany.GetConstructionCompany(Convert.ToInt32(formObj["getconstructioncompany"]));
            //BuildingSite buildingSite = new BuildingSite();
            //buildingSite = buildingSite.GetBuildingSite(Convert.ToInt32(formObj["getBuildingSite"]));
            //string contact = formObj["getContacts"];
            PayMethod payMethod = new PayMethod();
            payMethod = payMethod.GetPayMethod(Convert.ToInt32(formObj["getPayMethod"]));
            //string category = formObj["getCategory"];
            Tool tool = new Tool();
            tool = tool.GetTool(Convert.ToInt32(formObj["getTools"]));
            //DeliveryGuide deliveryGuide = new DeliveryGuide();
            try
            {
                MySqlConnection conn = AvroDB.Connection();
                conn.Open();
                MySqlCommand cmdDeliveryGuide = new MySqlCommand("INSERT INTO Guiadespacho (id,fecha,vencimiento,Usuario_id,Formapago_id) " +
                    "VALUES (NULL,CURDATE(),ADDDATE(CURDATE(), INTERVAL 1 MONTH),1,"+payMethod.Id+");", conn);
                cmdDeliveryGuide.ExecuteNonQuery();
                MySqlCommand cmdLastDeliveryGuide = new MySqlCommand("SELECT id FROM Guiadespacho ORDER BY id DESC LIMIT 1", conn);
                using (var reader = cmdLastDeliveryGuide.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int LastDeliveryGuideId = Convert.ToInt32(reader["id"]);
                        MySqlCommand cmdOrder = new MySqlCommand("INSERT INTO Pedido (id,descripcion,Guiadespacho_id,Herramienta_id,Constructora_id) " +
                            "VALUES (NULL,'"+tool.Name+"',(SELECT id FROM Guiadespacho WHERE id LIKE "+LastDeliveryGuideId+")," +
                            "(SELECT id FROM Herramienta WHERE id LIKE "+tool.Id+"," +
                            "(SELECT id FROM Constructora WHERE id LIKE "+constructionCompany.Id+");", conn);
                        cmdOrder.ExecuteNonQuery();
                    }
                }
                conn.Close();
            }catch (MySqlException e)
            {
                Console.WriteLine("Error: " + e.Message);
                return null;
            }
            return View("Rent");
        }

        public ActionResult Change()
        {
            //Agrgar lista de CONSTRUCTORAS a dropdownlist

            MySqlConnection con = AvroDB.Connection();
            con.Open();
            using (MySqlCommand comando = new MySqlCommand("Select * from Constructora", con))
            {
                MySqlDataAdapter sda = new MySqlDataAdapter(comando);
                DataSet ds = new DataSet();
                sda.Fill(ds);

                ViewBag.Constructoras = ds.Tables[0];
                List<SelectListItem> getconstructioncompany = new List<SelectListItem>();
                foreach (DataRow dr in ViewBag.Constructoras.Rows)
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
                foreach (DataRow dr in ViewBag.Obras.Rows)
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
                foreach (DataRow dr in ViewBag.Contactos.Rows)
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
                foreach (DataRow dr in ViewBag.Formapago.Rows)
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
                foreach (DataRow dr in ViewBag.Categoria.Rows)
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
                foreach (DataRow dr in ViewBag.Herramientas.Rows)
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
                foreach (DataRow dr in ViewBag.Constructoras.Rows)
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
                foreach (DataRow dr in ViewBag.Obras.Rows)
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
                foreach (DataRow dr in ViewBag.Contactos.Rows)
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
                foreach (DataRow dr in ViewBag.Formapago.Rows)
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
                foreach (DataRow dr in ViewBag.Categoria.Rows)
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
                foreach (DataRow dr in ViewBag.Herramientas.Rows)
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