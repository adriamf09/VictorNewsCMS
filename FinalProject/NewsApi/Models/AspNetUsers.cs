using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewsApi.Models
{
    [Table("AspNetUsers")]
    public class AspNetUsers
    {
        [System.ComponentModel.DataAnnotations.Key]
        [Column("Id")]
        public string Id { get; set; }

        [Column("Email")]
        public string Email {get; set;}

        [Column("Name")]
        public string Name { get; set; }

        [Column("LastName")]
        public string LastName { get; set; }

        [Column("UserName")]
        public string UserName { get; set; }

        [Column("Eliminado")]
        public bool Eliminado { get; set; }
    }
}