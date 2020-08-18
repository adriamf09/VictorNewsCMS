using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewsApi.Models
{
    [Table("Noticias")]
    public class Noticias
    {
        [Key]
        [Column("NoticiaId")]
        public int NoticiaId { get; set; }

        [Required]
        [Column("CategoriaId")]
        public int CategoriaId { get; set; }

        [Column("Autor")]
        public string Autor { get; set; }

        [Required]
        [Column("EstadoId")]
        public int EstadoId { get; set; }

        [Required]
        [StringLength(200)]
        [Column("Titular")]
        public string Titular { get; set; }

        [Required]
        [Column("Portada")]
        public String Portada { get; set; }

        [Required]
        [StringLength(500)]
        [Column("Resumen")]
        public string Resumen { get; set; }

        [Required]
        [Column("Contenido")]
        public string Contenido { get; set; }

        [Column("FechaCreacion")]
        public DateTime FechaCreacion { get; set; }

        [Column("FechaPublicacion")]
        public DateTime FechaPublicacion { get; set; }

        [Column("Eliminado")]
        public bool Eliminado { get; set; }
    }
}