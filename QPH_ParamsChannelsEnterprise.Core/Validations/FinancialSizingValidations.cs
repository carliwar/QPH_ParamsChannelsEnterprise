using FluentValidation;
using QPH_ParamsChannelsEnterprise.Core.DTOs;
using QPH_ParamsChannelsEnterprise.Core.Enumerators;

namespace QPH_ParamsChannelsEnterprise.Core.Validations
{
    public class FinancialSizingValidations : AbstractValidator<FinancialSizingDTO>
    {
        public FinancialSizingValidations()
        {
            RuleFor(t => t.Dimension1ID)                
                .NotNull().WithMessage("El campo Business Line es requerido.");

            RuleFor(t => t.Dimension2ID)
                .NotNull().WithMessage("El campo SubBusiness Line es requerido.");

            RuleFor(t => t.Dimension3ID)
                .NotNull().WithMessage("El campo Financial Dimension es requerido.");

            RuleFor(t => t.Status)
                .NotNull().WithMessage("El estado es requerido.")
                .MaximumLength(20)
                .WithMessage("El estado tiene formato incorrecto.")
                .IsEnumName(typeof(StatusACTIVO_INACTIVOEnum), caseSensitive: false)
                .WithMessage("El estado tiene formato incorrecto.");
        }
    }
}
