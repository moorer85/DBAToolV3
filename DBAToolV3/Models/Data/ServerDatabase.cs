using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DBAToolV3.Data.Models
{
    public class ServerDatabase
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Size { get; set; }

        //[Display(Name = "Database Owner")]
        //public Employee DatabaseOwner { get; set; }

        //[Display(Name = "Primary DBA Support")]
        //public Employee PrimaryDBA { get; set; }

        //[Display(Name = "Backup DBA Support")]
        //public Employee BackupDBA { get; set; }

        public int NumberOfUsers { get; set; }
        public int ServerId { get; set; }
        public virtual Server Server { get; set; }


    }
}
