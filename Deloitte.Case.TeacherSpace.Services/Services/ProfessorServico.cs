using AutoMapper;
using Deloitte.Case.TeacherSpace.Domain.Entities;
using Deloitte.Case.TeacherSpace.Domain.Validadores;
using Deloitte.Case.TeacherSpace.Infraestrutura.Interfaces;
using Deloitte.Case.TeacherSpace.Services.Model;

namespace Deloitte.Case.TeacherSpace.Services.Services
{
    /// <summary>
    /// Define a classe <see cref="ProfessorServico"/>.
    /// </summary>
    public class ProfessorServico : BaseServico<ProfessorModel, Professor, IProfessorRepositorio, ProfessorValidador>
    {
        /// <summary>
        /// Inicializa uma nova instância de <see cref="ProfessorServico"/>.
        /// </summary>
        /// <param name="professorRepositorio">O repositorio de professor <see cref="IProfessorRepositorio"/>.</param>
        /// <param name="mapper">O mapeador do modelo de dados <see cref="IMapper"/>.</param>
        public ProfessorServico(IProfessorRepositorio professorRepositorio, IMapper mapper) : base(professorRepositorio, mapper)
        {

        }
    }
}
