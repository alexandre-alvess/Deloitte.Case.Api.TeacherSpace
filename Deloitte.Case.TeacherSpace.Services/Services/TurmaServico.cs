using AutoMapper;
using Deloitte.Case.TeacherSpace.Domain.Entidades;
using Deloitte.Case.TeacherSpace.Domain.Validadores;
using Deloitte.Case.TeacherSpace.Infraestrutura.Interfaces;
using Deloitte.Case.TeacherSpace.Services.Interfaces;
using Deloitte.Case.TeacherSpace.Services.Model;

namespace Deloitte.Case.TeacherSpace.Services.Services
{
    public class TurmaServico : BaseServico<TurmaModel, Turma, ITurmaRepositorio, TurmaValidador>, ITurmaServico
    {
        /// <summary>
        /// Inicializa uma nova instância de <see cref="TurmaServico"/>.
        /// </summary>
        /// <param name="repositorio">O repositorio de turma <see cref="ITurmaRepositorio"/>.</param>
        /// <param name="mapper">O mapeador do modelo de dados <see cref="IMapper"/>.</param>
        public TurmaServico(ITurmaRepositorio repositorio, IMapper mapper) : base(repositorio, mapper)
        {
        }

        protected override void AntesDeAtualizar(TurmaModel model, Turma entidade)
        {
            entidade.DisciplinaId = entidade.Disciplina.Id;
            entidade.ProfessorId = entidade.Professor.Id;
        }
    }
}
