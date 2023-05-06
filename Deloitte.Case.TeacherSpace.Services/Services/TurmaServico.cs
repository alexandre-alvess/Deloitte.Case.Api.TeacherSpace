using AutoMapper;
using Deloitte.Case.TeacherSpace.Domain.Entidades;
using Deloitte.Case.TeacherSpace.Domain.Utilitarios;
using Deloitte.Case.TeacherSpace.Domain.Validadores;
using Deloitte.Case.TeacherSpace.Infraestrutura.Interfaces;
using Deloitte.Case.TeacherSpace.Services.Interfaces;
using Deloitte.Case.TeacherSpace.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace Deloitte.Case.TeacherSpace.Services.Services
{
    /// <summary>
    /// Define a classe <see cref="TurmaServico"/>.
    /// </summary>
    public class TurmaServico : BaseServico<TurmaModel, Turma, ITurmaRepositorio, TurmaValidador>, ITurmaServico
    {
        private readonly IAlunoRepositorio _alunoRepositorio;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="TurmaServico"/>.
        /// </summary>
        /// <param name="repositorio">O repositorio de turma <see cref="ITurmaRepositorio"/>.</param>
        /// <param name="mapper">O mapeador do modelo de dados <see cref="IMapper"/>.</param>
        /// <param name="alunoRepositorio">O repositório de aluno <see cref="IAlunoRepositorio"/>.</param>
        public TurmaServico(ITurmaRepositorio repositorio, IMapper mapper, IAlunoRepositorio alunoRepositorio) : base(repositorio, mapper)
        {
            _alunoRepositorio = alunoRepositorio;
        }

        /// <summary>
        /// Adiciona o aluno na turma.
        /// </summary>
        /// <param name="model">O model de aluno para adicionar na turma.</param>
        /// <returns>O aluno adicionado na turma.</returns>
        public async Task<DataResult<AlunoTurmaModel>> AdicionarAluno(AlunoTurmaModel model)
        {
            var alunoTurmaValido = await ValideAlunoTurma(model);
            if (!alunoTurmaValido.StatusOk)
                return DataResult<AlunoTurmaModel>.Falha(alunoTurmaValido.Erros);

            var existeAlunoTurma = await _repositorio.ExisteAluno(model.AlunoId, model.TurmaId);
            if (existeAlunoTurma)
                return DataResult<AlunoTurmaModel>.Falha("O aluno já está registrado na turma.");

            var resultado = await _repositorio.AdicionarAluno(_mapper.Map<AlunoTurmaModel, AlunoTurma>(model));

            return resultado.StatusOk
                ? DataResult<AlunoTurmaModel>.Successo(model)
                : DataResult<AlunoTurmaModel>.Falha(resultado.Erros);
        }

        /// <summary>
        /// Inativa o aluno na turma.
        /// </summary>
        /// <param name="model">O model de aluno para inativar na turma.</param>
        /// <returns>O aluno inativado na turma.</returns>
        public async Task<DataResult<AlunoTurmaModel>> InativarAluno(AlunoTurmaModel model)
        {
            var alunoTurmaValido = await ValideAlunoTurma(model);
            if (!alunoTurmaValido.StatusOk)
                return DataResult<AlunoTurmaModel>.Falha(alunoTurmaValido.Erros);

            var entidade = _mapper.Map<AlunoTurmaModel, AlunoTurma>(model);

            entidade.Ativo = false;

            var resultado = await _repositorio.AtualizarAluno(entidade);

            return resultado.StatusOk
                ? DataResult<AlunoTurmaModel>.Successo(_mapper.Map<AlunoTurma, AlunoTurmaModel>(resultado.Dado))
                : DataResult<AlunoTurmaModel>.Falha(resultado.Erros);
        }

        /// <summary>
        /// Consulta as turmas vinculadas ao professor.
        /// </summary>
        /// <param name="professorId">O identificador do professor <see cref="Guid"/>.</param>
        /// <param name="pagina">A pagina a ser consultada <see cref="int"/>.</param>
        /// <param name="quantide_pagina">A quantidade de elementos para ser consultada por página <see cref="int"/>.</param>
        /// <returns>As turmas vinculadas ao professor informado <see cref="PagedResult{TurmaModel}"/>.</returns>
        public async Task<PagedResult<TurmaModel>> ConsultarPorProfessor(Guid professorId, int pagina, int quantide_pagina)
        {
            var paginaEntidades = await _repositorio.ConsultarLista(x => x.ProfessorId == professorId, pagina, quantide_pagina);
            
            return new PagedResult<TurmaModel>
            {
                Dados = _mapper.Map<IEnumerable<Turma>, IEnumerable<TurmaModel>>(paginaEntidades.Dados),
                TotalRegistros = paginaEntidades.TotalRegistros,
                TotalRegistrosFiltro = paginaEntidades.TotalRegistrosFiltro
            };
        }

        /// <summary>
        /// Consulta as turmas vinculadas ao professor.
        /// </summary>
        /// <param name="professorId">O identificador do professor <see cref="Guid"/>.</param>
        /// <returns>As turmas vinculadas ao professor informado <see cref="IEnumerable{TurmaModel}"/>.</returns>
        public async Task<IEnumerable<TurmaModel>> ConsultarPorProfessorSearch(Guid professorId)
        {
            var turmas = await _repositorio.DbContext.Turmas.Where(x => x.ProfessorId == professorId).ToListAsync();
            return _mapper.Map<IEnumerable<Turma>, IEnumerable<TurmaModel>>(turmas);
        }

        protected override Task<DataResult<TurmaModel>> AntesDeAtualizar(TurmaModel model, Turma entidade)
        {
            entidade.DisciplinaId = entidade.Disciplina.Id;
            entidade.ProfessorId = entidade.Professor.Id;

            return Task.FromResult(DataResult<TurmaModel>.Successo(model));
        }

        private async Task<DataResult<bool>> ValideAlunoTurma(AlunoTurmaModel model)
        {
            var turma = await _repositorio.Consultar(model.TurmaId);
            if (turma == null)
                return DataResult<bool>.Falha("Turma informada não existe.");

            var aluno = await _alunoRepositorio.Consultar(model.AlunoId);
            if (aluno == null)
                return DataResult<bool>.Falha("Aluno informado não existe.");

            return DataResult<bool>.Successo(true);
        }
    }
}
