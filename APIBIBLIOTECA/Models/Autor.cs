namespace APIBIBLIOTECA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Autor")]
    public partial class Autor
    {
        [Key]
        public int IdAutor { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Nacionalidad { get; set; }

    }
}
