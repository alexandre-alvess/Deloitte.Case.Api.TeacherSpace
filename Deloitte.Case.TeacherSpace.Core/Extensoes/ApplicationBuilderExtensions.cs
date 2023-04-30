using Deloitte.Case.TeacherSpace.Core.Configuracoes;
using Microsoft.AspNetCore.Builder;

namespace Deloitte.Case.TeacherSpace.Core.Extensoes
{
    /// <summary>
    /// Define a classe <see cref="ApplicationBuilderExtensions"/>.
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Adiciona o middleware de tratamento de exceções por injeção de dependência.
        /// </summary>
        /// <param name="applicationBuilder">O application builder <see cref="IApplicationBuilder"/>.</param>
        public static IApplicationBuilder AddGlobalErrorHandler(this IApplicationBuilder applicationBuilder)
            => applicationBuilder.UseMiddleware<ErrorHandlingMiddleware>();
    }
}
