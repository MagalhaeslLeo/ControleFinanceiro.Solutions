using ControleFinanceiro.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Repository.ContextDB
{
    public class Context : DbContext
    {
        public DbSet<Despesa> Despesa { get; set; }    
        public DbSet<Receita> Receita { get; set; }
        public DbSet<Usuario> CADUsuario { get; set; }
        public DbSet<DemonstrativoFinanceiro> CADDemonstrativoFinanceiro { get; set; }
        public DbSet<ModuloMenu> ModuloMenu { get; set; }

        public DbSet<ModuloMenuSuspenso> ModuloMenuSuspenso { get; set; }
        public Context(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
