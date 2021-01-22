using AutoMapper;

namespace QPH_ParamsChannelsEnterprise.Infrastructure.Mapping.CustomResolvers
{
    public class StringToCharSI_NOMappingResolver : IValueConverter<string, string>
    {
        public string Convert(string source, ResolutionContext context)
        {
            if (source.ToUpper() == "SI")
                return "S";

            return "N";
        }
    }
}
