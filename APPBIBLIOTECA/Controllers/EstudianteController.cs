using APPBIBLIOTECA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace APPBIBLIOTECA.Controllers
{
    public class EstudianteController : Controller
    {
        // GET: Estudiante
        public ActionResult Index()
        {
            IEnumerable<Estudiante> EstudiantesList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Estudiantes").Result;
            EstudiantesList = response.Content.ReadAsAsync<IEnumerable<Estudiante>>().Result;
            return View(EstudiantesList);
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            if (id == 0)
                return View(new Estudiante());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Estudiantes/"+id.ToString()).Result;
                return View(response.Content.ReadAsAsync<Estudiante>().Result);

            }
        }
        [HttpPost]
        public ActionResult AgregarEditar(Estudiante EstudianteList)
        {
            if (EstudianteList.IdLector == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Estudiantes", EstudianteList).Result;
                TempData["SuccessMessage"] = "Guardado";    
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Estudiantes/"+EstudianteList.IdLector.ToString(), EstudianteList).Result;
                TempData["SuccessMessage"] = "Actualizado";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Borrar(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Estudiantes/"+id.ToString()).Result;
            TempData["SuccessMessage"] = "Borrado";
            return RedirectToAction("Index");
        }
    }
}