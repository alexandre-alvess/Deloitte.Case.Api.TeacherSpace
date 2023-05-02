namespace Deloitte.Case.TeacherSpace.Services.Models
{
    /// <summary>
    /// Define a classe <see cref="TurmaModel"/>.
    /// </summary>
    public class TurmaModel : BaseModel
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
        public virtual ProfessorModel Professor { get; set; }

        /// <summary>
        /// Obtém ou define o identificador da Disciplina.
        /// </summary>
        public Guid DisciplinaId { get; set; }

        /// <summary>
        /// Obtém ou define o aluno da turma.
        /// </summary>
        public virtual DisciplinaModel Disciplina { get; set; }

        /// <summary>
        /// Obtém ou define a lista de alunos da turma.
        /// </summary>
        public virtual ICollection<AlunoModel> Alunos { get; set; }
    }
}
