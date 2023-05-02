using System.Text.Json.Serialization;

namespace Deloitte.Case.TeacherSpace.Services.Models
{
    /// <summary>
    /// Define a classe <see cref="TurmaBoletimModel"/>.
    /// </summary>
    public class TurmaBoletimModel
    {
        /// <summary>
        /// Obtém ou define a turma.
        /// </summary>
        public string Turma { get; set; }

        /// <summary>
        /// Obtém ou define o professor.
        /// </summary>
        public string Professor { get; set; }

        /// <summary>
        /// Obtém ou define a disciplina.
        /// </summary>
        public string Disciplina { get; set; }

        /// <summary>
        /// Obtém ou define a lista de boletins dos alunos da turma.
        /// </summary>
        public ICollection<AlunoBoletimModel> AlunosBoletim { get; set; }
    }
}
