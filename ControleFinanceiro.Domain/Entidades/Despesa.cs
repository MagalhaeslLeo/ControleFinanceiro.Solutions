using ControleFinanceiro.Domain.Guids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Entidades
{
    public class Despesa: EntityGuid
    {
        public decimal valor { get; set; }

        public string descricao { get; set; }

        public DateTime periodo { get; set; }
    }
}
