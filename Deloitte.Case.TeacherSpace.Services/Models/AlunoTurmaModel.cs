using Deloitte.Case.TeacherSpace.Services.Model;

namespace Deloitte.Case.TeacherSpace.Services.Models
{
    /// <summary>
    /// Define a classe <see cref="AlunoTurmaModel"/>.
    /// </summary>
    public class AlunoTurmaModel : BaseModel
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
