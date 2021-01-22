using FluentValidation;
using QPH_ParamsChannelsEnterprise.Core.DTOs;
using QPH_ParamsChannelsEnterprise.Core.Enumerators;

namespace QPH_ParamsChannelsEnterprise.Core.Validations
{
    public class NonBillableProductsValidations : AbstractValidator<NonBillableProductsDTO>
    {
        public NonBillableProductsValidations()
        {
            RuleFor(t => t.Code)
                .MaximumLength(50).WithMessage("El código no puede tener más de 50 caracteres.")
                .NotNull().WithMessage("El código es requerido.");

            RuleFor(t => t.Name)
                .MaximumLength(200).WithMessage("El nombre no puede tener más de 20 caracteres.")
                .NotNull().WithMessage("El nombre es requerido.");

            RuleFor(t => t.Description)
                .MaximumLength(200).WithMessage("La descripción no puede tener más de 500 caracteres.")
                .NotNull().WithMessage("La descripción es requerida.");

            RuleFor(t => t.Status)
                .NotNull().WithMessage("El estado es requerido.")
                .MaximumLength(20)
                .WithMessage("El estado tiene formato incorrecto.")
                .IsEnumName(typeof(StatusACTIVO_INACTIVOEnum), caseSensitive: false)
                .WithMessage("El estado tiene formato incorrecto.");
        }
    }
}

