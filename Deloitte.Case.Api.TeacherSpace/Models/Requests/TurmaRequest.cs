using Deloitte.Case.Api.TeacherSpace.Models.Bases;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Deloitte.Case.Api.TeacherSpace.Models.Requests
{
    /// <summary>
    /// Define a classe <see cref="TurmaRequest"/>.
    /// </summary>
    public class TurmaRequest : BaseRequest
    {
        /// <summary>
        /// Obtém ou define o nome da turma.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        /// <summary>
        /// Obtém ou define o identificador do Professor.
        /// </summary>
        [Required]
        [JsonPropertyName("professor_id")]
        public Guid ProfessorId { get; set; }

        /// <summary>
        /// Obtém ou define o identificador da Disciplina.
        /// </summary>
        [Required]
        [JsonPropertyName("disciplina_id")]
        public Guid DisciplinaId { get; set; }
    }
}
