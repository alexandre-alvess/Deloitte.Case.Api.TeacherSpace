namespace Deloitte.Case.TeacherSpace.Domain.Entidades.Base
{
    /// <summary>
    /// Define a classe  <see cref="PessoaBase"/>.
    /// </summary>
    public abstract class PessoaBase : EntidadeBase
    {
        /// <summary>
        /// Obtém ou define o nome.
        /// </summary>
        public virtual string Nome { get; set; }

        /// <summary>
        /// Obtém ou define o email.
        /// </summary>
        public virtual string Email { get; set; }

        /// <summary>
        /// Obtém ou define a data de nascimento.
        /// </summary>
        public virtual DateTime DataNascimento { get; set; }
    }
}
