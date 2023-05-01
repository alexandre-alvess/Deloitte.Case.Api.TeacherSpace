using Deloitte.Case.Api.TeacherSpace.Models.Bases;

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
        public Guid AlunoId { get; set; }

        /// <summary>
        /// Obtém ou define o identificador da turma.
        /// </summary>
        public Guid TurmaId { get; set; }
    }
}
