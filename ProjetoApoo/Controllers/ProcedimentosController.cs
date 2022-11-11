using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Modelo;
using Persistencia.DAL;
using Persistencia.Contexts;

namespace ProjetoApoo.Controllers
{
    public class ProcedimentosController : Controller
    {
        private ExameDAL exameDAL = new ExameDAL();
        private ConsultaDAL consultaDAL = new ConsultaDAL();

        // GET: Procedimentos
        public ActionResult IndexExame()
        {
            return View(exameDAL.ObterExamesClassificadosPorId());
        }

        // GET: Procedimentos/Details/5
        public ActionResult DetailsExame(long? id)
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

        // GET: Procedimentos/Create
        public ActionResult CreateExame()
        {
            return View();
        }

        // POST: Procedimentos/Create
        [HttpPost]
        public ActionResult CreateExame(Exame exame)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    exameDAL.GravarExame(exame);
                    return RedirectToAction("IndexExame");
                }
                return View(exame);
            }
            catch
            {
                return View(exame);
            }
        }

        // GET: Procedimentos/Edit/5
        public ActionResult EditExame(long? id)
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
            //ViewBag.ConsultaId = new SelectList(consultaDAL.ObterConsultasClassificadosPorId(), "ConsultaId"/*, exame.ConsultaId*/);
            return View(exame);
        }

        // POST: Procedimentos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditExame(Exame exame)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    exameDAL.GravarExame(exame);
                    return RedirectToAction("IndexExame");
                }
                return View(exame);
            }
            catch
            {
                return View(exame);
            }
        }

        // GET: Procedimentos/Delete/5
        public ActionResult DeleteExame(long? id)
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
        public ActionResult DeleteExame(long id)
        {
            try
            {
                Exame exame = exameDAL.EliminarExamePorId(id);
                return RedirectToAction("IndexExame");
            }
            catch
            {
                return View();
            }
        }

        //CONSULTA

        // GET: Procedimentos
        public ActionResult IndexConsulta()
        {
            return View(consultaDAL.ObterConsultasClassificadosPorId());
        }

        // GET: Procedimentos/Details/5
        public ActionResult DetailsConsulta(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Consulta consulta = consultaDAL.ObterConsultasPorId((long)id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            return View(consulta);
        }

        // GET: Procedimentos/Create
        public ActionResult CreateConsulta()
        {
            return View();
        }

        // POST: Procedimentos/Create
        [HttpPost]
        public ActionResult CreateConsulta(Consulta consulta)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    consultaDAL.GravarConsulta(consulta);
                    return RedirectToAction("IndexConsulta");
                }
                return View(consulta);
            }
            catch
            {
                return View(consulta);
            }
        }

        // GET: Procedimentos/Edit/5
        public ActionResult EditConsulta(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Consulta consulta = consultaDAL.ObterConsultasPorId((long)id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            return View(consulta);
        }

        // POST: Procedimentos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditConsulta(Consulta consulta)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    consultaDAL.GravarConsulta(consulta);
                    return RedirectToAction("IndexConsulta");
                }
                return View(consulta);
            }
            catch
            {
                return View(consulta);
            }
        }

        // GET: Procedimentos/Delete/5
        public ActionResult DeleteConsulta(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Consulta consulta = consultaDAL.ObterConsultasPorId((long)id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            return View(consulta);
        }

        // POST: Procedimentos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConsulta(long id)
        {
            try
            {
                Consulta consulta = consultaDAL.EliminarConsultaPorId(id);
                return RedirectToAction("IndexConsulta");
            }
            catch
            {
                return View();
            }
        }
    }
}
