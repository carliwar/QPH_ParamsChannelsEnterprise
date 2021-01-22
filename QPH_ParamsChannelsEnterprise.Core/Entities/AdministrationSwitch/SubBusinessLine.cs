using System.Collections.Generic;

namespace QPH_ParamsChannelsEnterprise.Core.Entities.AdministrationSwitch
{
    public partial class SubBusinessLine
    {
        public int IDSubBusinessLine { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CodeCostCenter { get; set; }
        public bool Status { get; set; }
    }
}
