using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Deloitte.Case.TeacherSpace.Services.Model
{
    /// <summary>
    /// Define a classe <see cref="PessoaModel"/>.
    /// </summary>
    public class PessoaModel : BaseModel
    {
        /// <summary>
        /// Obtém ou define o nome.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Obtém ou define o email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Obtém ou define a data de nascimento.
        /// </summary>
        public DateTime DataNascimento { get; set; }
    }
}
