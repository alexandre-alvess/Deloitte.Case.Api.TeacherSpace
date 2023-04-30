using Deloitte.Case.TeacherSpace.Domain.Entidades;
using Deloitte.Case.TeacherSpace.Domain.Utilitarios;
using Deloitte.Case.TeacherSpace.Infraestrutura.Context;
using Deloitte.Case.TeacherSpace.Infraestrutura.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Deloitte.Case.TeacherSpace.Infraestrutura.Repositorios
{
    /// <summary>
    /// Define a classe <see cref="BaseRepositorio"/>.
    /// </summary>
    public abstract class BaseRepositorio<TEntidade> : IBaseRepositorio<TEntidade>
        where TEntidade : EntidadeBase
    {
        /// <summary>
        /// Define o contexto da base de dados.
        /// </summary>
        private readonly TeacherSpaceContext _context;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="BaseRepositorio"/>.
        /// </summary>
        /// <param name="context">O contexto do banco de dados <see cref="TeacherSpaceContext"/>.</param>
        protected BaseRepositorio(TeacherSpaceContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adiciona a entidae na base de dados.
        /// </summary>
        /// <param name="obj">A entidade <see cref="TEntidade"/>.</param>
        /// <returns>A entidade adicionada <see cref="TEntidade"/>.</returns>
        public virtual async Task<DataResult<TEntidade>> Criar(TEntidade obj)
        {
            _context.Add(obj);
            var resultado = await _context.SaveChangesAsync();

            return resultado > 0 ? DataResult<TEntidade>.Successo(obj) : DataResult<TEntidade>.Falha("Falha ao tentar adicionar entidade.");
        }

        /// <summary>
        /// Atualiza a entidade na base de dados.
        /// </summary>
        /// <param name="obj">A entidade <see cref="T"/>.</param>
        /// <returns>A entidade atualizada <see cref="T"/>.</returns>
        public virtual async Task<DataResult<TEntidade>> Atualizar(TEntidade obj)
        {
            _context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var resultado = await _context.SaveChangesAsync();

            return resultado > 0 ? DataResult<TEntidade>.Successo(obj) : DataResult<TEntidade>.Falha("Falha ao tentar atualizar entidade.");
        }

        /// <summary>
        /// Remove a entidade na base de dados.
        /// </summary>
        /// <param name="obj">A entidade <see cref="TEntidade"/>.</param>
        public virtual async Task<DataResult<bool>> Remover(TEntidade obj)
        {
            var entidade = await Consultar(obj.Id);
            if (entidade != null)
            {
                _context.Remove(entidade);
                var resultado = await _context.SaveChangesAsync();

                return resultado > 0 ? DataResult<bool>.Successo(true) : DataResult<bool>.Falha("Falha ao tentar remover entidade.");
            }

            return DataResult<bool>.Successo(true);
        }

        /// <summary>
        /// Consulta uma entidade pelo seu identificador.
        /// </summary>
        /// <param name="id">O identificador da entidade <see cref="Guid"/>.</param>
        /// <returns>A entidade consultada <see cref="TEntidade"/>.</returns>
        public virtual async Task<TEntidade> Consultar(Guid id)
        {
            return await _context.Set<TEntidade>()
                .AsNoTracking()
                .Where(entidade => entidade.Id == id)
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Consulta a entidade pelo filtro de busca especificado.
        /// </summary>
        /// <param name="filtroBusca">A expressão do filtro de busca.</param>
        /// <param name="includes">Os includes da consulta.</param>
        /// <returns>A entidade consultada <see cref="TEntidade"/>.</returns>
        public virtual async Task<TEntidade> Consultar(Expression<Func<TEntidade, bool>> filtroBusca, params Expression<Func<TEntidade, object>>[] includes)
        {
            return await Include(includes).Where(filtroBusca).AsNoTracking().FirstOrDefaultAsync();
        }

        /// <summary>
        /// Consulta paginada de uma lista de entidades.
        /// </summary>
        /// <param name="pagina">A pagina a ser consultada <see cref="int"/>.</param>
        /// <param name="quantide_pagina">A quantidade de elementos para ser consultada por página <see cref="int"/>.</param>
        /// <returns>A lista de entidades consultadas <see cref="List{T}"/>.</returns>
        public virtual async Task<IEnumerable<TEntidade>> ConsultarLista(int pagina, int quantide_pagina)
        {
            return await _context.Set<TEntidade>().AsNoTracking().Skip(quantide_pagina * (pagina - 1)).Take(quantide_pagina).ToListAsync();
        }

        /// <summary>
        /// Consulta paginada de uma lista de entidades.
        /// </summary>
        /// <param name="filtroBusca">A expressão do filtro de busca.</param>
        /// <param name="pagina">A pagina a ser consultada <see cref="int"/>.</param>
        /// <param name="quantide_pagina">A quantidade de elementos para ser consultada por página <see cref="int"/>.</param>
        /// <param name="includes">Os includes da consulta.</param>
        /// <returns>A lista de entidades consultadas <see cref="List{T}"/>.</returns>
        public virtual async Task<IEnumerable<TEntidade>> ConsultarLista(Expression<Func<TEntidade, bool>> filtroBusca, int pagina, int quantide_pagina, params Expression<Func<TEntidade, object>>[] includes)
        {
            return await Include(includes).Where(filtroBusca).AsNoTracking().Skip(quantide_pagina * (pagina - 1)).Take(quantide_pagina).ToListAsync();
        }

        protected IQueryable<T> Include<T>(params Expression<Func<T, object>>[] paths)
            where T : class
        {
            IQueryable<T> query = _context.Set<T>();
            return query.Any() ? paths.Aggregate(query, (current, path) => current.Include(path)) : query;
        }
    }
}
