using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace aula.Models
{
    public class Agendamento
    {
        public long AgendamentoId { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Data de Cadastro")]
        [Required(ErrorMessage = "Informe a data de cadastro do produto")]
        public DateTime Data{ get; set; }
        public long? ClienteId { get; set; }
        public long? ServiçoId { get; set; }
        public long? FuncionarioId { get; set; }
        public string Horario { get; set; }
        public Cliente Cliente { get; set; }
        public Serviço Serviço { get; set; }
        public Funcionario Funcionario { get; set; }
    }
}