using Deloitte.Case.TeacherSpace.Domain.Entidades.Base;
using Deloitte.Case.TeacherSpace.Domain.Utilitarios.Enumeradores;
using System.ComponentModel.DataAnnotations.Schema;

namespace Deloitte.Case.TeacherSpace.Domain.Entidades
{
    /// <summary>
    /// Define a classe <see cref="Usuario"/>.
    /// </summary>
    public class Usuario : EntidadeBase
    {
        /// <summary>
        /// Obtém ou define o identificador da pessoa.
        /// </summary>
        public Guid PessoaId { get; set; }

        /// <summary>
        /// Obtém ou define a pessoa.
        /// </summary>
        public virtual Pessoa Pessoa { get; set; }

        /// <summary>
        /// Obtém ou define o Login.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Obtém ou define a senha.
        /// </summary>
        public string Senha { get; set; }

        /// <summary>
        /// Obtém ou define o tipo de perfil do usuário.
        /// </summary>
        [NotMapped]
        public EnumTipoPerfilUsuario TipoPerfil { get; set; }
    }
}
