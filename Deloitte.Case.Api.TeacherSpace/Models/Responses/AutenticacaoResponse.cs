using Deloitte.Case.TeacherSpace.Domain.Utilitarios.Enumeradores;
using System.Text.Json.Serialization;

namespace Deloitte.Case.Api.TeacherSpace.Models.Responses
{
    /// <summary>
    /// Define a classe <see cref="AutenticacaoResponse"/>.
    /// </summary>
    public class AutenticacaoResponse
    {
        /// <summary>
        /// Obtém ou define o token de autenticação.
        /// </summary>
        [JsonPropertyName("token")]
        public string Token { get; set; }

        /// <summary>
        /// Obtém ou define o identificador do usuário.
        /// </summary>
        [JsonPropertyName("usuario_id")]
        public Guid UsuarioId { get; set; }

        /// <summary>
        /// Obtém ou define o identificador da entidade. 
        /// </summary>
        [JsonPropertyName("entidade_id")]
        public Guid EntidadeId { get; set; }

        /// <summary>
        /// Obtém ou define o tipo de perfil do usuário.
        /// </summary>
        [JsonPropertyName("tipo_perfil_usuario")]
        public EnumTipoPerfilUsuario TipoPerfilUsuario { get; set; }

        /// <summary>
        /// Obtém ou define o usuário.
        /// </summary>
        [JsonPropertyName("usuario")]
        public UsuarioResponse Usuario { get; set; }
    }
}
