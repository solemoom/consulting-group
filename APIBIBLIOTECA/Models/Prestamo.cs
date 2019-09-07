namespace APIBIBLIOTECA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Prestamo")]
    public partial class Prestamo
    {
        public int IdLector { get; set; }

        public int IdLibro { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaPrestamo { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaDevolucion { get; set; }

        public bool Devuelto { get; set; }

        [Key]
        public int idPrestamo { get; set; }

        public virtual Estudiante Estudiante { get; set; }

        public virtual Libro Libro { get; set; }
    }
}
