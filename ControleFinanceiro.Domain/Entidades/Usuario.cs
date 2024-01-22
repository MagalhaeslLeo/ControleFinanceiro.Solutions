using ControleFinanceiro.Domain.Guids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Entidades
{
    public class Usuario : EntityGuid
    {
        public string usuario { get; set; }
        public string email { get; set; }
        public string senha { get; set; }   
    }
}
