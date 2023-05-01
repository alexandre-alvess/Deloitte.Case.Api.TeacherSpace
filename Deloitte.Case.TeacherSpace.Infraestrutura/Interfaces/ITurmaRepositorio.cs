using Deloitte.Case.TeacherSpace.Domain.Entidades;
using Deloitte.Case.TeacherSpace.Domain.Utilitarios;

namespace Deloitte.Case.TeacherSpace.Infraestrutura.Interfaces
{
    /// <summary>
    /// Define a interface <see cref="ITurmaRepositorio"/>.
    /// </summary>
    public interface ITurmaRepositorio : IBaseRepositorio<Turma>
    {
        /// <summary>
        /// Adicina o aluno na turma.
        /// </summary>
        /// <param name="obj">A entidade aluno turma.</param>
        /// <returns>O aluno adicionado na turma <see cref="AlunoTurma"/>.</returns>
        Task<DataResult<AlunoTurma>> AdicionarAluno(AlunoTurma obj);

        /// <summary>
        /// Verifica se o aluno está registrado na turma.
        /// </summary>
        /// <param name="alunoId">O identificador de aluno <see cref="Guid"/>.</param>
        /// <param name="turmaId">O identificador da turma <see cref="Guid"/>.</param>
        /// <returns>Se o aluno está registrado na turma <see cref="bool"/>.</returns>
        Task<bool> ExisteAluno(Guid alunoId, Guid turmaId);

        /// <summary>
        /// Atualiza o aluno na turma.
        /// </summary>
        /// <param name="obj">A entidade aluno turma.</param>
        /// <returns>O aluno atualizado na turma <see cref="AlunoTurma"/>.</returns>
        Task<DataResult<AlunoTurma>> AtualizarAluno(AlunoTurma obj);
    }
}
