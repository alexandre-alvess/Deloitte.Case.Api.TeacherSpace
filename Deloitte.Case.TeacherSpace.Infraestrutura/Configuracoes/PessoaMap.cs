using Deloitte.Case.TeacherSpace.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Deloitte.Case.TeacherSpace.Infraestrutura.Configuracoes
{
    /// <summary>
    /// Define a classe <see cref="PessoaMap"/>.
    /// </summary>
    public class PessoaMap : BaseMap<Pessoa>
    {
        internal override void ConfiguradorInterno(EntityTypeBuilder<Pessoa> builder)
        {
            builder
                .ToTable("Pessoas")
                .HasKey(e => e.Id);

            builder
                .Property(e => e.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(e => e.Email)
                .HasMaxLength(200)
                .IsRequired();

            builder
                .Property(e => e.DataNascimento)
                .IsRequired();
        }
    }
}
