using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Service.ServiceEntity
{
    public class DespesaService
    {
        public Guid Id { get; set; }
        public decimal valor { get; set; }

        public string descricao { get; set; }

        public DateTime periodo { get; set; }

        public bool IsDeleted { get; set; }
    }
}
