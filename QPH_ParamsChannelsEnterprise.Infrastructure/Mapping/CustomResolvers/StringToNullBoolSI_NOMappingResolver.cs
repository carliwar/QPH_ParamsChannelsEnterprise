using AutoMapper;

namespace QPH_ParamsChannelsEnterprise.Infrastructure.Mapping.CustomResolvers
{
    public class StringToNullBoolSI_NOMappingResolver : IValueConverter<string, bool?>
    {
        public bool? Convert(string source, ResolutionContext context)
        {
            if (source.ToUpper() == "SI")
                return true;
            if (source.ToUpper() == "NO")
                return false;

            return null;
        }
    }
}
