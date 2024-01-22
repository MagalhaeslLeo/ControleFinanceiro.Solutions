using ControleFinanceiro.Service.ServiceEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Service.Interfaces
{
    public interface IServiceUsuario
    {
        Task AddSave(UsuarioService usuario);
        Task MarkDeleted(UsuarioService usuario);

        Task<IEnumerable<UsuarioService>> GetAll();

        Task<UsuarioService> GetById(Guid id);

        Task<UsuarioService> Update(UsuarioService usuario);
    }
}
