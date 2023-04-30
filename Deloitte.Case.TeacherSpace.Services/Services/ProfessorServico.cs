using AutoMapper;
using Deloitte.Case.TeacherSpace.Domain.Entidades;
using Deloitte.Case.TeacherSpace.Domain.Entities;
using Deloitte.Case.TeacherSpace.Domain.Validadores;
using Deloitte.Case.TeacherSpace.Infraestrutura.Interfaces;
using Deloitte.Case.TeacherSpace.Services.Interfaces;
using Deloitte.Case.TeacherSpace.Services.Model;

namespace Deloitte.Case.TeacherSpace.Services.Services
{
    /// <summary>
    /// Define a classe <see cref="ProfessorServico"/>.
    /// </summary>
    public class ProfessorServico : BaseServico<ProfessorModel, Professor, IProfessorRepositorio, ProfessorValidador>, IProfessorServico
    {
        /// <summary>
        /// Inicializa uma nova instância de <see cref="ProfessorServico"/>.
        /// </summary>
        /// <param name="professorRepositorio">O repositorio de professor <see cref="IProfessorRepositorio"/>.</param>
        /// <param name="mapper">O mapeador do modelo de dados <see cref="IMapper"/>.</param>
        public ProfessorServico(IProfessorRepositorio professorRepositorio, IMapper mapper) : base(professorRepositorio, mapper)
        {
        }

        protected override void AntesDeAdicionar(ProfessorModel model, Professor entidade)
        {
            entidade.Pessoa = _mapper.Map<Professor, Pessoa>(entidade);
            entidade.Pessoa.Id = Guid.NewGuid();
        }

        protected override void AntesDeAtualizar(ProfessorModel model, Professor entidade)
        {
            var pessoaId = entidade.Pessoa.Id;

            entidade.Pessoa = _mapper.Map<Professor, Pessoa>(entidade);
            entidade.Pessoa.Id = pessoaId;
        }
    }
}
