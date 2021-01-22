using AutoMapper;
using QPH_ParamsChannelsEnterprise.Core.DTOs;
using QPH_ParamsChannelsEnterprise.Core.Entities.AdministrationSwitch;
using QPH_ParamsChannelsEnterprise.Core.Entities.SwitchAtiscode;
using QPH_ParamsChannelsEnterprise.Infrastructure.Mapping.CustomResolvers;

namespace QPH_ParamsChannelsEnterprise.Infrastructure.Mapping
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<AtisLogTran, AtisLogTranDTO>()
                .ForMember(t => t.Id, u => u.MapFrom(t => t.IdLogTran))
                .ReverseMap();

            CreateMap<BusinessLine, BusinessLineDTO>()
                .ForMember(t => t.Id, u => u.MapFrom(t => t.IDBusinessLine))
                .ForMember(d => d.Status, opt => opt.ConvertUsing<BoolToStringACTIVO_INACTIVOMappginResolver, bool>())
                .ReverseMap()
                .ForMember(d => d.Status, opt => opt.ConvertUsing<StringToBoolACTIVO_INACTIVOMappingConverter, string>());

            CreateMap<Channel, ChannelDTO>()
                .ForMember(t => t.Id, u => u.MapFrom(t => t.IDChannel))
                .ForMember(d => d.Status, opt => opt.ConvertUsing<BoolToStringSI_NOMappingConverter, bool>())
                .ForMember(d => d.PaymentReceivedRequired, opt => opt.ConvertUsing<BoolToStringSI_NOMappingConverter, bool>())
                .ForMember(d => d.Declarable, opt => opt.ConvertUsing<CharToStringSI_NOMappingResolver, string>())
                .ReverseMap()
                .ForMember(d => d.Status, opt => opt.ConvertUsing<StringToBoolSI_NOMappingResolver, string>())
                .ForMember(d => d.PaymentReceivedRequired, opt => opt.ConvertUsing<StringToBoolSI_NOMappingResolver, string>())
                .ForMember(d => d.Declarable, opt => opt.ConvertUsing<StringToCharSI_NOMappingResolver, string>());

            CreateMap<ChannelEnterprise, ChannelEnterpriseDTO>()
               .ForMember(t => t.Id, u => u.MapFrom(t => t.IDChannelEnterprise))
               .ReverseMap();

            CreateMap<ChannelEnterpriseInfo, ChannelEnterpriseInfoDTO>()
               .ForMember(t => t.Id, u => u.MapFrom(t => t.IDChannelEnterprise))
               .ForMember(d => d.TributaImpuesto, opt => opt.ConvertUsing<BoolToStringSI_NOMappingConverter, bool>())
               .ForMember(d => d.Status, opt => opt.ConvertUsing<BoolToStringSI_NOMappingConverter, bool>())
               .ForMember(d => d.PaymentReceivedRequired, opt => opt.ConvertUsing<BoolToStringSI_NOMappingConverter, bool>())
               .ReverseMap()
               .ForMember(d => d.TributaImpuesto, opt => opt.ConvertUsing<StringToNullBoolSI_NOMappingResolver, string>())
               .ForMember(d => d.Status, opt => opt.ConvertUsing<StringToBoolSI_NOMappingResolver, string>())
               .ForMember(d => d.PaymentReceivedRequired, opt => opt.ConvertUsing<StringToNullBoolSI_NOMappingResolver, string>());

            CreateMap<ChannelNonBillableProducts, ChannelNonBillableProductsDTO>()
               .ForMember(t => t.Id, u => u.MapFrom(t => t.IDChannelNonBillableProducts))
               .ReverseMap();

            CreateMap<CredentialsServer, CredentialsServerDTO>()
               .ForMember(t => t.Id, u => u.MapFrom(t => t.IDCredentialsServer))
               .ForMember(d => d.Status, opt => opt.ConvertUsing<BoolToStringACTIVO_INACTIVOMappginResolver, bool>())
               .ReverseMap()
               .ForMember(d => d.Status, opt => opt.ConvertUsing<StringToBoolACTIVO_INACTIVOMappingConverter, string>());

            CreateMap<CredentialsUser, CredentialsUserDTO>()
               .ForMember(t => t.Id, u => u.MapFrom(t => t.IDCredentialsUser))
               .ForMember(d => d.Status, opt => opt.ConvertUsing<BoolToStringACTIVO_INACTIVOMappginResolver, bool>())
               .ReverseMap()
               .ForMember(d => d.Status, opt => opt.ConvertUsing<StringToBoolACTIVO_INACTIVOMappingConverter, string>());

            CreateMap<EnterpriseCredentials, EnterpriseCredentialsDTO>()
               .ForMember(t => t.Id, u => u.MapFrom(t => t.IDEnterpriseCredentials))
               .ForMember(d => d.Status, opt => opt.ConvertUsing<BoolToStringACTIVO_INACTIVOMappginResolver, bool>())
               .ReverseMap()
               .ForMember(d => d.Status, opt => opt.ConvertUsing<StringToBoolACTIVO_INACTIVOMappingConverter, string>());

            CreateMap<Enterprise, EnterpriseDTO>()
               .ForMember(t => t.Id, u => u.MapFrom(t => t.IDEnterprise))
               .ForMember(d => d.Status, opt => opt.ConvertUsing<BoolToStringSI_NOMappingConverter, bool>())
               .ForMember(d => d.TributaImpuesto, opt => opt.ConvertUsing<BoolToStringSI_NOMappingConverter, bool>())
               .ReverseMap()
               .ForMember(d => d.Status, opt => opt.ConvertUsing<StringToBoolSI_NOMappingResolver, string>())
               .ForMember(d => d.TributaImpuesto, opt => opt.ConvertUsing<StringToBoolSI_NOMappingResolver, string>());

            CreateMap<FinancialDimension, FinancialDimensionDTO>()
               .ForMember(t => t.Id, u => u.MapFrom(t => t.IDFinancialDimension))
               .ForMember(d => d.Status, opt => opt.ConvertUsing<BoolToStringACTIVO_INACTIVOMappginResolver, bool>())
               .ReverseMap()
               .ForMember(d => d.Status, opt => opt.ConvertUsing<StringToBoolACTIVO_INACTIVOMappingConverter, string>());

            CreateMap<FinancialSizing, FinancialSizingDTO>()
               .ForMember(t => t.Id, u => u.MapFrom(t => t.IDFinancialSizing))
               .ForMember(d => d.Status, opt => opt.ConvertUsing<BoolToStringACTIVO_INACTIVOMappginResolver, bool>())
               .ReverseMap()
               .ForMember(d => d.Status, opt => opt.ConvertUsing<StringToBoolACTIVO_INACTIVOMappingConverter, string>());

            CreateMap<FinancialSizingViewResults, FinancialSizingViewResultDTO>()
               .ForMember(t => t.Id, u => u.MapFrom(t => t.IDFinancialSizing))
               .ForMember(d => d.Status, opt => opt.ConvertUsing<BoolToStringACTIVO_INACTIVOMappginResolver, bool>())
               .ReverseMap()
               .ForMember(d => d.Status, opt => opt.ConvertUsing<StringToBoolACTIVO_INACTIVOMappingConverter, string>());

            CreateMap<NonBillableProducts, NonBillableProductsDTO>()
               .ForMember(t => t.Id, u => u.MapFrom(t => t.IDNonBillableProducts))
               .ForMember(d => d.Status, opt => opt.ConvertUsing<BoolToStringACTIVO_INACTIVOMappginResolver, bool>())
               .ReverseMap()
               .ForMember(d => d.Status, opt => opt.ConvertUsing<StringToBoolACTIVO_INACTIVOMappingConverter, string>());

            CreateMap<Parameters, ParametersDTO>()
               .ForMember(t => t.Id, u => u.MapFrom(t => t.IDParameters))
               .ReverseMap();

            CreateMap<QueryManager, QueryManagerDTO>()
               .ForMember(t => t.Id, u => u.MapFrom(t => t.IDQueryManager))
               .ForMember(d => d.Status, opt => opt.ConvertUsing<BoolToStringSI_NOMappingConverter, bool>())
               .ReverseMap()
               .ForMember(d => d.Status, opt => opt.ConvertUsing<StringToBoolSI_NOMappingResolver, string>());

            CreateMap<SubBusinessLine, SubBusinessLineDTO>()
                .ForMember(t => t.Id, u => u.MapFrom(t => t.IDSubBusinessLine))
                .ForMember(d => d.Status, opt => opt.ConvertUsing<BoolToStringACTIVO_INACTIVOMappginResolver, bool>())
                .ReverseMap()
                .ForMember(d => d.Status, opt => opt.ConvertUsing<StringToBoolACTIVO_INACTIVOMappingConverter, string>());


            CreateMap<GetNonBilllableProductsResult, NonBillableProductsInfoDTO> ()
               .ForMember(t => t.Id, u => u.MapFrom(t => t.NonBillableProductID))
               .ReverseMap();
        }
    }
}
