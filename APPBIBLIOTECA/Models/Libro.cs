using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APPBIBLIOTECA.Models
{
    public class Libro
    {

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