using AutoMapper;

namespace QPH_ParamsChannelsEnterprise.Infrastructure.Mapping.CustomResolvers
{

    public class BoolToStringACTIVO_INACTIVOMappginResolver: IValueConverter<bool, string>
    {
        public string Convert(bool source, ResolutionContext context)
        {
            if (source)
                return "ACTIVO";

            return "INACTIVO";
        }
    }
}
