using AutoMapper;

namespace QPH_ParamsChannelsEnterprise.Infrastructure.Mapping.CustomResolvers
{
    public class BoolToStringSI_NOMappingConverter : IValueConverter<bool, string>
    {
        public string Convert(bool source, ResolutionContext context)
        {
            if (source)
                return "SI";

            return "NO";
        }
    }
}
