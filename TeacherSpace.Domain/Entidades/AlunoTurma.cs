using Deloitte.Case.TeacherSpace.Domain.Entidades.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Deloitte.Case.TeacherSpace.Domain.Entidades
{
    /// <summary>
    /// Define a classe <see cref="AlunoTurma"/>.
    /// </summary>
    public class AlunoTurma : EntidadeBase
    {
        /// <summary>
        /// Obtém ou define o identificador da entidade.
        /// </summary>
        [NotMapped]
        public override Guid Id { get; set; }

        /// <summary>
        /// Obtém ou define o identificador do aluno.
        /// </summary>
        public Guid AlunoId { get; set; }

        /// <summary>
        /// Obtém ou define o aluno.
        /// </summary>
        public virtual Aluno Aluno { get; set; }

        /// <summary>
        /// Obtém ou define o identificador da turma.
        /// </summary>
        public Guid TurmaId { get; set; }

        /// <summary>
        /// Obtém ou define a turma.
        /// </summary>
        public virtual Turma Turma { get; set; }
    }
}
