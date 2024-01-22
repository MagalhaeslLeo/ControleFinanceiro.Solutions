using ControleFinanceiro.Domain.Entidades;
using ControleFinanceiro.Domain.Interfaces;
using ControleFinanceiro.Repository.ContextDB;

namespace ControleFinanceiro.Repository.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(Context context) : base(context) { }
}
}

