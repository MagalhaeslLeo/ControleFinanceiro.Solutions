using ControleFinanceiro.Domain.Entidades;
using ControleFinanceiro.Domain.Interfaces;
using ControleFinanceiro.Repository.ContextDB;

namespace ControleFinanceiro.Repository.Repositories
{
    public class ModuloMenuRepository : RepositoryBase<ModuloMenu>, IModuloMenuRepository
    {
        public ModuloMenuRepository(Context context) : base(context) {}
    }
}
