namespace Deloitte.Case.TeacherSpace.Domain.Entidades.Base
{
    /// <summary>
    /// Define a classe <see cref="EntidadeBase"/>.
    /// </summary>
    public abstract class EntidadeBase
    {
        /// <summary>
        /// Inicializa uma nova instância de <see cref="EntidadeBase"/>.
        /// </summary>
        protected EntidadeBase()
        {
            Ativo = true;
        }

        /// <summary>
        /// Obtém ou define o identificador da entidade.
        /// </summary>
        public virtual Guid Id { get; set; }

        /// <summary>
        /// Obtém ou define se a entidade está ativa.
        /// </summary>
        public bool Ativo { get; set; }
    }
}
