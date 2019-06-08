using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DBAToolV3.Data.Models
{
    public class ServerDatabase
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Size { get; set; }
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int NumberOfUsers { get; set; }
        public int ServerId { get; set; }
        public virtual Server Server { get; set; }

    }
}
