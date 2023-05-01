using Deloitte.Case.TeacherSpace.Domain.Entidades;
using Deloitte.Case.TeacherSpace.Infraestrutura.Context;
using Deloitte.Case.TeacherSpace.Infraestrutura.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Deloitte.Case.TeacherSpace.Infraestrutura.Repositorios
{
    /// <summary>
    /// Define a classe <see cref="TurmaRepositorio"/>.
    /// </summary>
    public class TurmaRepositorio : BaseRepositorio<Turma>, ITurmaRepositorio
    {
        /// <summary>
        /// Inicializa uma nova instância de <see cref="TurmaRepositorio"/>.
        /// </summary>
        /// <param name="context">O contexto do banco de dados <see cref="TeacherSpaceContext"/>.</param>
        public TurmaRepositorio(TeacherSpaceContext context) : base(context, i => i.Include(t => t.Professor)
                                                                                   .ThenInclude(p => p.Pessoa)
                                                                                   .Include(t => t.Disciplina))
        {
        }
    }
}
