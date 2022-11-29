using Modelo;
using Persistencia.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProjetoApoo.Controllers
{
    public class VeterinariosController : Controller
    {
        private VeterinarioDAL veterinarioDAL = new VeterinarioDAL();
        private ActionResult ObterVisaoVeterinarioPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veterinario veterinario = veterinarioDAL.ObterVeterinarioPorId((long)id);
            if (veterinario == null)
            {
                return HttpNotFound();
            }
            return View(veterinario);
        }
        private ActionResult GravarVeterinario(Veterinario veterinario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    veterinarioDAL.GravarVeterinario(veterinario);
                    return RedirectToAction("index");
                }
                return View(veterinario);
            }
            catch
            {
                return View(veterinario);
            }
        }
        // GET: Veterinarios
        public ActionResult Index()
        {
            return View(veterinarioDAL.ObterVeterinariosClassificadosPorNome());
        }
        // Create get
        public ActionResult Create()
        {
            return View();
        }
        // Create post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Veterinario veterinario)
        {
            return GravarVeterinario(veterinario);
        }
        //Edit alone
        public ActionResult Edit(long? id)
        {
            return ObterVisaoVeterinarioPorId(id);
        }
        //Edit post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Veterinario veterinario)
        {
            return GravarVeterinario(veterinario);

        }
        //Details alone
        public ActionResult Details(long? id)
        {
            return ObterVisaoVeterinarioPorId(id);
        }
        //Delete alone
        public ActionResult Delete(long? id)
        {
            return ObterVisaoVeterinarioPorId(id);
        }
        //Delete post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Veterinario veterinario = veterinarioDAL.EliminarVeterinarioPorId(id);
 
                return RedirectToAction("index");
            }
            catch
            {
                return View();
            }
        }
    }
}