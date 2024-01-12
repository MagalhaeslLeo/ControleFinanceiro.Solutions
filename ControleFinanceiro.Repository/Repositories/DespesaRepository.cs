using ControleFinanceiro.Domain.Entidades;
using ControleFinanceiro.Domain.Interfaces;
using ControleFinanceiro.Repository.ContextDB;

namespace ControleFinanceiro.Repository.Repositories
{
    public class DespesaRepository : RepositoryBase<Despesa>, IDespesaRepository
    {
        public DespesaRepository(Context context) : base(context){}
    }
}
