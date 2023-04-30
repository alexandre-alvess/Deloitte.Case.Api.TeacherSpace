namespace Deloitte.Case.TeacherSpace.Services.Model
{
    /// <summary>
    /// Define a classe <see cref="BoletimModel"/>.
    /// </summary>
    public class BoletimModel : BaseModel
    {
        /// <summary>
        /// Obtém ou define a data de entrega do boletim.
        /// </summary>
        public DateTime DataEntrega { get; set; }

        /// <summary>
        /// Obtém ou define a nota do boletim.
        /// </summary>
        public decimal Nota { get; set; }

        /// <summary>
        /// Obtém ou define o identificador do aluno.
        /// </summary>
        public Guid AlunoId { get; set; }

        /// <summary>
        /// Obtém ou define o aluno.
        /// </summary>
        public virtual AlunoModel Aluno { get; set; }

        /// <summary>
        /// Obtém ou define o identificador da Turma.
        /// </summary>
        public Guid TurmaId { get; set; }

        /// <summary>
        /// Obtém ou define a turma.
        /// </summary>
        public virtual TurmaModel Turma { get; set; }
    }
}
