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
                .ToTable("Turma")
                .HasKey(e => e.Id);

            builder
                .HasMany(e => e.Alunos)
                .WithMany(e => e.Turmas)
                .UsingEntity(
                    "AlunoTurma",
                    l => l.HasOne(typeof(Aluno)).WithMany().HasForeignKey("AlunosId").HasPrincipalKey(nameof(Aluno.Id)),
                    r => r.HasOne(typeof(Turma)).WithMany().HasForeignKey("TurmasId").HasForeignKey(nameof(Turma.Id)),
                    j => j.HasKey("TurmasId", "AlunosId"));

            builder
                .Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(80);
        }
    }
}
