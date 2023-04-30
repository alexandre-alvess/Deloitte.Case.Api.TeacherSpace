using Deloitte.Case.TeacherSpace.Domain.Entidades;
using FluentValidation;

namespace Deloitte.Case.TeacherSpace.Domain.Validadores
{
    /// <summary>
    /// Define a classe <see cref="BoletimValidador"/>.
    /// </summary>
    public class BoletimValidador : BaseValidador<Boletim>
    {
        public BoletimValidador()
        {
            RuleFor(boletim => boletim.Nota)
                .NotNull()
                .NotEmpty()
                .WithMessage("A nota é obrigatória.")

                .GreaterThanOrEqualTo(0)
                .WithMessage("A nota deve ser maior ou igual a 0.");

            RuleFor(boletim => boletim.DataEntrega)
                .NotNull()
                .NotEmpty()
                .WithMessage("A data de entrega é obrigatória.")

                .GreaterThanOrEqualTo(DateTime.Now.AddMonths(-1))
                .WithMessage("Não é permitido registrar o boletim com a data de entrega anterior a 1 mês.");

            RuleFor(boletim => boletim.AlunoId)
                .NotNull()
                .NotEmpty()
                .WithMessage("O aluno é obrigatório.");

            RuleFor(boletim => boletim.TurmaId)
                .NotNull()
                .NotEmpty()
                .WithMessage("A turma é obrigatória.");
        }
    }
}
