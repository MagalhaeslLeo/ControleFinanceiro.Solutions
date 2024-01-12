using ControleFinanceiro.Domain.Guids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Interfaces
{
    public interface IRepositoryBase<T> where T: EntityGuid
    {
        Task AddSave(T entity);
        Task MarkDeleted(T entity);

        Task<IEnumerable<T>> GetAll();

        Task <T> GetById(Guid id);

        Task <T> Update(T entity);
    }
}
