using System.Collections.Generic;

namespace QPH_ParamsChannelsEnterprise.Core.Entities.AdministrationSwitch
{
    public partial class FinancialSizing
    {
        public int IDFinancialSizing { get; set; }
        public int Dimension1ID { get; set; }
        public int Dimension2ID { get; set; }
        public int Dimension3ID { get; set; }
        public bool Status { get; set; }
    }
}
