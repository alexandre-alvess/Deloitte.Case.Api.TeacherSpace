using Deloitte.Case.Api.TeacherSpace.Models.Bases;
using System.Text.Json.Serialization;

namespace Deloitte.Case.Api.TeacherSpace.Models.Responses
{
    /// <summary>
    /// Define a classe <see cref="BoletimResponse"/>.
    /// </summary>
    public class BoletimResponse : BaseResponse
    {
        /// <summary>
        /// Obtém ou define a data de entrega do boletim.
        /// </summary>
        [JsonPropertyName("data_entrega")]
        public DateTime DataEntrega { get; set; }

        /// <summary>
        /// Obtém ou define a nota do boletim.
        /// </summary>
        [JsonPropertyName("nota")]
        public decimal Nota { get; set; }

        /// <summary>
        /// Obtém ou define o identificador do aluno.
        /// </summary>
        [JsonPropertyName("aluno_id")]
        public Guid AlunoId { get; set; }

        /// <summary>
        /// Obtém ou define o aluno.
        /// </summary>
        [JsonPropertyName("aluno")]
        public AlunoResponse Aluno { get; set; }

        /// <summary>
        /// Obtém ou define o identificador da Turma.
        /// </summary>
        [JsonPropertyName("turma_id")]
        public Guid TurmaId { get; set; }

        /// <summary>
        /// Obtém ou define o nome da turma.
        /// </summary>
        [JsonPropertyName("turma")]
        public TurmaResponse Turma { get; set; }
    }
}
