using Deloitte.Case.TeacherSpace.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Deloitte.Case.TeacherSpace.Infraestrutura.Configuracoes
{
    /// <summary>
    /// Define a classe <see cref="DisciplinaMap"/>.
    /// </summary>
    public class DisciplinaMap : BaseMap<Disciplina>
    {
        internal override void ConfiguradorInterno(EntityTypeBuilder<Disciplina> builder)
        {
            builder
                .ToTable("Disciplina")
                .HasKey(e => e.Id);

            builder
                .HasMany(e => e.Turmas)
                .WithOne(e => e.Disciplina)
                .HasForeignKey(e => e.DisciplinaId)
                .IsRequired();

            builder
                .Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(e => e.CargaHoraria)
                .IsRequired();
        }
    }
}
