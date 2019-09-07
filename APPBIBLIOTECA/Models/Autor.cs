using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APPBIBLIOTECA.Models
{
    public class Autor
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