using System;
using System.Collections.Generic;

namespace QPH_ParamsChannelsEnterprise.Core.DTOs
{
    public class ChannelDTO : BaseDTO
    {
        public DateTime Fecha { get; set; }
        public string Segmento { get; set; }
        public string PuntoEmision { get; set; }
        public string Code { get; set; }
        public int? IdentificatorChannelSAP { get; set; }
        public int? IdentificatorChannelCreditNoteSAP { get; set; }
        public string Description { get; set; }
        public string AuthorizationNumber { get; set; }
        public int? ProductItemGroupCode { get; set; }
        public string Declarable { get; set; }
        public string IVACode { get; set; }
        public string PaymentReceivedRequired { get; set; }
        public int? CodeCreditCard { get; set; }
        public int? Ambiente { get; set; }
        public int? Iva { get; set; }
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public string CategoriaCliente { get; set; }
        public string CuentaContable { get; set; }
        public string BalanceAccount { get; set; }
        public int? GrupoCredito { get; set; }
        public int EnterpriseID { get; set; }
        public int? DocumentoElectronico { get; set; }
        public int? Relacionado { get; set; }
        public string CodigoMotivoNotaCredito { get; set; }
        public string PaymentMadeAccount { get; set; }
        public string ListaPrecioCredito { get; set; }
        public int? LimiteCredito { get; set; }
        public string Uge { get; set; }
        public string Bodega { get; set; }
        public string TipoFormaPago { get; set; }
        public string StatusChannel { get; set; }
        public string EnlaceInvoice { get; set; }
        public string EnlaceCreditNote { get; set; }
        public string EnlaceCotization { get; set; }
        public string Status { get; set; }
        public int? FinancialSizingID { get; set; }
        public List<int> NonBillableProducts { get; set; }
        public DateTime LimitStartDateTransactions { get; set; }
        public DateTime LimitFinishDateTransactions { get; set; }
    }
}
