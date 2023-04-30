using Deloitte.Case.TeacherSpace.Domain.Entidades;
using Deloitte.Case.TeacherSpace.Infraestrutura.Context;
using Deloitte.Case.TeacherSpace.Infraestrutura.Interfaces;

namespace Deloitte.Case.TeacherSpace.Infraestrutura.Repositorios
{
    /// <summary>
    /// Define a classe <see cref="PessoaRepositorio"/>.
    /// </summary>
    public class PessoaRepositorio : BaseRepositorio<Pessoa>, IPessoaRepositorio
    {
        /// <summary>
        /// Inicializa uma nova instância de <see cref="PessoaRepositorio"/>.
        /// </summary>
        /// <param name="context">O contexto do banco de dados <see cref="TeacherSpaceContext"/>.</param>
        public PessoaRepositorio(TeacherSpaceContext context) : base(context)
        {
        }
    }
}
