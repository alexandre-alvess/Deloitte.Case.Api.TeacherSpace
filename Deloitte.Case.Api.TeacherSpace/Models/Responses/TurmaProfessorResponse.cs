using System.Text.Json.Serialization;

namespace Deloitte.Case.Api.TeacherSpace.Models.Responses
{
    /// <summary>
    /// Define a classe <see cref="TurmaProfessorResponse"/>.
    /// </summary>
    public class TurmaProfessorResponse
    {
        /// <summary>
        /// Obtém ou define o identificador da turma.
        /// </summary>
        [JsonPropertyName("turma_id")]
        public Guid TurmaId { get; set; }

        /// <summary>
        /// Obtém ou define o identificador do professor da turma.
        /// </summary>
        [JsonPropertyName("professor_id")]
        public Guid ProfessorId { get; set; }

        /// <summary>
        /// Obtém ou define o nome da turma.
        /// </summary>
        [JsonPropertyName("turma")]
        public string Turma { get; set; }
    }
}
