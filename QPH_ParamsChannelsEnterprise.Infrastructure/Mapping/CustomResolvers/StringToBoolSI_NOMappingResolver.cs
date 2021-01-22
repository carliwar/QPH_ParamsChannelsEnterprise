using AutoMapper;

namespace QPH_ParamsChannelsEnterprise.Infrastructure.Mapping.CustomResolvers
{
    public class StringToBoolSI_NOMappingResolver : IValueConverter<string, bool>
    {
        public bool Convert(string source, ResolutionContext context)
        {
            if (source.ToUpper() == "SI")
                return true;

            return false;
        }
    }
}
