using Proyecto.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Maintenance : IMaintenance
    {
        //Propiedades
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public Tool tool { get; set; }
        public User user { get; set; }
        //Constructores
        public Maintenance() { }
        public Maintenance(int id, string description, DateTime maintenanceDate, Tool tool, User user)
        {
            Id = id;
            Description = description;
            MaintenanceDate = maintenanceDate;
            this.tool = tool;
            this.user = user;
        }
        //Métodos de interfaz
        public bool AddMaintenance(Maintenance maintenance)
        {
            throw new NotImplementedException();
        }

        public void ModifyMaintenance(Maintenance maintenance)
        {
            throw new NotImplementedException();
        }

        public Maintenance GetMaintenance(int id)
        {
            throw new NotImplementedException();
        }
    }
}