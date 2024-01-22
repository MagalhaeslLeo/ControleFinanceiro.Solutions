using ControleFinanceiro.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFinanceiro.Repository.mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario> { 
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuario");
        builder.HasQueryFilter(d => !d.IsDeleted);
    }
}
}
