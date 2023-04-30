using Deloitte.Case.TeacherSpace.Core.Enumeradores;
using Deloitte.Case.TeacherSpace.Core.Excecoes;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Deloitte.Case.TeacherSpace.Core.Configuracoes
{
    /// <summary>
    /// Define a classe <see cref="ErrorHandlingMiddleware"/>.
    /// </summary>
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="ErrorHandlingMiddleware"/>.
        /// </summary>
        /// <param name="next">O delegate da requisição <see cref="RequestDelegate"/>.</param>
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// INVOKE.
        /// </summary>
        /// <param name="contexto">O contexto da requisição HTTP <see cref="HttpContext"/>.</param>
        public async Task Invoke(HttpContext contexto)
        {
            try
            {
                await _next(contexto);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(contexto, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext contexto, Exception ex)
        {
            EnumApiErroTipo tipoErro;

            var tipoExcessao = ex.GetType();

            if (tipoExcessao == typeof(ApiException))
            {
                tipoErro = EnumApiErroTipo.Comunicacao;
            }
            else if (tipoExcessao == typeof(ExternoApiException))
            {
                tipoErro = EnumApiErroTipo.Negocio;
            }
            else
            {
                tipoErro = EnumApiErroTipo.Tecnico;
            }

            contexto.Response.ContentType = "application/json";

            return contexto.Response.WriteAsync(JsonSerializer.Serialize(new
            {
                erro = ex.Message,
                tipoErro,
                stackTrace = ex.StackTrace,
            }));
        }
    }
}
