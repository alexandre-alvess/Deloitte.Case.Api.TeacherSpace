using Deloitte.Case.Api.TeacherSpace.Models.Bases;
using System.Text.Json.Serialization;

namespace Deloitte.Case.Api.TeacherSpace.Models.Responses
{
    /// <summary>
    /// Define a classe <see cref="AlunoTurmaResponse"/>.
    /// </summary>
    public class AlunoTurmaResponse : BaseResponse
    {
        /// <summary>
        /// Obtém ou define o identificador do aluno.
        /// </summary>
        [JsonPropertyName("aluno_id")]
        public Guid AlunoId { get; set; }

        /// <summary>
        /// Obtém ou define o identificador da turma.
        /// </summary>
        [JsonPropertyName("turm_id")]
        public Guid TurmaId { get; set; }

        /// <summary>
        /// Obtém ou define o nome do aluno.
        /// </summary>
        [JsonPropertyName("aluno")]
        public string Aluno { get; set; }
    }
}
