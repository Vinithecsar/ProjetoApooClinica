using Persistencia.DAL;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace ProjetoApoo.Controllers
{
    public class TelefonesController : Controller
    {
        private TelefoneDAL telefoneDAL = new TelefoneDAL();
        private ActionResult ObterVisaoTelefonePorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefone Telefone = telefoneDAL.ObterTelefonePorId((long)id);
            if (Telefone == null)
            {
                return HttpNotFound();
            }
            return View(Telefone);
        }
        private ActionResult GravarTelefone(Telefone telefone)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    telefoneDAL.GravarTelefone(telefone);
                }
                return View(telefone);
            }
            catch
            {
                return View(telefone);
            }
        }
        // GET: Telefones
        public ActionResult Index(long? IdCliente)
        {
            ViewBag.ID = Request.QueryString["idCliente"];
            return View(telefoneDAL.ObterTelefonesClassificadosPorDdd());
            //return View(context.Telefones.OrderBy(c => c.Nome));
            //return View(cat);
        }
        // Create get
        public ActionResult Create()
        {
            ViewBag.ID = Request.QueryString["idCliente"];
            return View();
        }
        // Create post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Telefone telefone)
        {
            // IEnumerable<Telefone> a = cat.Where(c => c.TelefoneId >0);
            //context.Telefones.Add(ca);
            //context.SaveChanges();
            //ca.TelefoneId = cat.Select(c => c.TelefoneId).Max() + 1;// type ;  1, 2, 3, 4
            //cat.Add(ca);
            //return RedirectToAction("Index");
            return GravarTelefone(telefone);
        }
        //Edit alone
        public ActionResult Edit(long? id)
        {
            return ObterVisaoTelefonePorId(id);
        }
        //Edit post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Telefone telefone)
        {
            return GravarTelefone(telefone);

        }
        //Details alone
        public ActionResult Details(long? id)
        {
            return ObterVisaoTelefonePorId(id);
        }
        //Delete alone
        public ActionResult Delete(long? id)
        {
            return ObterVisaoTelefonePorId(id);
        }
        //Delete post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Telefone telefone = telefoneDAL.EliminarTelefonePorId(id);
                TempData["Message"] = "Telefone " + telefone.TelefoneId + " foi removido";
                return RedirectToAction("index");
            }
            catch
            {
                return View();
            }
        }
    }
}
