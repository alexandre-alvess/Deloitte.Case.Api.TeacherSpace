using Deloitte.Case.TeacherSpace.Core.Enumeradores;

namespace Deloitte.Case.TeacherSpace.Core.Models
{
    /// <summary>
    /// Define a classe <see cref="ApiErroMessageItem"/>.
    /// </summary>
    public class ApiErroMessageItem
    {
        /// <summary>
        /// Obtém ou define o código do erro.
        /// </summary>
        public string Codigo { get; set; }

        /// <summary>
        /// Obtém ou define a mensagem de erro.
        /// </summary>
        public string Erro { get; set; }

        /// <summary>
        /// Obtém ou define a stack trace.
        /// </summary>
        public string StackTrace { get; set; }

        /// <summary>
        /// Obtém ou define o tipo do erro.
        /// </summary>
        public EnumApiErroTipo Tipo { get; set; }

        /// <summary>
        /// Inicializa a instância da classe <see cref="ApiErroMessageItem"/>.
        /// </summary>
        /// <param name="codigo">O código do erro <see cref="string"/>.</param>
        /// <param name="erro">A mensagem de erro <see cref="string"/>.</param>
        /// <param name="tipo">O tipo do erro <see cref="EnumApiErroTipo"/>.</param>
        /// <param name="stackTrace">A strack trace do erro <see cref="string"/>.</param>
        public ApiErroMessageItem(string codigo, string erro, EnumApiErroTipo tipo, string stackTrace = null)
        {
            Codigo = codigo;
            Erro = erro;
            StackTrace = stackTrace;
            Tipo = tipo;
        }
    }
}
