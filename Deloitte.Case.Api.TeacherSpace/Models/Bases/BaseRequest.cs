namespace Deloitte.Case.Api.TeacherSpace.Models.Bases
{
    /// <summary>
    /// Define a classe <see cref="BaseRequest"/>.
    /// </summary>
    public class BaseRequest
    {
        /// <summary>
        /// Obtém ou define o identificador da entidade.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Obtém ou define se a entidade está ativa.
        /// </summary>
        public bool Ativo { get; set; }
    }
}
