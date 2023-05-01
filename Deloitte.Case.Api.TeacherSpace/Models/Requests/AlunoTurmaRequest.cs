using Deloitte.Case.Api.TeacherSpace.Models.Bases;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Deloitte.Case.Api.TeacherSpace.Models.Requests
{
    /// <summary>
    /// Define a classe <see cref="AlunoTurmaRequest"/>.
    /// </summary>
    public class AlunoTurmaRequest : BaseRequest
    {
        /// <summary>
        /// Obtém ou define o identificador do aluno.
        /// </summary>
        [Required]
        [JsonPropertyName("aluno_id")]
        public Guid AlunoId { get; set; }

        /// <summary>
        /// Obtém ou define o identificador da turma.
        /// </summary>
        [Required]
        [JsonPropertyName("turma_id")]
        public Guid TurmaId { get; set; }
    }
}
