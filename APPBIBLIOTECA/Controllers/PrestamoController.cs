using APPBIBLIOTECA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace APPBIBLIOTECA.Controllers
{
    public class PrestamoController : Controller
    {
        // GET: Prestamo
        public ActionResult Index()
        {
            IEnumerable<Prestamo> PrestamoList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Prestamoes").Result;
            PrestamoList = response.Content.ReadAsAsync<IEnumerable<Prestamo>>().Result;
            return View(PrestamoList);
        }


        public ActionResult AgregarEditar(int id = 0)
        {
            if (id == 0)
                return View(new Prestamo());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Prestamoes/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<Prestamo>().Result);

            }
        }
        [HttpPost]
        public ActionResult AgregarEditar(Prestamo PrestamoList)
        {
            if (PrestamoList.idPrestamo == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Prestamoes", PrestamoList).Result;
                TempData["SuccessMessage"] = "Guardado";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Prestamoes/" + PrestamoList.idPrestamo.ToString(), PrestamoList).Result;
                TempData["SuccessMessage"] = "Actualizado";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Borrar(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Prestamoes/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Borrado";
            return RedirectToAction("Index");
        }
    }
}