using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewsApi.Models
{
    [Table("Paginacion")]
    public class Paginacion
    {
        [Key]
        [Column("PaginacionId")]
        public int PaginacionId { get; set; }

        [Required]
        [Column("PageSize")]
        public int PageSize { get; set; }
    }
}