using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NewsApi.Models
{
    public class NewsAppDbContext : DbContext
    {
        public NewsAppDbContext()
            : base("DefaultConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Categorias> Categorias { get; set; }

        public DbSet<Estados> Estados { get; set; }
        public DbSet<Noticias> Noticias { get; set; }

        public DbSet<AspNetRoles> AspNetRoles { get; set; }

        public DbSet<AspNetUsers> AspNetUsers { get; set; }

        public DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }

        public System.Data.Entity.DbSet<NewsApi.Models.CategoriasNoticias> CategoriasNoticias { get; set; }

        public System.Data.Entity.DbSet<NewsApi.Models.Paginacion> Paginacions { get; set; }
    }
}