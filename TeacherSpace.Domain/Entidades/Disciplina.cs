using Deloitte.Case.TeacherSpace.Domain.Entities;

namespace Deloitte.Case.TeacherSpace.Domain.Entidades
{
    /// <summary>
    /// Define a classe <see cref="Disciplina"/>.
    /// </summary>
    public class Disciplina : EntidadeBase
    {
        /// <summary>
        /// Obtém ou define o nome da disciplina.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Obtém ou define a carga horária da disciplina.
        /// </summary>
        public int CargaHoraria { get; set; }

        /// <summary>
        /// Obtém ou define as turmas do professor.
        /// </summary>
        public ICollection<Turma> Turmas { get; set; }
    }
}
