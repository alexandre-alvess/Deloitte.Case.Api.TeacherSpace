using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Deloitte.Case.Api.TeacherSpace.Models.Bases
{
    /// <summary>
    /// Define a classe <see cref="PessoaBase"/>.
    /// </summary>
    public class PessoaBase : BaseRequest
    {
        /// <summary>
        /// Obtém ou define o nome.
        /// </summary>
        [JsonPropertyName("nome")]
        [Required(AllowEmptyStrings = false)]
        [MinLength(3)]
        [MaxLength(80)]
        public string Nome { get; set; }

        /// <summary>
        /// Obtém ou define o email.
        /// </summary>
        [JsonPropertyName("email")]
        [Required(AllowEmptyStrings = false)]
        [EmailAddress]
        [MaxLength(180)]
        public string Email { get; set; }

        /// <summary>
        /// Obtém ou define a data de nascimento.
        /// </summary>
        [JsonPropertyName("data_nascimento")]
        [Required]
        public DateTime DataNascimento { get; set; }
    }
}
