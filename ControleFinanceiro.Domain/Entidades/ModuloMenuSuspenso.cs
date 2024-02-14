using ControleFinanceiro.Domain.Guids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Entidades
{
    public class ModuloMenuSuspenso : EntityGuid
    {
        public string NomeFuncionalidade { get; set; }

        public string UrlFuncionalidade { get; set; }

        public bool IndicadorAtivo { get; set; }

    }
}
