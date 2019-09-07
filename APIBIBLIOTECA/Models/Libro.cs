namespace APIBIBLIOTECA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Libro")]
    public partial class Libro
    {

        [Key]
        public int IdLibro { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Editorial { get; set; }

        [Required]
        [StringLength(50)]
        public string Area { get; set; }
    }
}
