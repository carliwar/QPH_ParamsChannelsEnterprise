using FluentValidation;
using QPH_ParamsChannelsEnterprise.Core.DTOs;
using QPH_ParamsChannelsEnterprise.Core.Enumerators;

namespace QPH_ParamsChannelsEnterprise.Core.Validations
{
    public class CredentialsUserValidations : AbstractValidator<CredentialsUserDTO>
    {
        public CredentialsUserValidations()
        {
            RuleFor(t => t.Username)
                .MaximumLength(200).WithMessage("El usuario no puede tener más de 200 caracteres.")
                .NotNull().WithMessage("El usuario es requerido.");

            RuleFor(t => t.Password)
                .MaximumLength(500).WithMessage("El password no puede tener más de 500 caracteres.")
                .NotNull().WithMessage("La contraseña es requerida.");

            RuleFor(t => t.Status)
                .NotNull().WithMessage("El estado es requerido.")
                .MaximumLength(20)
                .WithMessage("El estado tiene formato incorrecto.")
                .IsEnumName(typeof(StatusACTIVO_INACTIVOEnum), caseSensitive: false)
                .WithMessage("El estado tiene formato incorrecto.");
        }
    }
}
