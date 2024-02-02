using ControleFinanceiro.Domain.Entidades;
using ControleFinanceiro.Domain.Interfaces;
using ControleFinanceiro.Repository.ContextDB;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.Repository.Repositories
{
    public class ModuloMenuRepository : RepositoryBase<ModuloMenu>, IModuloMenuRepository
    {
        public ModuloMenuRepository(Context context) : base(context) {}

        public List<ModuloMenu> GetAllModuloMenu(string modulo)
        {
            var query = @"select 
                          Id,
                          Controller,
                          [Action],
                          Icon,
                          Title,
                          UrlModule,
                          CreatedAt,
                          Deleted
                          from ModuloMenu
                          where UrlModule = @modulo";
            var queryReturn = context.ModuloMenu.FromSqlRaw(query, new SqlParameter("@modulo", modulo)).ToList();
            return queryReturn;
        }
    }
}
