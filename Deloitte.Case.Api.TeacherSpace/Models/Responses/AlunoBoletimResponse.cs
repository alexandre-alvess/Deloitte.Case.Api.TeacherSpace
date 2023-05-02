using System.Text.Json.Serialization;

namespace Deloitte.Case.Api.TeacherSpace.Models.Responses
{
    /// <summary>
    /// Define a classe <see cref="AlunoBoletimResponse"/>.
    /// </summary>
    public class AlunoBoletimResponse
    {
        /// <summary>
        /// Obtém ou define o identificador do aluno.
        /// </summary>
        [JsonPropertyName("aluno_id")]
        public Guid AlunoId { get; set; }

        /// <summary>
        /// Obtém ou define o nome do aluno.
        /// </summary>
        [JsonPropertyName("aluno")]
        public string Aluno { get; set; }

        /// <summary>
        /// Obtém ou define a lista de boletins do aluno.
        /// </summary>
        [JsonPropertyName("notas_boletim")]
        public ICollection<BoletimResponse> NotasBoletim { get; set; }
    }
}
