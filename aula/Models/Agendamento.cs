using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aula.Models
{
    public class Agendamento
    {
        public long? AgendamentoId { get; set; }
        public string Data{ get; set; }
        public long? ClienteId { get; set; }
        public long? ServiçoId { get; set; }
        public long? FuncionarioId { get; set; }
        public Cliente Cliente { get; set; }
        public Serviço Serviço { get; set; }
        public Funcionario Funcionario { get; set; }
    }
}