using Deloitte.Case.TeacherSpace.Domain.Entities;
using Deloitte.Case.TeacherSpace.Infraestrutura.Context;
using Deloitte.Case.TeacherSpace.Infraestrutura.Interfaces;

namespace Deloitte.Case.TeacherSpace.Infraestrutura.Repositorios
{
    /// <summary>
    /// Define a classe <see cref="ProfessorRepositorio"/>.
    /// </summary>
    public class ProfessorRepositorio : BaseRepositorio<Professor>, IProfessorRepositorio
    {
        /// <summary>
        /// Inicializa uma nova instância de <see cref="ProfessorRepositorio"/>.
        /// </summary>
        /// <param name="context">O contexto do banco de dados <see cref="TeacherSpaceContext"/>.</param>
        public ProfessorRepositorio(TeacherSpaceContext context) : base(context)
        {
        }
    }
}
