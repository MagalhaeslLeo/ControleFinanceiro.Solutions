using ControleFinanceiro.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Repository.mapping
{
    public class DemonstrativoFinanceiroMap : IEntityTypeConfiguration<DemonstrativoFinanceiro>
    {
        public void Configure(EntityTypeBuilder<DemonstrativoFinanceiro> builder)
        {
            builder.ToTable("DemonstrativoFinanceiro");
            builder.HasQueryFilter(d => !d.IsDeleted);
        }
    }
}
