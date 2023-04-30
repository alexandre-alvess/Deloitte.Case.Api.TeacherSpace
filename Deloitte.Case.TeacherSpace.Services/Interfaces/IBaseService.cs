using Deloitte.Case.TeacherSpace.Domain.Utilitarios;
using Deloitte.Case.TeacherSpace.Services.Model;

namespace Deloitte.Case.TeacherSpace.Services.Interfaces
{
    /// <summary>
    /// Define a interface  <see cref="IBaseService"/>.
    /// </summary>
    public interface IBaseService<TModel>
        where TModel : BaseModel
    {
        /// <summary>
        /// Adiciona o modelo de dados.
        /// </summary>
        /// <param name="model">O modelo de dados <see cref="TModel"/>.</param>
        /// <returns>O modelo de dados adicionado <see cref="TModel"/>.</returns>
        Task<DataResult<TModel>> Criar(TModel model);

        /// <summary>
        /// Consulta o modelo de dados pelo identificador.
        /// </summary>
        /// <param name="id">O identificador do modelo de dados <see cref="Guid"/>.</param>
        /// <returns>O modelo de dados consultado <see cref="TModel"/>.</returns>
        Task<TModel> Consultar(Guid id);

        /// <summary>
        /// Consulta a lista de modelos de dados paginada.
        /// </summary>
        /// <param name="pagina">A pagina a ser consultada <see cref="int"/>.</param>
        /// <param name="quantide_pagina">A quantidade de elementos para ser consultada por página <see cref="int"/>.</param>
        /// <returns>O modelo de dados consultado <see cref="TModel"/>.</returns>
        Task<IEnumerable<TModel>> ConsultarLista(int pagina, int quantide_pagina);

        /// <summary>
        /// Atualiza o modelo de dados.
        /// </summary>
        /// <param name="model">O modelo de dados <see cref="TModel"/>.</param>
        /// <returns>O modelo de dados atualizado <see cref="TModel"/>.</returns>
        Task<DataResult<TModel>> Atualizar(TModel model);

        /// <summary>
        /// Inativa o modelo de dados.
        /// </summary>
        /// <param name="id">O identificador do modelo de dados <see cref="Guid"/>.</param>
        /// <returns>O modelo de dados inativado <see cref="TModel"/>.</returns>
        Task<DataResult<TModel>> Inativar(Guid id);
    }
}
