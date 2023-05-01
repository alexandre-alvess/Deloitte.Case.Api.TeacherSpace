using Deloitte.Case.TeacherSpace.Domain.Utilitarios;
using Deloitte.Case.TeacherSpace.Services.Model;
using Deloitte.Case.TeacherSpace.Services.Models;

namespace Deloitte.Case.TeacherSpace.Services.Interfaces
{
    /// <summary>
    /// Define a interface <see cref="ITurmaServico"/>.
    /// </summary>
    public interface ITurmaServico : IBaseServico<TurmaModel>
    {
        /// <summary>
        /// Adiciona o aluno na turma.
        /// </summary>
        /// <param name="model">O model de aluno para adicionar na turma.</param>
        /// <returns>O aluno adicionado na turma.</returns>
        Task<DataResult<AlunoTurmaModel>> AdicionarAluno(AlunoTurmaModel model);

        /// <summary>
        /// Inativa o aluno na turma.
        /// </summary>
        /// <param name="model">O model de aluno para inativar na turma.</param>
        /// <returns>O aluno inativado na turma.</returns>
        Task<DataResult<AlunoTurmaModel>> InativarAluno(AlunoTurmaModel model);
    }
}
