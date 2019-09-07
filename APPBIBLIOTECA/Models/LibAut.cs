using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APPBIBLIOTECA.Models
{
    public class LibAut
    {
        public int IdAutor { get; set; }

        public int IdLibro { get; set; }

        [Key]
        public int IdLibAut { get; set; }

        public virtual Autor Autor { get; set; }

        public virtual Libro Libro { get; set; }
    }
}