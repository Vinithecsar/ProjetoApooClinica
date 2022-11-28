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
    public class ClientesController : Controller
    {
        private ClienteDAL clienteDAL = new ClienteDAL();
        private ActionResult ObterVisaoClientePorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = clienteDAL.ObterClientePorId((long)id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }
        private ActionResult GravarCliente(Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    clienteDAL.GravarCliente(cliente);
                    return RedirectToAction("index");
                }
                return View(cliente);
            }
            catch
            {
                return View(cliente);
            }
        }
        // GET: Clientes
        public ActionResult Index()
        {
            return View(clienteDAL.ObterClientesClassificadosPorCPF());
            //return View(context.Clientes.OrderBy(c => c.Nome));
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
        public ActionResult Create(Cliente cliente)
        {
            // IEnumerable<Cliente> a = cat.Where(c => c.ClienteId >0);
            //context.Clientes.Add(ca);
            //context.SaveChanges();
            //ca.ClienteId = cat.Select(c => c.ClienteId).Max() + 1;// type ;  1, 2, 3, 4
            //cat.Add(ca);
            //return RedirectToAction("Index");
            return GravarCliente(cliente);
        }
        //Edit alone
        public ActionResult Edit(long? id)
        {
            return ObterVisaoClientePorId(id);
        }
        //Edit post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cliente cliente)
        {
            return GravarCliente(cliente);
            
        }
        //Details alone
        public ActionResult Details(long? id)
        {
            return ObterVisaoClientePorId(id);
        }
        //Delete alone
        public ActionResult Delete(long? id)
        {
            return ObterVisaoClientePorId(id);
        }
        //Delete post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Cliente cliente = clienteDAL.EliminarClientePorId(id);
                TempData["Message"] = "Cliente " + cliente.Cpf.ToUpper() + " foi removido";
                return RedirectToAction("index");
            }
            catch
            {
                return View();
            }
        }
    }
}
