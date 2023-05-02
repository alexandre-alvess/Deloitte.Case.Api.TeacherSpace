namespace Deloitte.Case.TeacherSpace.Services.Models
{
    /// <summary>
    /// Define a classe <see cref="BaseModel"/>.
    /// </summary>
    public class BaseModel
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
