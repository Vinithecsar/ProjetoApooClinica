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
    public class SecretariosController : Controller
    {
        private SecretarioDAL secretarioDAL = new SecretarioDAL();
        private ActionResult ObterVisaoSecretarioPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Secretario secretario = secretarioDAL.ObterSecretarioPorId((long)id);
            if (secretario == null)
            {
                return HttpNotFound();
            }
            return View(secretario);
        }
        private ActionResult GravarSecretario(Secretario secretario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    secretarioDAL.GravarSecretario(secretario);
                    return RedirectToAction("index");
                }
                return View(secretario);
            }
            catch
            {
                return View(secretario);
            }
        }
        // GET: Secretarios
        public ActionResult Index()
        {
            return View(secretarioDAL.ObterSecretariosClassificadosPorNome());
            //return View(context.Secretarios.OrderBy(c => c.Nome));
            //return View(cat);
        }
        // Create get
        public ActionResult Create()
        {
            return View();
        }
        // Create post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Secretario secretario)
        {
            // IEnumerable<Secretario> a = cat.Where(c => c.SecretarioId >0);
            //context.Secretarios.Add(ca);
            //context.SaveChanges();
            //ca.SecretarioId = cat.Select(c => c.SecretarioId).Max() + 1;// type ;  1, 2, 3, 4
            //cat.Add(ca);
            //return RedirectToAction("Index");
            return GravarSecretario(secretario);
        }
        //Edit alone
        public ActionResult Edit(long? id)
        {
            return ObterVisaoSecretarioPorId(id);
        }
        //Edit post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Secretario secretario)
        {
            return GravarSecretario(secretario);

        }
        //Details alone
        public ActionResult Details(long? id)
        {
            return ObterVisaoSecretarioPorId(id);
        }
        //Delete alone
        public ActionResult Delete(long? id)
        {
            return ObterVisaoSecretarioPorId(id);
        }
        //Delete post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Secretario secretario = secretarioDAL.EliminarSecretarioPorId(id);
                TempData["Message"] = "Secretario " + secretario.UsuarioId + " foi removido";
                return RedirectToAction("index");
            }
            catch
            {
                return View();
            }
        }
    }
}