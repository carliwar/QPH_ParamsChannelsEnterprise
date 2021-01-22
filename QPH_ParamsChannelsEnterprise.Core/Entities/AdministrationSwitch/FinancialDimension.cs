using System.Collections.Generic;

namespace QPH_ParamsChannelsEnterprise.Core.Entities.AdministrationSwitch
{
    public partial class FinancialDimension
    {
        public int IDFinancialDimension { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CodeCostCenter { get; set; }
        public bool Status { get; set; }   
    }
}
