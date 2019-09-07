using APPBIBLIOTECA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace APPBIBLIOTECA.Controllers
{
    public class LibroController : Controller
    {
        // GET: Libro
        public ActionResult Index()
        {
            IEnumerable<Libro> LibroList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Libroes").Result;
            LibroList = response.Content.ReadAsAsync<IEnumerable<Libro>>().Result;
            return View(LibroList);
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            if (id == 0)
                return View(new Libro());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Libroes/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<Libro>().Result);

            }
        }

        [HttpPost]
        public ActionResult AgregarEditar(Libro LibroList)
        {
            if (LibroList.IdLibro == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Libroes", LibroList).Result;
                TempData["SuccessMessage"] = "Guardado";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Libroes/" + LibroList.IdLibro.ToString(), LibroList).Result;
                TempData["SuccessMessage"] = "Actualizado";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Borrar(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Libroes/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Borrado";
            return RedirectToAction("Index");
        }
    }
}