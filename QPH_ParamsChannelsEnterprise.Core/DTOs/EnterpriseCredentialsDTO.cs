namespace QPH_ParamsChannelsEnterprise.Core.DTOs
{
    public class EnterpriseCredentialsDTO : BaseDTO
    {
        public int EnterpriseID { get; set; }
        public int CredentialsUserID { get; set; }
        public int CredentialsServerID { get; set; }
        public string Status { get; set; }
    }
}
