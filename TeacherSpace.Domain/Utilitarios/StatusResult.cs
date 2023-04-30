using System.Net;

namespace Deloitte.Case.TeacherSpace.Domain.Utilitarios
{
    /// <summary>
    /// Define a classe <see cref="StatusResult"/>.
    /// </summary>
    public class StatusResult
    {
        /// <summary>
        /// Inicializa uma nova instância de <see cref="StatusResult"/>.
        /// </summary>
        public StatusResult()
        {
        }

        /// <summary>
        /// Inicializa uma nova instância de <see cref="StatusResult"/>.
        /// </summary>
        /// <param name="statusOk">O status do resultado da operação realizada <see cref="bool"/>.</param>
        /// <param name="erros">A lista de erros <see cref="List{string}"/>.</param>
        public StatusResult(bool statusOk, List<string> erros)
        {
            StatusOk = statusOk;
            Erros = erros;
        }

        /// <summary>
        /// Obtém ou define um valor que indica se StatusOk
        /// </summary>
        public bool StatusOk { get; set; }

        /// <summary>
        /// Obtém ou define o código do erro.
        /// </summary>
        public string CodigoErro { get; set; }

        /// <summary>
        /// Obtém ou define a lista de erros.
        /// </summary>
        public List<string> Erros { get; set; }

        /// <summary>
        /// Obtém ou define o código de status da operação http.
        /// </summary>
        public HttpStatusCode CodigoStatusHttp { get; set; }
    }
}
