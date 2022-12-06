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
using Modelo.ViewModels;

namespace ProjetoApoo.Controllers
{
    public class ConsultasController : Controller
    {
        private void PopularViewBag(Consulta consulta  = null)
        {
            if (consulta == null)
            {
                ViewBag.PetId = new SelectList(petDAL.ObterPetsClassificadosPorId(),"PetId", "Nome");
                ViewBag.UsuarioId = new SelectList(veterinarioDAL.ObterVeterinariosClassificadosPorNome(), "UsuarioId", "Nome");
            }
            else
            {
                ViewBag.PetId = new SelectList(petDAL.ObterPetsClassificadosPorId(), "PetId", "Nome", consulta.PetId);
                ViewBag.UsuarioId = new SelectList(veterinarioDAL.ObterVeterinariosClassificadosPorNome(), "UsuarioId", "Nome", consulta.UsuarioId);
            }
        }
        private ConsultaDAL consultaDAL = new ConsultaDAL();
        private PetDAL petDAL = new PetDAL();
        private VeterinarioDAL veterinarioDAL = new VeterinarioDAL();
        private EFContext context = new EFContext();
        // GET: Consultas
        public ActionResult Index()
        {
            return View(consultaDAL.ObterConsultasClassificadasPorId());
        }

        // GET: Consultas/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consulta consulta = consultaDAL.ObterConsultasPorId((long)id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            var ConsultasExames = from c in context.Exames
                                  select new
                                  {
                                      c.ExameId,
                                      c.Descricao,
                                      Checked = ((from ce in context.ConsultasExames
                                                  where (ce.ConsultaId == id) & (ce.ExameId == c.ExameId)
                                                  select ce).Count() > 0)
                                  };
            var consultaViewModel = new ConsultaViewModel();
            consultaViewModel.ConsultaId = id.Value;
            consultaViewModel.Data_hora = consulta.Data_hora;
            consultaViewModel.Sintomas = consulta.Sintomas;
            consultaViewModel.Pet = consulta.Pet;
            consultaViewModel.Veterinario = consulta.Veterinario;
            var checkboxListExames = new List<CheckBoxViewModel>();
            foreach (var item in ConsultasExames)
            {
                checkboxListExames.Add(new CheckBoxViewModel
                {
                    Id = item.ExameId,
                    Descricao = item.Descricao,
                    Checked = item.Checked
                });
            }
            consultaViewModel.Exames = checkboxListExames;
            return View(consultaViewModel);
        }

        // GET: Consultas/Create
        public ActionResult Create()
        {
            PopularViewBag();
            return View();
        }

        // POST: Consultas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Consulta consulta)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    consultaDAL.GravarConsulta(consulta);
                    return RedirectToAction("Index");
                }
                PopularViewBag();
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
            PopularViewBag(consultaDAL.ObterConsultasPorId((long)id));
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consulta consulta = consultaDAL.ObterConsultasPorId((long)id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            var ConsultasExames = from c in context.Exames
                                  select new
                                  {
                                      c.ExameId,
                                      c.Descricao,
                                      Checked = ((from ce in context.ConsultasExames
                                                  where (ce.ConsultaId == id) & (ce.ExameId == c.ExameId)
                                                  select ce).Count() > 0)
                                  };
            var consultaViewModel = new ConsultaViewModel();
            consultaViewModel.ConsultaId = id.Value;
            consultaViewModel.Data_hora = consulta.Data_hora;
            consultaViewModel.Sintomas = consulta.Sintomas;
            var checkboxListExames = new List<CheckBoxViewModel>();
            foreach (var item in ConsultasExames)
            {
                checkboxListExames.Add(new CheckBoxViewModel
                {
                    Id = item.ExameId,
                    Descricao = item.Descricao,
                    Checked = item.Checked
                });
            }
            consultaViewModel.Exames = checkboxListExames;
            return View(consultaViewModel);
        }

        // POST: Consultas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ConsultaViewModel consulta)
        {
            if (ModelState.IsValid)
            {
                var consultaSelecionada = context.Consultas.Find(consulta.ConsultaId);
                consultaSelecionada.ConsultaId = consulta.ConsultaId;
                consultaSelecionada.Data_hora = consulta.Data_hora;
                consultaSelecionada.Sintomas = consulta.Sintomas;
                foreach (var item in context.ConsultasExames)
                {
                    if (item.ConsultaId == consulta.ConsultaId)
                    {
                        context.Entry(item).State = EntityState.Deleted;
                    }
                }
                if (consulta.Exames != null) {
                    foreach (var item in consulta.Exames)
                    {
                        if (item.Checked)
                        {
                            context.ConsultasExames.Add(new ConsultaExame()
                            {
                                ConsultaId = consulta.ConsultaId,
                                ExameId = item.Id
                            });
                        }
                    } }
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PetId = new SelectList(petDAL.ObterPetsClassificadosPorId(), "PetId", "Nome", consulta.PetId);
            ViewBag.UsuarioId = new SelectList(veterinarioDAL.ObterVeterinariosClassificadosPorNome(), "UsuarioId", "Nome", consulta.UsuarioId);
            return View(consulta);
        }
        // GET: Consultas/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
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
