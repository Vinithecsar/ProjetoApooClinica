using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Modelo;
using Persistencia;

namespace ProjetoApoo.Controllers
{
    public class ProcedimentosController : Controller
    {
        private ExameDAL exameDAL = new ExameDAL();
        // GET: Procedimentos
        public ActionResult Index()
        {
            return View(exameDAL.ObterExamesClassificadosPorId());
        }

        // GET: Procedimentos/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Exame exame = exameDAL.ObterExamesPorId((long)id);
            if (exame == null)
            {
                return HttpNotFound();
            }
            return View(exame);
        }

        // GET: Procedimentos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Procedimentos/Create
        [HttpPost]
        public ActionResult Create(Exame exame)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    exameDAL.GravarExame(exame);
                    return RedirectToAction("Index");
                }
                return View(exame);
            }
            catch
            {
                return View(exame);
            }
        }

        // GET: Procedimentos/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Exame exame = exameDAL.ObterExamesPorId((long)id);
            if (exame == null)
            {
                return HttpNotFound();
            }
            return View(exame);
        }

        // POST: Procedimentos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Exame exame)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    exameDAL.GravarExame(exame);
                    return RedirectToAction("Index");
                }
                return View(exame);
            }
            catch
            {
                return View(exame);
            }
        }

        // GET: Procedimentos/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Exame exame = exameDAL.ObterExamesPorId((long)id);
            if (exame == null)
            {
                return HttpNotFound();
            }
            return View(exame);
        }

        // POST: Procedimentos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Exame exame = exameDAL.EliminarExamePorId(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
