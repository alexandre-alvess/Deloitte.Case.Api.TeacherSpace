using Deloitte.Case.Api.TeacherSpace.Models.Bases;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Deloitte.Case.Api.TeacherSpace.Models.Requests
{
    /// <summary>
    /// Define a classe <see cref="BoletimRequest"/>.
    /// </summary>
    public class BoletimRequest : BaseRequest
    {
        /// <summary>
        /// Obtém ou define a data de entrega do boletim.
        /// </summary>
        [Required]
        [JsonPropertyName("data_entrega")]
        public DateTime DataEntrega { get; set; }

        /// <summary>
        /// Obtém ou define a nota do boletim.
        /// </summary>
        [Required]
        [JsonPropertyName("nota")]
        [Range(0, 10)]
        public decimal Nota { get; set; }

        /// <summary>
        /// Obtém ou define o identificador do aluno.
        /// </summary>
        [Required]
        [JsonPropertyName("aluno_id")]
        public Guid AlunoId { get; set; }

        /// <summary>
        /// Obtém ou define o identificador da Turma.
        /// </summary>
        [Required]
        [JsonPropertyName("turma_id")]
        public Guid TurmaId { get; set; }
    }
}
