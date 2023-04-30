using Deloitte.Case.TeacherSpace.Domain.Entidades;
using Deloitte.Case.TeacherSpace.Infraestrutura.Context;
using Deloitte.Case.TeacherSpace.Infraestrutura.Interfaces;

namespace Deloitte.Case.TeacherSpace.Infraestrutura.Repositorios
{
    /// <summary>
    /// Define a classe <see cref="AlunoRepositorio"/>.
    /// </summary>
    public class AlunoRepositorio : BaseRepositorio<Aluno>, IAlunoRepositorio
    {
        /// <summary>
        /// Inicializa uma nova instância de <see cref="AlunoRepositorio"/>.
        /// </summary>
        /// <param name="context">O contexto do banco de dados <see cref="TeacherSpaceContext"/>.</param>
        public AlunoRepositorio(TeacherSpaceContext context) : base(context)
        {
        }
    }
}
