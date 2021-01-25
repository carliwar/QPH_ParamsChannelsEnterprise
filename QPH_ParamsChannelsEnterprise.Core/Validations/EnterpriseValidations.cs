using FluentValidation;
using QPH_ParamsChannelsEnterprise.Core.DTOs;
using QPH_ParamsChannelsEnterprise.Core.Enumerators;
using QPH_ParamsChannelsEnterprise.Core.Validations.Customized;

namespace QPH_ParamsChannelsEnterprise.Core.Validations
{
    public class EnterpriseValidations : AbstractValidator<EnterpriseDTO>
    {
        public EnterpriseValidations()
        {
            RuleFor(t => t.Establecimiento)
                .MaximumLength(10).WithMessage("El establecimiento no puede tener más de 10 caracteres.")
                .NotNull().WithMessage("El establecimiento es requerido.");

            RuleFor(t => t.RazonSocial)
                .MaximumLength(300).WithMessage("La razón social no puede tener más de 300 caracteres.")
                .NotNull().WithMessage("La razón social es requerida.");

            RuleFor(t => t.RUC)
                .MustBeValidRUC()
                .MaximumLength(20).WithMessage("El RUC no puede tener más de 20 caracteres.")                
                .NotNull().WithMessage("El RUC es requerido.");

            RuleFor(t => t.DireccionMatriz)
                .MaximumLength(300).WithMessage("La direcció matriz no puede tener más de 300 caracteres.");

            RuleFor(t => t.TributaImpuesto)
                .NotNull().WithMessage("Tributa Impuesto es requerido.")
                .MaximumLength(20)
                .WithMessage("El campo Tributa Impuesto tiene formato incorrecto.")
                .IsEnumName(typeof(StatusSI_NOEnum), caseSensitive: false)
                .WithMessage("El campo Tributa Impuesto tiene formato incorrecto.");

            RuleFor(t => t.Contribuyente)
                .MaximumLength(100).WithMessage("El contribuyente no puede tener más de 100 caracteres.")
                .NotNull().WithMessage("El contribuyente es requerido.");

            RuleFor(t => t.Ciudad)
                .MaximumLength(20).WithMessage("La ciudad no puede tener más de 20 caracteres.")
                .NotNull().WithMessage("La ciudad es requerida.");

            RuleFor(t => t.Telefono)
                .MaximumLength(10).WithMessage("El teléfono no puede tener más de 10 caracteres.");

            RuleFor(t => t.Status)
                .NotNull().WithMessage("El estado es requerido.")
                .MaximumLength(20)
                .WithMessage("El estado tiene formato incorrecto.")
                .IsEnumName(typeof(StatusSI_NOEnum), caseSensitive: false)
                .WithMessage("El estado tiene formato incorrecto.");
        }
    }
}
