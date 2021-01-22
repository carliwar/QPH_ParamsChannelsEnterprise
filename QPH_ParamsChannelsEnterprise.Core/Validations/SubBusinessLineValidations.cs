using FluentValidation;
using QPH_ParamsChannelsEnterprise.Core.DTOs;
using QPH_ParamsChannelsEnterprise.Core.Enumerators;

namespace QPH_ParamsChannelsEnterprise.Core.Validations
{
    public class SubBusinessLineValidations : AbstractValidator<BusinessLineDTO>
    {
        public SubBusinessLineValidations()
        {
            RuleFor(t => t.Name)
                .MaximumLength(300).WithMessage("El nombre no puede tener más de 300 caracteres.")
                .NotNull().WithMessage("El nombre es requerido.");

            RuleFor(t => t.Description)
                .MaximumLength(500).WithMessage("La descripción no puede tener más de 500 caracteres.")
                .NotNull().WithMessage("La descripción es requerida.");

            RuleFor(t => t.CodeCostCenter)
                .MaximumLength(50).WithMessage("El CodeCostCenter no puede tener más de 500 caracteres.")
                .NotNull().WithMessage("El CodeCostCenter es requerido.");

            RuleFor(t => t.Status)
                .NotNull().WithMessage("El estado es requerido.")
                .MaximumLength(20)
                .WithMessage("El estado tiene formato incorrecto.")
                .IsEnumName(typeof(StatusACTIVO_INACTIVOEnum), caseSensitive: false)
                .WithMessage("El estado tiene formato incorrecto.");
        }
    }
}
