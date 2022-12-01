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
        private PetDAL petDAL = new PetDAL();

        // GET: Pets
        public ActionResult Index()
        {
            return View(petDAL.ObterPetsClassificadosPorId());
        }

        // GET: Pets/Details/5
        public ActionResult Details(long? id)
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

        // GET: Pets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pets/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pet pet)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    petDAL.GravarPet(pet);
                    return RedirectToAction("Index");
                }
                return View(pet);
            }
            catch
            {
                return View(pet);
            }
        }

        // GET: Pets/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Pet pet = petDAL.ObterPetsPorId((long)id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        // POST: Pets/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pet pet)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    petDAL.GravarPet(pet);
                    return RedirectToAction("Index");
                }
                return View(pet);
            }
            catch
            {
                return View(pet);
            }
        }

        // GET: Pets/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Pet pet = petDAL.ObterPetsPorId((long)id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        // POST: Pets/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
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
