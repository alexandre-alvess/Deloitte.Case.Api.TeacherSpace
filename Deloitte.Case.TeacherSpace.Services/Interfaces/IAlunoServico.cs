using Deloitte.Case.TeacherSpace.Services.Models;

namespace Deloitte.Case.TeacherSpace.Services.Interfaces
{
    /// <summary>
    /// Define a interface <see cref="IAlunoServico"/>.
    /// </summary>
    public interface IAlunoServico : IBaseServico<AlunoModel>
    {
        /// <summary>
        /// Consulta os alunos por turma.
        /// </summary>
        /// <param name="turmaId">O identificador da turma <see cref="Guid"/>.</param>
        /// <returns>Os alunos da turma consultada.</returns>
        Task<IEnumerable<AlunoTurmaModel>> ConsultarPorTurmaSearch(Guid turmaId);
    }
}
