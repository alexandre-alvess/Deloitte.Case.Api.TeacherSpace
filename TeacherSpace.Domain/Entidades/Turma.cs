using Deloitte.Case.TeacherSpace.Domain.Entidades.Base;
using Deloitte.Case.TeacherSpace.Domain.Entities;

namespace Deloitte.Case.TeacherSpace.Domain.Entidades
{
    /// <summary>
    /// Define a classe <see cref="Turma"/>.
    /// </summary>
    public class Turma : EntidadeBase
    {
        /// <summary>
        /// Obtém ou define o nome da turma.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Obtém ou define o identificador do Professor.
        /// </summary>
        public Guid ProfessorId { get; set; }

        /// <summary>
        /// Obtém ou define o professor da turma.
        /// </summary>
        public virtual Professor Professor { get; set; }

        /// <summary>
        /// Obtém ou define o identificador da Disciplina.
        /// </summary>
        public Guid DisciplinaId { get; set; }

        /// <summary>
        /// Obtém ou define o aluno da turma.
        /// </summary>
        public virtual Disciplina Disciplina { get; set; }

        /// <summary>
        /// Obtém ou define a lista de alunos da turma.
        /// </summary>
        public virtual ICollection<Aluno> Alunos { get; set; }

        /// <summary>
        /// Obtém ou define a lista de alunos da turma.
        /// </summary>
        public virtual ICollection<AlunoTurma> AlunoTurmas { get; set; }
    }
}
