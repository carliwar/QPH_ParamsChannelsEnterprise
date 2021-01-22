namespace QPH_ParamsChannelsEnterprise.Core.DTOs
{
    public class NonBillableProductsInfoDTO : BaseDTO
    {
        public int ChannelID { get; set; }
        public string Segmento { get; set; }
        public int NonBillableProductID { get; set; }
        public string Code { get; set; }
    }
}
