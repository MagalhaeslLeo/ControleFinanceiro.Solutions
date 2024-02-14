using ControleFinanceiro.Domain.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Repository.mapping
{
    public class ModuloMenuSuspensoMap : IEntityTypeConfiguration<ModuloMenuSuspenso>
    {
        public void Configure(EntityTypeBuilder<ModuloMenuSuspenso> builder)
        {
            builder.ToTable("SEGFuncionalidade");
            builder.HasQueryFilter(d => !d.IsDeleted);
        }
    }
}

