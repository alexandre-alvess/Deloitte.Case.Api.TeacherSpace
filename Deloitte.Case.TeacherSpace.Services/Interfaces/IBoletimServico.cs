using Deloitte.Case.TeacherSpace.Services.Models;

namespace Deloitte.Case.TeacherSpace.Services.Interfaces
{
    /// <summary>
    /// Define a interface <see cref="IBoletimServico"/>.
    /// </summary>
    public interface IBoletimServico : IBaseServico<BoletimModel>
    {
        /// <summary>
        /// Consulta a lista paginada de boletins por turma.
        /// </summary>
        /// <param name="turmaId">O identificador da turma <see cref="Guid"/>.</param>
        /// <returns>Os boletins da turma consultada <see cref="TModel"/>.</returns>
        Task<TurmaBoletimModel> ConsultarListaPorTurma(Guid turmaId);
    }
}
