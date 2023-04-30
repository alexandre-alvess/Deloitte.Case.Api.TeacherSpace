namespace Deloitte.Case.TeacherSpace.Core.Models
{
    /// <summary>
    /// Define a classe <see cref="ApiErrorMessage"/>.
    /// </summary>
    public class ApiErrorMessage
    {
        /// <summary>
        /// Obtém ou define a lista de erros.
        /// </summary>
        public IEnumerable<ApiErroMessageItem> Erros { get; set; }

        /// <summary>
        /// Inicializa a instância da classe <see cref="ApiErrorMessage"/>.
        /// </summary>
        /// <param name="erros">A lista de erros <see cref="IEnumerable{ApiErroMessageItem}"/>.</param>
        public ApiErrorMessage(IEnumerable<ApiErroMessageItem> erros)
        {
            Erros = erros;
        }

        /// <summary>
        /// Inicializa a instância da classe <see cref="ApiErrorMessage"/> definindo o erro causado.
        /// </summary>
        /// <param name="erroItem">O item de erro <see cref="ApiErroMessageItem"/>.</param>
        /// <returns>O <see cref="ApiErrorMessage"/>.</returns>
        public static ApiErrorMessage Erro(ApiErroMessageItem erroItem) => new ApiErrorMessage(new ApiErroMessageItem[1] { erroItem });
    }
}
