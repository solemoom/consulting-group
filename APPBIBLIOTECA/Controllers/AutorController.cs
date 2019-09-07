using APPBIBLIOTECA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace APPBIBLIOTECA.Controllers
{
    public class AutorController : Controller
    {
        // GET: Autor
        public ActionResult Index()
        {
            IEnumerable<Autor> AutorList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Autors").Result;
            AutorList = response.Content.ReadAsAsync<IEnumerable<Autor>>().Result;
            return View(AutorList);
        }
        public ActionResult AgregarEditar(int id = 0)
        {
            if (id == 0)
                return View(new Autor());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Autors/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<Autor>().Result);

            }
        }
        [HttpPost]
        public ActionResult AgregarEditar(Autor AutorList)
        {
            if (AutorList.IdAutor == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Autors", AutorList).Result;
                TempData["SuccessMessage"] = "Guardado";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Autors/" + AutorList.IdAutor.ToString(), AutorList).Result;
                TempData["SuccessMessage"] = "Actualizado";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Borrar(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Autors/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Borrado";
            return RedirectToAction("Index");
        }
    }
}