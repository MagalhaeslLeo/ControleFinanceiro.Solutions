using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Service.ServiceEntity
{
    public class ModuloMenuService
    {
        public Guid Id { get; set; }
        public string Controller { get; set; }

        public string Action { get; set; }

        public string Icon { get; set; }

        public string Title { get; set; }

        public string UrlModule { get; set; }

        public bool IsDeleted { get; set; }
    }
}
