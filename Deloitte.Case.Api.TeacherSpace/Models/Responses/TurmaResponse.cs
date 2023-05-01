using Deloitte.Case.Api.TeacherSpace.Models.Bases;
using System.Text.Json.Serialization;

namespace Deloitte.Case.Api.TeacherSpace.Models.Responses
{
    /// <summary>
    /// Define a classe <see cref="TurmaResponse"/>.
    /// </summary>
    public class TurmaResponse : BaseResponse
    {
        /// <summary>
        /// Obtém ou define o nome da turma.
        /// </summary>
        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        /// <summary>
        /// Obtém ou define do professor da turma.
        /// </summary>
        [JsonPropertyName("professor")]
        public ProfessorResponse Professor { get; set; }

        /// <summary>
        /// Obtém ou define a disciplina da turma.
        /// </summary>
        [JsonPropertyName("disciplina")]
        public DisciplinaResponse Disciplina { get; set; }

        /// <summary>
        /// Obtém ou define a lista de alunos da turma.
        /// </summary>
        [JsonPropertyName("alunos")]
        public ICollection<AlunoResponse> Alunos { get; set; }
    }
}
