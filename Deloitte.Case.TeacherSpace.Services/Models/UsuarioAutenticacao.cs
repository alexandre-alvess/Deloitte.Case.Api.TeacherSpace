using Deloitte.Case.TeacherSpace.Domain.Utilitarios.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Deloitte.Case.TeacherSpace.Services.Models
{
    /// <summary>
    /// Obtém ou define a classe <see cref="UsuarioAutenticacao"/>.
    /// </summary>
    public class UsuarioAutenticacao
    {
        /// <summary>
        /// Obtém ou define o token de autenticação.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Obtém ou define o identificador do usuário.
        /// </summary>
        public Guid UsuarioId { get; set; }

        /// <summary>
        /// Obtém ou define o identificador da entidade. 
        /// </summary>
        public Guid EntidadeId { get; set; }

        /// <summary>
        /// Obtém ou define o tipo de perfil do usuário.
        /// </summary>
        public EnumTipoPerfilUsuario TipoPerfilUsuario { get; set; }

        /// <summary>
        /// Obtém ou define o usuários.
        /// </summary>
        public UsuarioModel Usuario { get; set; }
    }
}
