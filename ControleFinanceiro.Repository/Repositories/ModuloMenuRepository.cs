using ControleFinanceiro.Domain.Entidades;
using ControleFinanceiro.Domain.Interfaces;
using ControleFinanceiro.Repository.ContextDB;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.Repository.Repositories
{
    public class ModuloMenuRepository : RepositoryBase<ModuloMenu>, IModuloMenuRepository
    {
        public ModuloMenuRepository(Context context) : base(context) { }

        public List<ModuloMenu> GetAllModuloMenu(string module)
        {
            var query = @"select 
                          Id,
                          Controller,
                          [Action],
                          Icon,
                          Title,
                          UrlModule,
                          CreatedAt,
                          IsDeleted
                          from SEGModuloMenu
                          where UrlModule = @modulo";
            var queryReturn = context.ModuloMenu.FromSqlRaw(query, new SqlParameter("@modulo", module)).ToList();
            return queryReturn;
        }
        public List<ModuloMenuSuspenso> GetAllModuloMenuSuspenso()
        {
            var query = @"select 
                          Id,
                          NomeFuncionalidade,
                          UrlFuncionalidade,
                          IndicadorAtivo,
                          IsDeleted
                          from SEGFuncionalidade";
            var queryReturn = context.ModuloMenuSuspenso.FromSqlRaw(query).ToList();
            return queryReturn;
        }
    }
}
