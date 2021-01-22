using AutoMapper;

namespace QPH_ParamsChannelsEnterprise.Infrastructure.Mapping.CustomResolvers
{

    public class StringToBoolACTIVO_INACTIVOMappingConverter : IValueConverter<string, bool>
    {
        public bool Convert(string source, ResolutionContext context)
        {
            if (source.ToUpper() == "ACTIVO")
                return true;

            return false;
        }
    }
}
