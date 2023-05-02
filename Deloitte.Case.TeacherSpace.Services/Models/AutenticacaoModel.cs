namespace Deloitte.Case.TeacherSpace.Services.Models
{
    /// <summary>
    /// Define a classe <see cref="AutenticacaoModel"/>.
    /// </summary>
    public class AutenticacaoModel
    {
        /// <summary>
        /// Obtém ou define o login do usuário.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Obtém ou define a senha do usuário.
        /// </summary>
        public string Senha { get; set; }
    }
}
