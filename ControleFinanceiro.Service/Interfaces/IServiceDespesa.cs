using ControleFinanceiro.Service.ServiceEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Service.Interfaces
{
    public interface IServiceDespesa
    {
        Task AddSave(DespesaService despesa);
        Task MarkDeleted(Guid Id);

        Task<IEnumerable<DespesaService>> GetAll();

        Task<DespesaService> GetById(Guid id);

        Task<DespesaService> Update(DespesaService despesa);
    }
}
