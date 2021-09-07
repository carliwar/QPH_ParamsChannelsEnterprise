namespace QPH_ParamsChannelsEnterprise.Core.DTOs
{
    public class ChannelEnterpriseDTO : BaseDTO
    {
        public int IDEnterprise { get; set; }
        public long IDChannel { get; set; }
        public bool Status { get; set; }
        public bool StatusInvoice { get; set; }
        public bool StatusCreditNote { get; set; }
        public bool StatusCotization { get; set; }
    }
}
