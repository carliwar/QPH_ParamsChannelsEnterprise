using System.Collections.Generic;

namespace QPH_ParamsChannelsEnterprise.Core.Entities.AdministrationSwitch
{
    public partial class CredentialsServer
    {
        public int IDCredentialsServer { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Servername { get; set; }
        public string Databasename { get; set; }
        public bool Status { get; set; }
    }
}
