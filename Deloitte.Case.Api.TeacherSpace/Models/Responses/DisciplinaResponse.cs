using Deloitte.Case.Api.TeacherSpace.Models.Bases;
using System.Text.Json.Serialization;

namespace Deloitte.Case.Api.TeacherSpace.Models.Responses
{
    /// <summary>
    /// Define a classe <see cref="DisciplinaResponse"/>.
    /// </summary>
    public class DisciplinaResponse : BaseResponse
    {
        /// <summary>
        /// Obtém ou define o nome da disciplina.
        /// </summary>
        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        /// <summary>
        /// Obtém ou define a carga horária da disciplina.
        /// </summary>
        [JsonPropertyName("carga_horaria")]
        public int CargaHoraria { get; set; }
    }
}
