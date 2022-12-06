using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Modelo;
using Persistencia.Contexts;
using Persistencia.DAL;

namespace ProjetoApoo.Controllers
{
    public class PetsController : Controller
    {
        //metodos privados (inicio)
        private ActionResult GravarPet(Pet pet)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    petDAL.GravarPet(pet);
                    return RedirectToAction("Index");
                }
                PopularViewBag(pet);
                return View(pet);
            }
            catch
            {
                return View(pet);
            }
        }
        private ActionResult ObterVisaoPetPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = petDAL.ObterPetsPorId((long)id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        private void PopularViewBag(Pet pet = null)
        {
            if (pet == null)
            {
                ViewBag.EspecieId = new SelectList(especieDAL.ObterEspeciesClassificadasPorNome(), "EspecieId", "Nome");
            }
            else
            {
                ViewBag.EspecieId = new SelectList(especieDAL.ObterEspeciesClassificadasPorNome(), "EspecieId", "Nome", pet.EspecieId);
            }
        }
        //metodos privados (fim)


        //private EFContext context = new EFContext();
        private PetDAL petDAL = new PetDAL();
        private EspecieDAL especieDAL = new EspecieDAL();

        // GET: Pets
        public ActionResult Index()
        {
            return View(petDAL.ObterPetsClassificadosPorId());
        }

        // GET: Pets/Create
        public ActionResult Create()
        {
            PopularViewBag();
            return View();
        }

        // POST: Pets/Create
        [HttpPost]
        public ActionResult Create(Pet pet)
        {
            return GravarPet(pet);
        }

        // GET: Pets/Edit/5
        public ActionResult Edit(long? id)
        {
            PopularViewBag(petDAL.ObterPetsPorId((long)id));
            return ObterVisaoPetPorId(id);
        }

        // POST: Pets/Edit/5
        [HttpPost]
        public ActionResult Edit(Pet pet)
        {
            return GravarPet(pet);
        }

        // GET: Pets/Details/5
        public ActionResult Details(long? id)
        {
            return ObterVisaoPetPorId(id);
        }

        // GET: Pets/Delete/5

        public ActionResult Delete(long? id)
        {
            return ObterVisaoPetPorId(id);
        }

        // POST: Pets/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Pet pet = petDAL.EliminarPetPorId(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
