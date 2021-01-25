using FluentValidation;

namespace QPH_ParamsChannelsEnterprise.Core.Validations.Customized
{
    public static class ValidatorExtensions
    {
        public static IRuleBuilderOptions<T,TElement> MustBeValidRUC<T, TElement>(this IRuleBuilder<T, TElement> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new RUCValidator<TElement>());
        }
    }
}
