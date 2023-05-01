using Deloitte.Case.TeacherSpace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Deloitte.Case.TeacherSpace.Infraestrutura.Configuracoes
{
    /// <summary>
    /// Define a classe <see cref="ProfessorMap"/>.
    /// </summary>
    public class ProfessorMap : BaseMap<Professor>
    {
        internal override void ConfiguradorInterno(EntityTypeBuilder<Professor> builder)
        {
            builder
                .ToTable("Professores")
                .HasKey(e => e.Id);

            builder
                .HasMany(e => e.Turmas)
                .WithOne(e => e.Professor)
                .HasForeignKey(e => e.ProfessorId)
                .IsRequired();

            builder
                .HasOne(e => e.Pessoa)
                .WithOne()
                .HasForeignKey<Professor>(e => e.PessoaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Professor_Pessoa")
                .IsRequired();
        }
    }
}
