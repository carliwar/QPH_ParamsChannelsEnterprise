using System.Collections.Generic;

namespace QPH_ParamsChannelsEnterprise.Core.Entities.AdministrationSwitch
{
    public partial class CredentialsUser
    {
        public int IDCredentialsUser { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }        
    }
}
