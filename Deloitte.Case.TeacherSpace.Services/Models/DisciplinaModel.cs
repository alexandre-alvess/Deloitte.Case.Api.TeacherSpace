namespace Deloitte.Case.TeacherSpace.Services.Model
{
    /// <summary>
    /// Define a classe <see cref="DisciplinaModel"/>.
    /// </summary>
    public class DisciplinaModel : BaseModel
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
        public ICollection<TurmaModel> Turmas { get; set; }
    }
}
