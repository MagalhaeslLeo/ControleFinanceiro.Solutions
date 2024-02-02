using ControleFinanceiro.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Interfaces
{
    public interface IModuloMenuRepository : IRepositoryBase<ModuloMenu>
    {
        List<ModuloMenu> GetAllModuloMenu(string modulo);
    }
}
