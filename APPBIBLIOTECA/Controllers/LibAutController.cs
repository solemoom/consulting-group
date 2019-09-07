using APPBIBLIOTECA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace APPBIBLIOTECA.Controllers
{
    public class LibAutController : Controller
    {
        // GET: LibAut
        public ActionResult Index()
        {
            IEnumerable<LibAut> LibAutList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("LibAuts").Result;
            LibAutList = response.Content.ReadAsAsync<IEnumerable<LibAut>>().Result;
            return View(LibAutList);
        }
        public ActionResult AgregarEditar(int id = 0)
        {
            if (id == 0)
                return View(new Prestamo());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("LibAuts/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<LibAut>().Result);

            }
        }
        [HttpPost]
        public ActionResult AgregarEditar(LibAut LibAutList)
        {
            if (LibAutList.IdLibAut == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("LibAuts", LibAutList).Result;
                TempData["SuccessMessage"] = "Guardado";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("LibAuts/" + LibAutList.IdLibAut.ToString(), LibAutList).Result;
                TempData["SuccessMessage"] = "Actualizado";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Borrar(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("LibAuts/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Borrado";
            return RedirectToAction("Index");
        }
    }
}