namespace Deloitte.Case.TeacherSpace.Services.Models
{
    /// <summary>
    /// Define a classe <see cref="AppSettings"/>.
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// Obtém ou define a chave secreta para geração do token de autenticação.
        /// </summary>
        public string ChaveSecreta { set; get; }
    }
}
