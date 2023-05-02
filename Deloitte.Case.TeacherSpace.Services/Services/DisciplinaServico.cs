using AutoMapper;
using Deloitte.Case.TeacherSpace.Domain.Entidades;
using Deloitte.Case.TeacherSpace.Domain.Validadores;
using Deloitte.Case.TeacherSpace.Infraestrutura.Interfaces;
using Deloitte.Case.TeacherSpace.Services.Interfaces;
using Deloitte.Case.TeacherSpace.Services.Models;

namespace Deloitte.Case.TeacherSpace.Services.Services
{
    /// <summary>
    /// Define a classe <see cref="DisciplinaServico"/>.
    /// </summary>
    public class DisciplinaServico : BaseServico<DisciplinaModel, Disciplina, IDisciplinaRepositorio, DisciplinaValidador>, IDisciplinaServico
    {
        /// <summary>
        /// Inicializa uma nova instância de <see cref="DisciplinaServico"/>.
        /// </summary>
        /// <param name="repositorio">O repositorio de disciplina <see cref="IDisciplinaRepositorio"/>.</param>
        /// <param name="mapper">O mapeador do modelo de dados <see cref="IMapper"/>.</param>
        public DisciplinaServico(IDisciplinaRepositorio repositorio, IMapper mapper) : base(repositorio, mapper)
        {
        }
    }
}
