using ControleFinanceiro.Service.ServiceEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Service.Interfaces
{
    public interface IServiceReceita
    {
        Task AddSave(ReceitaService receita);
        Task MarkDeleted(Guid Id);

        Task<IEnumerable<ReceitaService>> GetAll();
 
        Task<ReceitaService> GetById(Guid id);

        Task<ReceitaService> Update(ReceitaService receita);
    }
}
