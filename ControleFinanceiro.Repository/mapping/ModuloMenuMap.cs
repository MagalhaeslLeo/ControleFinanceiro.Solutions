using ControleFinanceiro.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Repository.mapping
{
    public class ModuloMenuMap : IEntityTypeConfiguration<ModuloMenu>
    {
        public void Configure(EntityTypeBuilder<ModuloMenu> builder)
        {
            builder.ToTable("SEGModuloMenu");
            builder.HasQueryFilter(d => !d.IsDeleted);
        }
    }
}
