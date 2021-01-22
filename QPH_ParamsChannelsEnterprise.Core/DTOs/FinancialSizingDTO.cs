using System.Collections.Generic;

namespace QPH_ParamsChannelsEnterprise.Core.DTOs
{
    public class FinancialSizingDTO : BaseDTO
    {
        public int Dimension1ID { get; set; }
        public int Dimension2ID { get; set; }
        public int Dimension3ID { get; set; }
        public string Status { get; set; }

        public List<BusinessLineDTO> BusinessLines { get; set; }
        public List<SubBusinessLineDTO> SubBusinessLines { get; set; }
        public List<FinancialDimensionDTO> FinancialDimensions { get; set; }
    }
}
