using ControleFinanceiro.Service.ServiceEntity;
using ControleFinanceiro.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Service.Interfaces
{
    public interface IServiceModuloMenu
    {
        Task AddSave(ModuloMenuService moduloMenu);
        Task MarkDeleted(ModuloMenuService moduloMenu);

        Task<IEnumerable<ModuloMenuService>> GetAll();

        Task<ModuloMenuService> GetById (Guid id);

        Task<ModuloMenuService> Update(ModuloMenuService modulomenu);

        List<ModuloMenuService> GetAllModuloMenu(string modulo);
        List<ModuloMenuSuspensoService> GetAllModuloMenuSuspenso();
    }
}
