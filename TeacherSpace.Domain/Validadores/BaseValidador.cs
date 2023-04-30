using Deloitte.Case.TeacherSpace.Domain.Entidades.Base;
using FluentValidation;

namespace Deloitte.Case.TeacherSpace.Domain.Validadores
{
    /// <summary>
    /// Define a classe <see cref="BaseValidador"/>.
    /// </summary>
    public abstract class BaseValidador<TEntidade> : AbstractValidator<TEntidade>
        where TEntidade : EntidadeBase
    {
        public BaseValidador()
        {
            RuleFor(entidade => entidade)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia.")

                .NotNull()
                .WithMessage("A entidade não pode ser nula");
        }
    }
}
