namespace Deloitte.Case.TeacherSpace.Domain.Utilitarios
{
    /// <summary>
    /// Define a classe <see cref="DataResult"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DataResult<T> : StatusResult
    {
        /// <summary>
        /// Inicializa uma nova instância de <see cref="DataResult"/>.
        /// </summary>
        public DataResult()
        {
        }

        /// <summary>
        /// Inicializa uma nova instância de <see cref="DataResult"/>.
        /// </summary>
        /// <param name="statusOk">O status do resultado da operação realizada <see cref="bool"/>.</param>
        /// <param name="erros">A lista de erros <see cref="List{string}"/>.</param>
        public DataResult(bool statusOk, List<string> erros)
            : base(statusOk, erros)
        {
        }

        /// <summary>
        /// Inicializa uma nova instância de <see cref="DataResult{T}"/> para definir o sucesso da operação.
        /// </summary>
        /// <param name="dado">O dado resultante da operação <see cref="T"/>.</param>
        /// <returns>O <see cref="DataResult{T}"/>.</returns>
        public static DataResult<T> Successo(T dado)
        {
            return new DataResult<T>
            {
                StatusOk = true,
                Dado = dado
            };
        }

        /// <summary>
        /// Inicializa uma nova instância de <see cref="DataResult{T}"/> para definir a falha da operação.
        /// </summary>
        /// <param name="erro">A mensagem de erro <see cref="string"/>.</param>
        /// <returns>O <see cref="DataResult{T}"/>.</returns>
        public static DataResult<T> Falha(string erro) => Falha(new List<string> { erro });

        /// <summary>
        /// Inicializa uma nova instância de <see cref="DataResult{T}"/> para definir a falha da operação.
        /// </summary>
        /// <param name="errors">A lista de erros <see cref="string"/>.</param>
        /// <returns>O <see cref="DataResult{T}"/>.</returns>
        public static DataResult<T> Falha(List<string> erros) => new DataResult<T>(statusOk: false, erros: erros);

        /// <summary>
        /// Obtém ou define o dado.
        /// </summary>
        public T Dado { get; set; }
    }
}
