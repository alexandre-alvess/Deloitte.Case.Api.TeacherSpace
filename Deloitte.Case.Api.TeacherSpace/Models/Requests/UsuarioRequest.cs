using Deloitte.Case.Api.TeacherSpace.Models.Bases;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Deloitte.Case.Api.TeacherSpace.Models.Requests
{
    /// <summary>
    /// Define a classe <see cref="UsuarioRequest"/>.
    /// </summary>
    public class UsuarioRequest : BaseRequest
    {
        /// <summary>
        /// Obtém ou define o nome do usuário.
        /// </summary>
        [JsonPropertyName("nome")]
        [Required(AllowEmptyStrings = false)]
        [MinLength(3)]
        [MaxLength(80)]
        public string Nome { get; set; }

        /// <summary>
        /// Obtém ou define o login do usuário.
        /// </summary>
        [JsonPropertyName("login")]
        [Required(AllowEmptyStrings = false)]
        [EmailAddress]
        [MaxLength(180)]
        public string Login { get; set; }

        /// <summary>
        /// Obtém ou define a senha do usuário.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [MinLength(6)]
        [MaxLength(50)]
        [JsonPropertyName("senha")]
        public string Senha { get; set; }
    }
}
