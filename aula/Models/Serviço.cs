using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aula.Models
{
    public class Serviço
    {
        public long ServiçoId { get; set; }

        public string Descrição { get; set; }

        public string Valor { get; set; }

        public virtual ICollection<Agendamento> Agendamentos { get; set; }

        public string LogotipoMimeType { get; set; }

        public byte[] Logotipo { get; set; }
    }
}