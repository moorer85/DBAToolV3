using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DBAToolV3.Data.Models
{
    public class Server
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int? Memory { get; set; }

        public int? CpuCore { get; set; }

        public float? CpuSpeed { get; set; }

        public DateTime PurchaseDate { get; set; } 
      
        public DatabaseStatus Status { get; set; }
        public string ImageUrl { get; set; }

        public virtual IEnumerable<ServerDatabase> ServerDatabases { get; set; }




    }
}
