using Deloitte.Case.TeacherSpace.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Deloitte.Case.TeacherSpace.Infraestrutura.Configuracoes
{
    /// <summary>
    /// Define a classe <see cref="BaseMap"/>.
    /// </summary>
    public abstract class BaseMap<TEntidade> : IEntityTypeConfiguration<TEntidade>
        where TEntidade : EntidadeBase
    {
        public void Configure(EntityTypeBuilder<TEntidade> builder)
        {
            builder.Property(e => e.Id).HasDefaultValueSql("NEWID()");
            builder.Property(e => e.Ativo);

            ConfiguradorInterno(builder);
        }

        internal abstract void ConfiguradorInterno(EntityTypeBuilder<TEntidade> builder);
    }
}
