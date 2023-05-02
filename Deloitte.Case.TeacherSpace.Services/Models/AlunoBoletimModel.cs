namespace Deloitte.Case.TeacherSpace.Services.Models
{
    /// <summary>
    /// Define a classe <see cref="AlunoBoletimModel"/>.
    /// </summary>
    public class AlunoBoletimModel
    {
        /// <summary>
        /// Obtém ou define o identificador do aluno.
        /// </summary>
        public Guid AlunoId { get; set; }

        /// <summary>
        /// Obtém ou define o nome do aluno.
        /// </summary>
        public string Aluno { get; set; }

        /// <summary>
        /// Obtém ou define a lista de boletins do aluno.
        /// </summary>
        public ICollection<BoletimModel> NotasBoletim { get; set; }
    }
}
