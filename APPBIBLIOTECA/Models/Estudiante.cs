using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APPBIBLIOTECA.Models
{
    public class Estudiante
    {
        public int IdLector { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string CI { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string Carrera { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public int Edad { get; set; }
    }
}