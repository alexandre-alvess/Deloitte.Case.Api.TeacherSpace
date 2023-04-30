using Deloitte.Case.TeacherSpace.Domain.Entidades.Base;
using FluentValidation;

namespace Deloitte.Case.TeacherSpace.Domain.Validadores
{
    /// <summary>
    /// Define a classe <see cref="PessoaValidador"/>.
    /// </summary>
    /// <typeparam name="TEntidade"></typeparam>
    public class PessoaValidador<TEntidade> : BaseValidador<TEntidade>
        where TEntidade : PessoaBase
    {
        public PessoaValidador()
        {
            RuleFor(pessoa => pessoa.Nome)
                .NotNull()
                .NotEmpty()
                .WithMessage("O nome é obrigatório.")

                .MinimumLength(3)
                .WithMessage("O nome deve ter no minimo 3 caracteres.")

                .MaximumLength(80)
                .WithMessage("O nome deve ter no máximo 80 caracteres.");

            RuleFor(pessoa => pessoa.Email)
                .NotNull()
                .NotEmpty()
                .WithMessage("O email é obrigatório.")

                .MaximumLength(180)
                .WithMessage("O email deve ter no máximo 180 caracteres.")

                .EmailAddress()
                .WithMessage("O email informado não é válido");

            RuleFor(pessoa => pessoa.DataNascimento)
                .NotNull()
                .NotEmpty()
                .WithMessage("A data de nascimento é obrigatória.")

                .GreaterThan(date => new DateTime(1900, 01, 01))
                .WithMessage("A data de nascimento não é válida.");
        }
    }
}
