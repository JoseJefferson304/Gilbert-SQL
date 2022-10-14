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
    public class ServiçosController : Controller
    {
        private EFContext context = new EFContext();

        // GET: Serviços ADWA
        public ActionResult Index()
        {
            return View(
                //serviços HAHAHAH HOHOHOHOHOa aaaaaaaaa uuuuuuuuuuu
                context.Serviços.OrderBy(c => c.Descrição)
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
        public ActionResult Create(Serviço serviço)
        {
            //serviço.ServiçoId = serviços.Select(m => m.ServiçoId).Max() + 1;
            context.Serviços.Add(serviço);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Serviços/Edit/5
        [HttpGet]
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Serviço serviço = serviços.Where(m => m.ServiçoId == id).First();

            Serviço serviço = context.Serviços.Find(id);

            if (serviço == null)
            {
                return HttpNotFound();
            }
            return View(serviço);
        }

        // POST: Serviços/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Serviço serviço)
        {
            if (ModelState.IsValid)
            {
                context.Entry(serviço).State = EntityState.Modified;
                context.SaveChanges();
                //serviços.Remove(
                //serviços.Where(c => c.ServiçoId == serviço.ServiçoId).First());
                //serviços.Add(serviço);
                return RedirectToAction("Index");
            }
            return View(serviço);
        }

        // GET: Serviços/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Serviço serviço = context.Serviços.Find(id);
            //Serviço serviço = serviços.Where(m => m.ServiçoId == id).First();
            if (serviço == null)
            {
                return HttpNotFound();
            }
            return View(serviço);
        }

        // GET: Serviços/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Serviço serviço = context.Serviços.Find(id);
            //Serviço serviço = serviços.Where(m => m.ServiçoId == id).First();
            if (serviço == null)
            {
                return HttpNotFound();
            }
            return View(serviço);
        }

        // POST: Serviços/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Serviço serviço = context.Serviços.Find(id);
            //Serviço serviço = serviços.Where(m => m.ServiçoId == id).First();
            context.Serviços.Remove(serviço);
            //serviços.Remove(serviço);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}