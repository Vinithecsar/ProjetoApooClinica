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
    public class ConsultasController : Controller
    {
        private ConsultaDAL consultaDAL = new ConsultaDAL();

        // GET: Consultas
        public ActionResult Index()
        {
            return View(consultaDAL.ObterConsultasClassificadosPorId());
        }

        // GET: Consultas/Details/5
        public ActionResult Details(long? id)
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

        // GET: Consultas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Consultas/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ConsultaId,Data_hora,Sintomas")] Consulta consulta)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    consultaDAL.GravarConsulta(consulta);
                    return RedirectToAction("Index");
                }
                return View(consulta);
            }
            catch
            {
                return View(consulta);
            }
        }

        // GET: Consultas/Edit/5
        public ActionResult Edit(long? id)
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
            //var ConsultasExames = from c in consulta.Cursos
            //                       select new
            //                       {
            //                           c.CursoId,
            //                           c.Nome,
            //                           Checked = ((from ce in db.CursosEstudantes
            //                                       where (ce.EstudanteId == id) & (ce.CursoId == c.CursoId)
            //                                       select ce).Count() > 0)
            //                       };
            //var estudanteViewModel = new EstudantesViewModel();
            //estudanteViewModel.EstudanteId = id.Value;
            //estudanteViewModel.Nome = estudante.Nome;
            //estudanteViewModel.Idade = estudante.Idade;
            //estudanteViewModel.Sexo = estudante.Sexo;
            //var checkboxListCursos = new List<CheckBoxViewModel>();
            //foreach (var item in CursosEstudantes)
            //{
            //    checkboxListCursos.Add(new CheckBoxViewModel
            //    {
            //        Id = item.CursoId,
            //        Nome = item.Nome,
            //        Checked = item.Checked
            //    });
            //}
            //estudanteViewModel.Cursos = checkboxListCursos;
            //return View(estudanteViewModel);
        }

        // POST: Consultas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ConsultaId,Data_hora,Sintomas")] Consulta consulta)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    consultaDAL.GravarConsulta(consulta);
                    return RedirectToAction("Index");
                }
                return View(consulta);
            }
            catch
            {
                return View(consulta);
            }
        }

        // GET: Consultas/Delete/5
        public ActionResult Delete(long? id)
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

        // POST: Consultas/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Consulta consulta = consultaDAL.EliminarConsultaPorId(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
