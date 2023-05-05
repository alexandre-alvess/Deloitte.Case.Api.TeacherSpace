using Deloitte.Case.TeacherSpace.Domain.Entidades.Base;
using Deloitte.Case.TeacherSpace.Domain.Utilitarios;
using Deloitte.Case.TeacherSpace.Infraestrutura.Context;
using System.Linq.Expressions;

namespace Deloitte.Case.TeacherSpace.Infraestrutura.Interfaces
{
    /// <summary>
    /// Define a inteface <see cref="IBaseRepositorio"/>.
    /// </summary>
    public interface IBaseRepositorio<TEntidade>
        where TEntidade : EntidadeBase
    {
        /// <summary>
        /// Define o contexto do banco de dados.
        /// </summary>
        TeacherSpaceContext DbContext { get; protected set; }

        /// <summary>
        /// Adiciona a entidade na base de dados.
        /// </summary>
        /// <param name="obj">A entidade <see cref="TEntidade"/>.</param>
        /// <returns>A entidade adicionada <see cref="TEntidade"/>.</returns>
        Task<DataResult<TEntidade>> Criar(TEntidade obj);

        /// <summary>
        /// Atualiza a entidade na base de dados.
        /// </summary>
        /// <param name="obj">A entidade <see cref="T"/>.</param>
        /// <returns>A entidade atualizada <see cref="T"/>.</returns>
        Task<DataResult<TEntidade>> Atualizar(TEntidade obj);

        /// <summary>
        /// Remove a entidade na base de dados.
        /// </summary>
        /// <param name="obj">A entidade <see cref="TEntidade"/>.</param>
        Task<DataResult<bool>> Remover(TEntidade obj);

        /// <summary>
        /// Consulta a entidade pelo seu identificador.
        /// </summary>
        /// <param name="id">O identificador da entidade <see cref="Guid"/>.</param>
        /// <returns>A entidade consultada <see cref="TEntidade"/>.</returns>
        Task<TEntidade> Consultar(Guid id);

        /// <summary>
        /// Consulta a entidade pelo filtro de busca especificado.
        /// </summary>
        /// <param name="filtroBusca">A expressão do filtro de busca.</param>
        /// <param name="includes">Os includes da consulta.</param>
        /// <returns>A entidade consultada <see cref="TEntidade"/>.</returns>
        Task<TEntidade> Consultar(Expression<Func<TEntidade, bool>> filtroBusca, params Expression<Func<TEntidade, object>>[] includes);
        
        /// <summary>
        /// Consulta paginada de uma lista de entidades.
        /// </summary>
        /// <param name="pagina">A pagina a ser consultada <see cref="int"/>.</param>
        /// <param name="quantide_pagina">A quantidade de elementos para ser consultada por página <see cref="int"/>.</param>
        /// <returns>A lista de entidades consultadas <see cref="List{T}"/>.</returns>
        Task<PagedResult<TEntidade>> ConsultarLista(int pagina, int quantide_pagina);

        /// <summary>
        /// Consulta paginada de uma lista de entidades.
        /// </summary>
        /// <param name="filtroBusca">A expressão do filtro de busca.</param>
        /// <param name="pagina">A pagina a ser consultada <see cref="int"/>.</param>
        /// <param name="quantide_pagina">A quantidade de elementos para ser consultada por página <see cref="int"/>.</param>
        /// <param name="includes">Os includes da consulta.</param>
        /// <returns>A lista de entidades consultadas <see cref="List{T}"/>.</returns>
        Task<PagedResult<TEntidade>> ConsultarLista(Expression<Func<TEntidade, bool>> filtroBusca, int pagina, int quantide_pagina, params Expression<Func<TEntidade, object>>[] includes);
    }
}
