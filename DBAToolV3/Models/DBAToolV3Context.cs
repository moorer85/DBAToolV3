using DBAToolV3.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DBAToolV3.Models
{
    public class DBAToolV3Context : DbContext
    {
        public DBAToolV3Context() : base("name=DBAToolV3ContextEntities")
        {
        }



        public virtual DbSet<ServerDatabase> ServerDatabases { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Server> Servers { get; set; }

        public virtual DbSet<DatabaseStatus> Statuses { get; set; }





    }
}