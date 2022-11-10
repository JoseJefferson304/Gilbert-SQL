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

        private byte[] SetLogotipo(HttpPostedFileBase logotipo)
        {
            var bytesLogotipo = new byte[logotipo.ContentLength];
            logotipo.InputStream.Read(bytesLogotipo, 0, logotipo.ContentLength);
            return bytesLogotipo;
        }
 
        public ActionResult Edit(Serviço serviço , HttpPostedFileBase logotipo = null, string chkRemoverImagem = null)
        {
            try { 
                if (ModelState.IsValid)
                {
                    if (chkRemoverImagem != null)
                    {
                        serviço.Logotipo = null;
                    }
                    if (logotipo != null)
                    {
                        serviço.LogotipoMimeType = logotipo.ContentType;
                        serviço.Logotipo = SetLogotipo(logotipo);
                    }
                    context.Entry(serviço).State = EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag(serviço);
                return View(serviço);
            }
            catch
            {
                ViewBag(serviço);
                return View(serviço);
            }
        }

        public FileContentResult GetLogotipo(long id)
        {
            Serviço serviço = context.Serviços.Find(id);
            if (serviço != null)
            {
                return File(serviço.Logotipo, serviço.LogotipoMimeType);
            }
            return null;
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