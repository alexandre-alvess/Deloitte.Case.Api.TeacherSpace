using Deloitte.Case.TeacherSpace.Domain.Entidades;
using Deloitte.Case.TeacherSpace.Infraestrutura.Context;
using Deloitte.Case.TeacherSpace.Infraestrutura.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Deloitte.Case.TeacherSpace.Infraestrutura.Repositorios
{
    /// <summary>
    /// Define a classe <see cref="BoletimRepositorio"/>.
    /// </summary>
    public class BoletimRepositorio : BaseRepositorio<Boletim>, IBoletimRepositorio
    {
        /// <summary>
        /// Inicializa uma nova instância de <see cref="BoletimRepositorio"/>.
        /// </summary>
        /// <param name="context">O contexto do banco de dados <see cref="TeacherSpaceContext"/>.</param>
        public BoletimRepositorio(TeacherSpaceContext context) : base(context, i => i.Include(i => i.Aluno)
                                                                                     .ThenInclude(i => i.Pessoa)
                                                                                     .Include(i => i.Turma)
                                                                                     .ThenInclude(i => i.Disciplina))
        {
        }
    }
}
