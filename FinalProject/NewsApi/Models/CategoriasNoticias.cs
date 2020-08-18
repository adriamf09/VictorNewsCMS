using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewsApi.Models
{
    [Table("CategoriasNoticias")]
    public class CategoriasNoticias
    {
        [Key, Column("CategoriaId", Order = 0)]
        public int CategoriaId { get; set; }

        [Key, Column("NoticiaId", Order = 1)]
        public int NoticiaId { get; set; }
    }
}