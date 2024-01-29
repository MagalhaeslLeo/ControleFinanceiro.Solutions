using ControleFinanceiro.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Service.ServiceEntity
{
    public class DemonstrativoFinanceiroService
    {
        public Guid Id { get; set; }
        public decimal resultado { get; set; }

        public Guid Id_receita { get; set; }

        public Receita Receita { get; set; }

        public Guid Id_despesa { get; set; }

        public Despesa Despesa { get; set; }

        public bool IsDeleted { get; set; }
    }
}
