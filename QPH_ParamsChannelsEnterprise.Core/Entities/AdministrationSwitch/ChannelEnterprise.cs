namespace QPH_ParamsChannelsEnterprise.Core.Entities.AdministrationSwitch
{
    public class ChannelEnterprise
    {
        public int IDChannelEnterprise { get; set; }
        public int IDEnterprise { get; set; }
        public long IDChannel { get; set; }
        public bool Status { get; set; }
        public bool StatusInvoice { get; set; }
        public bool StatusCreditNote { get; set; }
        public bool StatusCotization { get; set; }
    }
}
