using Deloitte.Case.TeacherSpace.Domain.Entidades;
using FluentValidation;

namespace Deloitte.Case.TeacherSpace.Domain.Validadores
{
    /// <summary>
    /// Define a classe <see cref="UsuarioValidador"/>.
    /// </summary>
    public class UsuarioValidador : BaseValidador<Usuario>
    {
        public UsuarioValidador()
        {
            RuleFor(usuario => usuario.Login)
                .NotNull()
                .NotEmpty()
                .WithMessage("O login é obrigatório.")

                .MaximumLength(100)
                .WithMessage("O login deve ter no máximo 100 caracteres.");

            RuleFor(usuario => usuario.Senha)
                .NotNull()
                .NotEmpty()
                .WithMessage("A senha é obrigatória.")

                .MinimumLength(6)
                .WithMessage("A senha deve ter no mínimo 6 caracteres.")

                .MaximumLength(50)
                .WithMessage("A senha deve ter no máximo 50 caracteres");
        }
    }
}
