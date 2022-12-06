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
    public class EnderecosController : Controller
    {
        //metodos privados (inicio)
        private ActionResult GravarEndereco(Endereco endereco)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    enderecoDAL.GravarEndereco(endereco);
                    return RedirectToAction("Index");
                }
                PopularViewBag(endereco);
                return View(endereco);
            }
            catch
            {
                return View(endereco);
            }
        }
        private ActionResult ObterVisaoEnderecoPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = enderecoDAL.ObterEnderecosPorId((long)id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        private void PopularViewBag(Endereco endereco = null)
        {
            if (endereco == null)
            {
                ViewBag.UsuarioId = new SelectList(clienteDAL.ObterClientesClassificadosPorCPF(), "UsuarioId", "Nome");
            }
            else
            {
                ViewBag.UsuarioId = new SelectList(clienteDAL.ObterClientesClassificadosPorCPF(), "UsuarioId", "Nome", endereco.UsuarioId);
            }
        }
        //metodos privados (fim)


        //private EFContext context = new EFContext();
        private EnderecoDAL enderecoDAL = new EnderecoDAL();
        private ClienteDAL clienteDAL = new ClienteDAL();

        // GET: Enderecos
        public ActionResult Index()
        {
            return View(enderecoDAL.ObterEnderecosClassificadosPorId());
        }

        // GET: Enderecos/Create
        public ActionResult Create()
        {
            PopularViewBag();
            return View();
        }

        // POST: Enderecos/Create
        [HttpPost]
        public ActionResult Create(Endereco endereco)
        {
            return GravarEndereco(endereco);
        }

        // GET: Enderecos/Edit/5
        public ActionResult Edit(long? id)
        {
            PopularViewBag(enderecoDAL.ObterEnderecosPorId((long)id));
            return ObterVisaoEnderecoPorId(id);
        }

        // POST: Enderecos/Edit/5
        [HttpPost]
        public ActionResult Edit(Endereco endereco)
        {
            return GravarEndereco(endereco);
        }

        // GET: Enderecos/Details/5
        public ActionResult Details(long? id)
        {
            return ObterVisaoEnderecoPorId(id);
        }

        // GET: Enderecos/Delete/5

        public ActionResult Delete(long? id)
        {
            return ObterVisaoEnderecoPorId(id);
        }

        // POST: Enderecos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Endereco endereco = enderecoDAL.EliminarEnderecoPorId(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}