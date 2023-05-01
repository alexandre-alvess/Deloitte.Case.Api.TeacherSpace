using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Deloitte.Case.Api.TeacherSpace.Models.Requests
{
    /// <summary>
    /// Define a classe <see cref="AutenticacaoRequest"/>.
    /// </summary>
    public class AutenticacaoRequest
    {
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
        [JsonPropertyName("senha")]
        [Required(AllowEmptyStrings = false)]
        [MinLength(6)]
        [MaxLength(50)]
        public string Senha { get; set; }
    }
}
