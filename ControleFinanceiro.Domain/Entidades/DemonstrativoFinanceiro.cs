using ControleFinanceiro.Domain.Guids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Entidades
{
    public class DemonstrativoFinanceiro : EntityGuid
    {
        public decimal resultado { get; set; }
        public Guid Id_receita { get; set; }
        public Receita Receita { get; set; }
        public Guid Id_despesa { get; set; }
        public Despesa Despesa { get; set; }

    }
}
