using Deloitte.Case.TeacherSpace.Domain.Validadores;

namespace Deloitte.Case.TeacherSpace.Domain.Entidades
{
    /// <summary>
    /// Define a classe  <see cref="Pessoa"/>.
    /// </summary>
    public class Pessoa : EntidadeBase
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
