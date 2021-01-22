using System.ComponentModel.DataAnnotations.Schema;

namespace QPH_ParamsChannelsEnterprise.Core.Entities.AdministrationSwitch
{
    public partial class ChannelNonBillableProducts
    {
        public int IDChannelNonBillableProducts { get; set; }
        public long ChannelID { get; set; }
        public int NonBillableProductID { get; set; }        
    }
}
