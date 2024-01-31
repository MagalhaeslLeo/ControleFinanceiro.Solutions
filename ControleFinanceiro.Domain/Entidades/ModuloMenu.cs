using ControleFinanceiro.Domain.Guids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Entidades
{
    public class ModuloMenu : EntityGuid
    {
        public string Controller {  get; set; }

        public string Action { get; set; }

        public string Icon { get; set; }

        public string Title { get; set; }

        public string UrlModule { get; set; }

    }
}
