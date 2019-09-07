namespace APIBIBLIOTECA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Estudiante")]
    public partial class Estudiante
    {
        [Key]
        public int IdLector { get; set; }

        [Required]
        [StringLength(10)]
        public string CI { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        public string Direccion { get; set; }

        [Required]
        [StringLength(50)]
        public string Carrera { get; set; }

        public int Edad { get; set; }
    }
}
