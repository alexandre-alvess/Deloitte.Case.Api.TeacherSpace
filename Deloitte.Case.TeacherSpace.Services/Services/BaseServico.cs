using AutoMapper;
using Deloitte.Case.TeacherSpace.Domain.Entidades.Base;
using Deloitte.Case.TeacherSpace.Domain.Utilitarios;
using Deloitte.Case.TeacherSpace.Infraestrutura.Interfaces;
using Deloitte.Case.TeacherSpace.Services.Interfaces;
using FluentValidation;

namespace Deloitte.Case.TeacherSpace.Services.Services
{
    /// <summary>
    /// Define a classe <see cref="BaseServico"/>.
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <typeparam name="TEntidade"></typeparam>
    /// <typeparam name="TRepositorio"></typeparam>
    /// <typeparam name="TValidador"></typeparam>
    public abstract class BaseServico<TModel, TEntidade, TRepositorio, TValidador> : IBaseServico<TModel>
        where TModel : Models.BaseModel
        where TEntidade : EntidadeBase
        where TRepositorio : IBaseRepositorio<TEntidade>
        where TValidador : AbstractValidator<TEntidade>
    {
        protected readonly TRepositorio _repositorio;
        protected readonly IMapper _mapper;
        protected readonly TValidador _validador;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="BaseServico"/>.
        /// </summary>
        /// <param name="repositorio">O repositorio do modelo de dados <see cref="TRepositorio"/>.</param>
        /// <param name="mapper">O mapeador do modelo de dados <see cref="IMapper"/>.</param>
        protected BaseServico(TRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
            _validador = (TValidador)Activator.CreateInstance(typeof(TValidador));
        }

        /// <summary>
        /// Adiciona o modelo de dados.
        /// </summary>
        /// <param name="model">O modelo de dados <see cref="TModel"/>.</param>
        /// <returns>O modelo de dados adicionado <see cref="TModel"/>.</returns>
        public virtual async Task<DataResult<TModel>> Criar(TModel model)
        {
            var entidade = _mapper.Map<TModel, TEntidade>(model);
            entidade.Ativo = true;

            var antesAdicionar = await AntesDeAdicionar(model, entidade);
            if (!antesAdicionar.StatusOk)
                return DataResult<TModel>.Falha(antesAdicionar.Erros);

            var validacao = ValidarEntidade(entidade);
            if (!validacao.StatusOk)
                return DataResult<TModel>.Falha(validacao.Erros);

            entidade.Id = Guid.NewGuid();

            var resultado = await _repositorio.Criar(entidade);
            if (!resultado.StatusOk)
                return DataResult<TModel>.Falha(resultado.Erros);

            var depoisAdicionar = await DepoisDeAdicionar(model, entidade);
            if (!depoisAdicionar.StatusOk)
                return DataResult<TModel>.Falha(depoisAdicionar.Erros);

            _mapper.Map(entidade, model);

            return DataResult<TModel>.Successo(model);
        }

        /// <summary>
        /// Consulta o modelo de dados pelo identificador.
        /// </summary>
        /// <param name="id">O identificador do modelo de dados <see cref="Guid"/>.</param>
        /// <returns>O modelo de dados consultado <see cref="TModel"/>.</returns>
        public virtual async Task<TModel> Consultar(Guid id)
        {
            var entidade = await _repositorio.Consultar(id);
            return _mapper.Map<TEntidade, TModel>(entidade);
        }

        /// <summary>
        /// Consulta a lista de modelos de dados paginada.
        /// </summary>
        /// <param name="filtroBusca">A expressão do filtro de busca.</param>
        /// <param name="pagina">A pagina a ser consultada <see cref="int"/>.</param>
        /// <param name="quantide_pagina">A quantidade de elementos para ser consultada por página <see cref="int"/>.</param>
        /// <returns>O modelo de dados consultado <see cref="TModel"/>.</returns>
        public virtual async Task<PagedResult<TModel>> ConsultarLista(int pagina, int quantide_pagina)
        {
            var resultado = await _repositorio.ConsultarLista(pagina, quantide_pagina);

            return new PagedResult<TModel>
            {
                Dados = _mapper.Map<IEnumerable<TEntidade>, IEnumerable<TModel>>(resultado.Dados),
                TotalRegistros = resultado.TotalRegistros,
                TotalRegistrosFiltro = resultado.TotalRegistrosFiltro
            };
        }

        /// <summary>
        /// Atualiza o modelo de dados.
        /// </summary>
        /// <param name="model">O modelo de dados <see cref="TModel"/>.</param>
        /// <returns>O modelo de dados atualizado <see cref="TModel"/>.</returns>
        public virtual async Task<DataResult<TModel>> Atualizar(TModel model)
        {
            var entidade = await _repositorio.Consultar(model.Id);
            if (entidade == null)
                return DataResult<TModel>.Falha("Registro não encontrado para o id informado.");

            _mapper.Map(model, entidade);
            
            var antesAtualizar = await AntesDeAtualizar(model, entidade);
            if (!antesAtualizar.StatusOk)
                return DataResult<TModel>.Falha(antesAtualizar.Erros);

            var validacao = ValidarEntidade(entidade);
            if (!validacao.StatusOk)
                return DataResult<TModel>.Falha(validacao.Erros);

            var resultado = await _repositorio.Atualizar(entidade);
            if (!resultado.StatusOk)
                return DataResult<TModel>.Falha(resultado.Erros);

            var depoisAtualizar = await DepoisDeAtualizar(model, entidade);
            if (!depoisAtualizar.StatusOk)
                return DataResult<TModel>.Falha(depoisAtualizar.Erros);

            _mapper.Map(entidade, model);

            return DataResult<TModel>.Successo(model);
        }

        /// <summary>
        /// Inativa o modelo de dados.
        /// </summary>
        /// <param name="id">O identificador do modelo de dados <see cref="Guid"/>.</param>
        /// <returns>O modelo de dados inativado <see cref="TModel"/>.</returns>
        public virtual async Task<DataResult<TModel>> Inativar(Guid id)
        {
            var entidade = await _repositorio.Consultar(id);
            if (entidade == null)
                return DataResult<TModel>.Falha("Registro não encontrado para o id informado.");

            entidade.Ativo = false;
            
            var resultado = await _repositorio.Atualizar(entidade);

            return resultado.StatusOk
                ? DataResult<TModel>.Successo(_mapper.Map<TEntidade, TModel>(resultado.Dado))
                : DataResult<TModel>.Falha(resultado.Erros);
        }

        protected virtual Task<DataResult<TModel>> AntesDeAdicionar(TModel model, TEntidade entidade)
        {
            return Task.FromResult(DataResult<TModel>.Successo(model));
        }

        protected virtual Task<DataResult<TModel>> AntesDeAtualizar(TModel model, TEntidade entidade)
        {
            return Task.FromResult(DataResult<TModel>.Successo(model));
        }

        protected virtual Task<DataResult<TModel>> DepoisDeAdicionar(TModel model, TEntidade entidade)
        {
            return Task.FromResult(DataResult<TModel>.Successo(model));
        }

        protected virtual Task<DataResult<TModel>> DepoisDeAtualizar(TModel model, TEntidade entidade)
        {
            return Task.FromResult(DataResult<TModel>.Successo(model));
        }

        protected virtual DataResult<TEntidade> ValidarEntidade(TEntidade entidade)
        {
            var validacao = _validador.Validate(entidade);
            return validacao.IsValid
                ? DataResult<TEntidade>.Successo(entidade)
                : DataResult<TEntidade>.Falha(string.Join(", ", validacao.Errors.Select(x => x.ErrorMessage)));
        }
    }
}
