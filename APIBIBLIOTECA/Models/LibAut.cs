namespace APIBIBLIOTECA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LibAut")]
    public partial class LibAut
    {
        public int IdAutor { get; set; }

        public int IdLibro { get; set; }

        [Key]
        public int IdLibAut { get; set; }

        public virtual Autor Autor { get; set; }

        public virtual Libro Libro { get; set; }
    }
}
