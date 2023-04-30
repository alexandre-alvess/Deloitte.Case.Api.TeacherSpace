﻿using AutoMapper;
using Deloitte.Case.TeacherSpace.Domain.Validadores;
using Deloitte.Case.TeacherSpace.Infraestrutura.Interfaces;
using Deloitte.Case.TeacherSpace.Services.Interfaces;
using Deloitte.Case.TeacherSpace.Services.Model;

namespace Deloitte.Case.TeacherSpace.Services.Services
{
    /// <summary>
    /// Define a classe <see cref="AlunoServico"/>.
    /// </summary>
    public class AlunoServico : BaseServico<AlunoModel, Domain.Entidades.Aluno, IAlunoRepositorio, AlunoValidador>, IAlunoServico
    {
        /// <summary>
        /// Inicializa uma nova instância de <see cref="AlunoServico"/>.
        /// </summary>
        /// <param name="repositorio">O repositorio de aluno <see cref="IAlunoRepositorio"/>.</param>
        /// <param name="mapper">O mapeador do modelo de dados <see cref="IMapper"/>.</param>
        public AlunoServico(IAlunoRepositorio repositorio, IMapper mapper) : base(repositorio, mapper)
        {
        }
    }
}