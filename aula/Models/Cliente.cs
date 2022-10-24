using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aula.Models
{
    public class Cliente
    {
        public long ClienteId{ get; set; }
        public string Nome{ get; set; }
        public long Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }

        public virtual ICollection<Agendamento> Agendamentos { get; set; }
    }
}