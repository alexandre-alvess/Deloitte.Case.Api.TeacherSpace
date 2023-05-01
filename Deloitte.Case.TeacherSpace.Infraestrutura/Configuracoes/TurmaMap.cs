using Deloitte.Case.TeacherSpace.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Deloitte.Case.TeacherSpace.Infraestrutura.Configuracoes
{
    /// <summary>
    /// Define a classe <see cref="TurmaMap"/>.
    /// </summary>
    public class TurmaMap : BaseMap<Turma>
    {
        internal override void ConfiguradorInterno(EntityTypeBuilder<Turma> builder)
        {
            builder
                .ToTable("Turmas")
                .HasKey(e => e.Id);

            builder
                .HasMany(e => e.Alunos)
                .WithMany(e => e.Turmas)
                .UsingEntity<AlunoTurma>(
                    l => l.HasOne<Aluno>(e => e.Aluno).WithMany(e => e.AlunoTurmas),
                    r => r.HasOne<Turma>(e => e.Turma).WithMany(e => e.AlunoTurmas),
                    j => j.Property(e => e.Ativo).HasDefaultValue(true));

            builder
                .Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(80);
        }
    }
}
