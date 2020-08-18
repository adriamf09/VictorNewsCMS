using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewsApi.Models
{
    [Table("AspNetRoles")]
    public class AspNetRoles
    {
        [Key]
        [Column("Id")]
        public string Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }
    }
}