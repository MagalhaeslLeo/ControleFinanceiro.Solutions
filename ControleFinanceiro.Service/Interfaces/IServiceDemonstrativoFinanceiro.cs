using ControleFinanceiro.Service.ServiceEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Service.Interfaces
{
    public interface IServiceDemonstrativoFinanceiro
    {
        Task AddSave(DemonstrativoFinanceiroService demonstrativoFinanceiro);
        Task MarkDeleted(DemonstrativoFinanceiroService demonstrativoFinanceiro);

        Task<IEnumerable<DemonstrativoFinanceiroService>> GetAll();

        Task<DemonstrativoFinanceiroService> GetById(Guid id);

        Task<DemonstrativoFinanceiroService> Update(DemonstrativoFinanceiroService demonstrativoFinanceiro);
    }
}
