using Deloitte.Case.TeacherSpace.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Deloitte.Case.TeacherSpace.Infraestrutura.Configuracoes
{
    /// <summary>
    /// Define a classe <see cref="BoletimMap"/>.
    /// </summary>
    public class BoletimMap : BaseMap<Boletim>
    {
        internal override void ConfiguradorInterno(EntityTypeBuilder<Boletim> builder)
        {
            builder
                .ToTable("Boletins")
                .HasKey(e => e.Id);

            builder
                .Property(e => e.Nota)
                .IsRequired();

            builder
                .Property(e => e.DataEntrega)
                .IsRequired();
        }
    }
}
