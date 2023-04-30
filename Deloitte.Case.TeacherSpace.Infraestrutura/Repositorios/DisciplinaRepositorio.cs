using Deloitte.Case.TeacherSpace.Domain.Entidades;
using Deloitte.Case.TeacherSpace.Infraestrutura.Context;
using Deloitte.Case.TeacherSpace.Infraestrutura.Interfaces;

namespace Deloitte.Case.TeacherSpace.Infraestrutura.Repositorios
{
    /// <summary>
    /// Define a classe <see cref="DisciplinaRepositorio"/>.
    /// </summary>
    public class DisciplinaRepositorio : BaseRepositorio<Disciplina>, IDisciplinaRepositorio
    {
        /// <summary>
        /// Inicializa uma nova instância de <see cref="DisciplinaRepositorio"/>.
        /// </summary>
        /// <param name="context">O contexto do banco de dados <see cref="TeacherSpaceContext"/>.</param>
        public DisciplinaRepositorio(TeacherSpaceContext context) : base(context)
        {

        }
    }
}
