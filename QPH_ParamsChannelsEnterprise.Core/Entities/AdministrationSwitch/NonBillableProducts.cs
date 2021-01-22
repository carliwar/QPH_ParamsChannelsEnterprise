using System.Collections.Generic;

namespace QPH_ParamsChannelsEnterprise.Core.Entities.AdministrationSwitch
{
    public partial class NonBillableProducts
    {
        public int IDNonBillableProducts { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
