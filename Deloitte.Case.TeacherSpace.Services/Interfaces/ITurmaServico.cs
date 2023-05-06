using Deloitte.Case.TeacherSpace.Domain.Utilitarios;
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

        /// <summary>
        /// Consulta as turmas vinculadas ao professor.
        /// </summary>
        /// <param name="id">O identificador do professor <see cref="Guid"/>.</param>
        /// <param name="pagina">A pagina a ser consultada <see cref="int"/>.</param>
        /// <param name="quantide_pagina">A quantidade de elementos para ser consultada por página <see cref="int"/>.</param>
        /// <returns>As turmas vinculadas ao professor informado <see cref="TModel"/>.</returns>
        Task<PagedResult<TurmaModel>> ConsultarPorProfessor(Guid professorId, int pagina, int quantide_pagina);

        /// <summary>
        /// Consulta as turmas vinculadas ao professor.
        /// </summary>
        /// <param name="professorId">O identificador do professor <see cref="Guid"/>.</param>
        /// <returns>As turmas vinculadas ao professor informado <see cref="IEnumerable{TurmaModel}"/>.</returns>
        Task<IEnumerable<TurmaModel>> ConsultarPorProfessorSearch(Guid professorId);
    }
}
