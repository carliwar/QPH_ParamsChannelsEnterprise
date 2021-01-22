using System.Collections.Generic;

namespace QPH_ParamsChannelsEnterprise.Core.Entities.AdministrationSwitch
{
    public partial class Enterprise
    {
        public int IDEnterprise { get; set; }
        public string Establecimiento { get; set; }
        public string RazonSocial { get; set; }
        public string RUC { get; set; }
        public string DireccionMatriz { get; set; }
        public bool TributaImpuesto { get; set; }
        public string Contribuyente { get; set; }
        public string Ciudad { get; set; }
        public string Telefono { get; set; }
        public bool Status { get; set; }
    }
}
