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
    public class FuncionariosController : Controller
    {
        private EFContext context = new EFContext();

        // GET: Funcionarios
        public ActionResult Index()
        {
            return View(
                //funcionarios
                context.Funcionarios.OrderBy(c => c.Nome)
                );
        }

        // GET: Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Funcionario funcionario)
        {
            //funcionario.FuncionarioId = funcionarios.Select(m => m.FuncionarioId).Max() + 1;
            context.Funcionarios.Add(funcionario);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Funcionarios/Edit/5
        [HttpGet]
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Funcionario funcionario = funcionarios.Where(m => m.FuncionarioId == id).First();
 
            Funcionario funcionario = context.Funcionarios.Find(id);

            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // POST: Funcionarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                context.Entry(funcionario).State = EntityState.Modified;
                context.SaveChanges();
                //funcionarios.Remove(
                    //funcionarios.Where(c => c.FuncionarioId == funcionario.FuncionarioId).First());
                //funcionarios.Add(funcionario);
                return RedirectToAction("Index");
            }
            return View(funcionario);
        }

        // GET: Funcionarios/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = context.Funcionarios.Find(id);
            //Funcionario funcionario = funcionarios.Where(m => m.FuncionarioId == id).First();
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // GET: Funcionarios/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = context.Funcionarios.Find(id);
            //Funcionario funcionario = funcionarios.Where(m => m.FuncionarioId == id).First();
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Funcionario funcionario = context.Funcionarios.Find(id);
            //Funcionario funcionario = funcionarios.Where(m => m.FuncionarioId == id).First();
            context.Funcionarios.Remove(funcionario);
            //funcionarios.Remove(funcionario);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}