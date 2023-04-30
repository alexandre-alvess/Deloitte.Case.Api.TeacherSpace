namespace Deloitte.Case.TeacherSpace.Domain.Entidades
{
    /// <summary>
    /// Define a classe <see cref="Usuario"/>.
    /// </summary>
    public class Aluno : Pessoa
    {
        /// <summary>
        /// Obtém ou define o identificador da pessoa.
        /// </summary>
        public Guid PessoaId { get; set; }

        /// <summary>
        /// Obtém ou define a pessoa.
        /// </summary>
        public virtual Pessoa Pessoa { get; set; }

        /// <summary>
        /// Obtém ou define a lista de boletins do aluno.
        /// </summary>
        public virtual ICollection<Boletim> Boletins { get; set; }

        /// <summary>
        /// Obtém ou define a lista de turmas do aluno.
        /// </summary>
        public virtual ICollection<Turma> Turmas { get; set; }
    }
}
