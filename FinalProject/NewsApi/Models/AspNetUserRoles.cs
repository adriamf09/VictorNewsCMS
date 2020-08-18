using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewsApi.Models
{
    [Table("AspNetUserRoles")]
    public class AspNetUserRoles
    {
        [Key, Column("UserId", Order = 0)]
        public string UserId { get; set; }

        [Key, Column("RoleId", Order = 1)]
        public string RoleId { get; set; }
    }
}