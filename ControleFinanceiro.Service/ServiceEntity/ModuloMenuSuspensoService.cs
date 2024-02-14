using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Service.ServiceEntity
{
    public class ModuloMenuSuspensoService
    {
        public Guid Id { get; set; }
        public string NomeFuncionalidade { get; set; }

        public string UrlFuncionalidade { get; set; }

        public bool IndicadorAtivo { get; set; }

        public bool IsDeleted { get; set; }
    }
}
