using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Service.ServiceEntity
{
    public class UsuarioService
    {
        public Guid Id { get; set; }
        public string usuario { get; set; }

        public string email { get; set; }

        public string senha { get; set; }
        public bool IsDeleted { get; set; }
    }
}
