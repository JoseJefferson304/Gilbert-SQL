using aula.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace aula.App_Start.Models
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Asp_Net_MVC_CS")
        {
            Database.SetInitializer<EFContext>(
            new DropCreateDatabaseIfModelChanges<EFContext>());
        }
        public DbSet<Serviço> Serviços { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
    }
}