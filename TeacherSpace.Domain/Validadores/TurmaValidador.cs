using Deloitte.Case.TeacherSpace.Domain.Entidades;
using FluentValidation;

namespace Deloitte.Case.TeacherSpace.Domain.Validadores
{
    /// <summary>
    /// Define a classe <see cref="TurmaValidador"/>.
    /// </summary>
    public class TurmaValidador : BaseValidador<Turma>
    {
        public TurmaValidador()
        {
            RuleFor(turma => turma.Nome)
                .NotNull()
                .NotEmpty()
                .WithMessage("O nome da turma é obrigatório.")
                
                .MaximumLength(80)
                .WithMessage("O nome da turma deve ter no máximo 80 caracteres.");

            RuleFor(turma => turma.ProfessorId)
                .NotNull()
                .NotEmpty()
                .WithMessage("O professor é obrigatório.");

            RuleFor(turma => turma.DisciplinaId)
                .NotNull()
                .NotEmpty()
                .WithMessage("A disciplina é obrigatória.");
        }
    }
}
