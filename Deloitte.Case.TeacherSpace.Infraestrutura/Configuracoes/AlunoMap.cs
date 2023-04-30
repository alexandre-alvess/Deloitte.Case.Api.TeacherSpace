using Deloitte.Case.TeacherSpace.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Deloitte.Case.TeacherSpace.Infraestrutura.Configuracoes
{
    /// <summary>
    /// Define a classe <see cref="AlunoMap"/>.
    /// </summary>
    public class AlunoMap : BaseMap<Aluno>
    {
        internal override void ConfiguradorInterno(EntityTypeBuilder<Aluno> builder)
        {
            builder
                .ToTable("Aluno")
                .HasKey(e => e.Id);

            builder
                .HasMany(e => e.Boletins)
                .WithOne(e => e.Aluno)
                .HasForeignKey(e => e.AlunoId)
                .IsRequired();

            builder
                .HasOne(e => e.Pessoa)
                .WithOne()
                .HasForeignKey<Aluno>(e => e.PessoaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Aluno_Pessoa")
                .IsRequired();
        }
    }
}
