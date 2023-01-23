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
    public class AgendamentosController : Controller
    {
        private EFContext context = new EFContext();
        //// GET: Agendamentos
        //public ActionResult Index()
        //{
        //    return View(context.Agendamentos.OrderBy(c => c.Nome));
        //}

        // GET: Agendamentos
        public ActionResult Index()
        {
            var agendamentos =
            context.Agendamentos.Include(c => c.Cliente).Include(f => f.Funcionario).Include(f => f.Serviço).
            OrderBy(n => n.Data);
            return View(agendamentos);
        }

        // GET: Agendamentos/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agendamento agendamento = context.Agendamentos.Where(p => p.AgendamentoId == id).
            Include(c => c.Cliente).Include(f => f.Funcionario).Include(f => f.Serviço).First();
            if (agendamento == null)
            {
                return HttpNotFound();
            }
            return View(agendamento);
        }

        // GET: Agendamentos/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(context.Clientes.OrderBy(b => b.Nome),
            "ClienteId", "Nome");
            ViewBag.FuncionarioId = new SelectList(context.Funcionarios.OrderBy(b => b.Nome),
            "FuncionarioId", "Nome");
            ViewBag.ServiçoId = new SelectList(context.Serviços.OrderBy(b => b.Descrição),
            "ServiçoId", "Descrição");
            return View();
        }

        // POST: Agendamentos/Create
        [HttpPost]
        public ActionResult Create(Agendamento agendamento)
        {
            try
            {
                agendamento.Horario = "08:00";
                context.Agendamentos.Add(agendamento);
                context.SaveChanges();
                agendamento.Horario = "08:30";
                context.Agendamentos.Add(agendamento);
                context.SaveChanges();
                agendamento.Horario = "09:00";
                context.Agendamentos.Add(agendamento);
                context.SaveChanges();
                agendamento.Horario = "09:30";
                context.Agendamentos.Add(agendamento);
                context.SaveChanges();
                agendamento.Horario = "10:00";
                context.Agendamentos.Add(agendamento);
                context.SaveChanges();
                agendamento.Horario = "10:30";
                context.Agendamentos.Add(agendamento);
                context.SaveChanges();
                agendamento.Horario = "11:00";
                context.Agendamentos.Add(agendamento);
                context.SaveChanges();
                agendamento.Horario = "11:30";
                context.Agendamentos.Add(agendamento);
                context.SaveChanges();
                agendamento.Horario = "12:00";
                context.Agendamentos.Add(agendamento);
                context.SaveChanges();
                agendamento.Horario = "14:00";
                context.Agendamentos.Add(agendamento);
                agendamento.Horario = "14:30";
                context.Agendamentos.Add(agendamento);
                context.SaveChanges();

                context.SaveChanges();



                return RedirectToAction("Index");
            }
            catch
            {
                return View(agendamento);
            }
        }

        // GET: Agendamentos/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agendamento agendamento = context.Agendamentos.Find(id);
            if (agendamento == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(context.Clientes.OrderBy(b => b.Nome), "ClienteId",
            "Nome", agendamento.ClienteId);
            ViewBag.ServiçoId = new SelectList(context.Serviços.OrderBy(b => b.Descrição), "ServiçoId",
            "Descrição", agendamento.ServiçoId);
            ViewBag.FuncionarioId = new SelectList(context.Funcionarios.OrderBy(b => b.Nome), "FuncionarioId",
            "Nome", agendamento.FuncionarioId);
            return View(agendamento);
        }

        // POST: Agendamentos/Edit/5
        [HttpPost]
        public ActionResult Edit(Agendamento agendamento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Entry(agendamento).State = EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(agendamento);
            }
            catch
            {
                return View(agendamento);
            }
        }

        // GET: Agendamentos/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agendamento agendamento = context.Agendamentos.Where(p => p.AgendamentoId == id).
            Include(c => c.Cliente).Include(f => f.Funcionario).Include(f => f.Serviço).First();
            if (agendamento == null)
            {
                return HttpNotFound();
            }
            return View(agendamento);
        }

        // POST: Agendamentos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Agendamento agendamento = context.Agendamentos.Find(id);
                context.Agendamentos.Remove(agendamento);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}