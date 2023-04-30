using Deloitte.Case.TeacherSpace.Domain.Entidades.Base;
using Deloitte.Case.TeacherSpace.Domain.Entities;

namespace Deloitte.Case.TeacherSpace.Domain.Entidades
{
    /// <summary>
    /// Define a classe <see cref="Boletim"/>.
    /// </summary>
    public class Boletim : EntidadeBase
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
        public virtual Aluno Aluno { get; set; }

        /// <summary>
        /// Obtém ou define o identificador da Turma.
        /// </summary>
        public Guid TurmaId { get; set; }

        /// <summary>
        /// Obtém ou define a turma.
        /// </summary>
        public virtual Turma Turma { get; set; }
    }
}
