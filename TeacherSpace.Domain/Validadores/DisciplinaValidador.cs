using Deloitte.Case.TeacherSpace.Domain.Entidades;
using FluentValidation;

namespace Deloitte.Case.TeacherSpace.Domain.Validadores
{
    /// <summary>
    /// Define a classe <see cref="Disciplina"/>.
    /// </summary>
    public class DisciplinaValidador : BaseValidador<Disciplina>
    {
        public DisciplinaValidador()
        {
            RuleFor(disciplina => disciplina.Nome)
                .NotNull()
                .NotEmpty()
                .WithMessage("O nome da disciplina é obrigatório.")
                
                .MaximumLength(50)
                .WithMessage("O nome da disciplina deve ter no máximo 50 caracteres.");

            RuleFor(disciplina => disciplina.CargaHoraria)
                .NotNull()
                .NotEmpty()
                .WithMessage("A carga horária é obrigatória.")

                .GreaterThan(0)
                .WithMessage("A carga horária informada deve ser maior que 0.");
        }
    }
}
