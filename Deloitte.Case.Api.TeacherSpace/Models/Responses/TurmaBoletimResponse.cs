using System.Text.Json.Serialization;

namespace Deloitte.Case.Api.TeacherSpace.Models.Responses
{
    /// <summary>
    /// Define a classe <see cref="TurmaBoletimResponse"/>.
    /// </summary>
    public class TurmaBoletimResponse
    {
        /// <summary>
        /// Obtém ou define a turma.
        /// </summary>
        [JsonPropertyName("turma")]
        public string Turma { get; set; }

        /// <summary>
        /// Obtém ou define o professor.
        /// </summary>
        [JsonPropertyName("professor")]
        public string Professor { get; set; }

        /// <summary>
        /// Obtém ou define a disciplina.
        /// </summary>
        [JsonPropertyName("disciplina")]
        public string Disciplina { get; set; }

        /// <summary>
        /// Obtém ou define a lista de boletins dos alunos da turma.
        /// </summary>
        [JsonPropertyName("alunos_boletim")]
        public ICollection<AlunoBoletimResponse> AlunosBoletim { get; set; }
    }
}
