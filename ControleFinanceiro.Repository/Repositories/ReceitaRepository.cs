using ControleFinanceiro.Domain.Entidades;
using ControleFinanceiro.Domain.Interfaces;
using ControleFinanceiro.Repository.ContextDB;

namespace ControleFinanceiro.Repository.Repositories
{
    public class ReceitaRepository : RepositoryBase<Receita>, IReceitaRepository
    {
        public ReceitaRepository(Context context) : base(context){}
    }
}
