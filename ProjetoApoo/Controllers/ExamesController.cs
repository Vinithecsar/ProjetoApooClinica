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
    public class ExamesController : Controller
    {
        private ExameDAL exameDAL = new ExameDAL();

        // GET: Exames
        public ActionResult Index()
        {
            return View(exameDAL.ObterExamesClassificadosPorId());
        }

        // GET: Exames/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exame exame = exameDAL.ObterExamesPorId((long)id);
            if (exame == null)
            {
                return HttpNotFound();
            }
            return View(exame);
        }

        // GET: Exames/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Exames/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExameId,Descricao,ConsultaId")] Exame exame)
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

        // GET: Exames/Edit/5
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

        // POST: Exames/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExameId,Descricao,ConsultaId")] Exame exame)
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

        // GET: Exames/Delete/5
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

        // POST: Exames/Delete/5
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
