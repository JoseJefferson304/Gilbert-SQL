using aula.App_Start.Models;
using aula.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace aula.Controllers
{
    public class ClientesController : Controller
    {
        private EFContext context = new EFContext();

        // GET: Clientes
        public ActionResult Index()
        {
            return View(
                //clientes
                context.Clientes.OrderBy(c => c.Nome)
                );
        }
        //oi ola
        // GET: Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente)
        {
            //cliente.ClienteId = clientes.Select(m => m.ClienteId).Max() + 1;
            context.Clientes.Add(cliente);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Clientes/Edit/5
        [HttpGet]
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Cliente cliente = clientes.Where(m => m.ClienteId == id).First();

            Cliente cliente = context.Clientes.Find(id);

            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                context.Entry(cliente).State = EntityState.Modified;
                context.SaveChanges();
                //clientes.Remove(
                //clientes.Where(c => c.ClienteId == cliente.ClienteId).First());
                //clientes.Add(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: Clientes/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = context.Clientes.Find(id);
            //Cliente cliente = clientes.Where(m => m.ClienteId == id).First();
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = context.Clientes.Find(id);
            //Cliente cliente = clientes.Where(m => m.ClienteId == id).First();
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Cliente cliente = context.Clientes.Find(id);
            //Cliente cliente = clientes.Where(m => m.ClienteId == id).First();
            context.Clientes.Remove(cliente);
            //clientes.Remove(cliente);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}