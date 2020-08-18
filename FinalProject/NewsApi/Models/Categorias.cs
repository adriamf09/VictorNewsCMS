using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewsApi.Models
{
    [Table("Categorias")]
    public class Categorias
    {
        [Key]
        [Column("CategoriaId")]
        public int CategoriaId { get; set; }

        [Required]
        [StringLength(50)]
        [Column("NombreCategoria")]
        public string NombreCategoria { get; set; }

        [Column("Eliminado")]
        public bool Eliminado { get; set; }
    }
}