using Deloitte.Case.TeacherSpace.Core;
using Deloitte.Case.TeacherSpace.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Deloitte.Case.TeacherSpace.Infraestrutura.Configuracoes
{
    /// <summary>
    /// Define a classe <see cref="UsuarioMap"/>.
    /// </summary>
    public class UsuarioMap : BaseMap<Usuario>
    {
        internal override void ConfiguradorInterno(EntityTypeBuilder<Usuario> builder)
        {
            builder
                .ToTable("Usuarios")
                .HasKey(e => e.Id);

            builder
                .HasOne(e => e.Pessoa)
                .WithOne()
                .HasForeignKey<Usuario>(e => e.PessoaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_Pessoa")
                .IsRequired();

            builder
                .Property(e => e.Login)
                .HasMaxLength(100)
                .IsRequired();
            
            builder
                .Property(e => e.Senha)
                .HasMaxLength(200)
                .IsRequired()
                .HasConversion(v => v.Encrypt(), v => v.Decrypt()).IsUnicode(false);
        }
    }
}
