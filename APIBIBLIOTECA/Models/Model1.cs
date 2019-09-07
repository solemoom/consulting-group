namespace APIBIBLIOTECA.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public DbSet<Autor> Autor { get; set; }
        public DbSet<Estudiante> Estudiante { get; set; }
        public DbSet<LibAut> LibAut { get; set; }
        public DbSet<Libro> Libro { get; set; }
        public DbSet<Prestamo> Prestamo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
