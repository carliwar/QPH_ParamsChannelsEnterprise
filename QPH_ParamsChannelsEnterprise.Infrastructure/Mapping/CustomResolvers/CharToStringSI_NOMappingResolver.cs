using AutoMapper;

namespace QPH_ParamsChannelsEnterprise.Infrastructure.Mapping.CustomResolvers
{
    public class CharToStringSI_NOMappingResolver : IValueConverter<string, string>
    {
        public string Convert(string source, ResolutionContext context)
        {
            if (source.ToUpper() == "S")
                return "SI";

            return "NO";
        }
    }
}
