using Deloitte.Case.Api.TeacherSpace.Models.Bases;

namespace Deloitte.Case.Api.TeacherSpace.Models.Responses
{
    /// <summary>
    /// Define a classe <see cref="UsuarioResponse"/>.
    /// </summary>
    public class UsuarioResponse : BaseRequest
    {
        /// <summary>
        /// Obtém ou define o nome do usuário.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Obtém ou define o login do usuário.
        /// </summary>
        public string Login { get; set; }
    }
}
