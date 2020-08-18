using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewsApi.Models
{
    [Table("Estados")]
    public class Estados
    {
        [Key]
        [Column("EstadoId")]
        public int EstadoId { get; set; }

        [Required]
        [StringLength(30)]
        [Column("NombreEstado")]
        public string NombreEstado { get; set; }
    }
}