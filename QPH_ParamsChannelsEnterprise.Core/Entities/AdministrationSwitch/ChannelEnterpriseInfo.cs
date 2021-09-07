using System;

namespace QPH_ParamsChannelsEnterprise.Core.Entities.AdministrationSwitch
{
    public class ChannelEnterpriseInfo
    {
        public int IDChannelEnterprise { get; set; }
        public long IDChannel { get; set; }
        public DateTime? Fecha { get; set; }
        public string Segmento { get; set; }
        public string PuntoEmision { get; set; }
        public int? Ambiente { get; set; }
        public int? Iva { get; set; }
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public string CategoriaCliente { get; set; }
        public string CuentaContable { get; set; }
        public int? GrupoCredito { get; set; }
        public int? DocumentoElectronico { get; set; }
        public int? Relacionado { get; set; }
        public string ListaPrecioCredito { get; set; }
        public int? LimiteCredito { get; set; }
        public string Uge { get; set; }
        public string Bodega { get; set; }
        public string TipoFormaPago { get; set; }
        public string StatusChannel { get; set; }
        public int IDEnterprise { get; set; }
        public string Establecimiento { get; set; }
        public string RazonSocial { get; set; }
        public string RUC { get; set; }
        public string DireccionMatriz { get; set; }
        public bool? TributaImpuesto { get; set; }
        public string Contribuyente { get; set; }
        public string Ciudad { get; set; }
        public string Telefono { get; set; }
        public bool Status { get; set; }
        public string EnlaceInvoice { get; set; }
        public string EnlaceCreditNote { get; set; }
        public string EnlaceCotization { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string AuthotizationNumber { get; set; }
        public int? ProductItemGroupCode { get; set; }
        public string Declarable { get; set; }
        public string IVACode { get; set; }
        public int? IdentificatorChannelSAP { get; set; }
        public int? IdentificatorChannelCreditNoteSAP { get; set; }
        public bool? PaymentReceivedRequired { get; set; }
        public DateTime? LimitStartDateTransactions { get; set; }
        public DateTime? LimitFinishDateTransactions { get; set; }
        public string BalanceAccount { get; set; }
        //public int? CredentialsUserID { get; set; }
        public string Username { get; set; }
        public int? CredentialsServerID { get; set; }
        public string UsernameServer { get; set; }
        public string PasswordServer { get; set; }
        public string Servername { get; set; }
        public string Databasename { get; set; }
        public int? FinancialSizingID { get; set; }
        public string NombreDimension1 { get; set; }
        public string Dimension1 { get; set; }
        public string NombreDimension2 { get; set; }
        public string Dimension2 { get; set; }
        public string NombreDimension3 { get; set; }
        public string CodeDimension3 { get; set; }
        public string Dimension3 { get; set; }
        public string PasswordUser { get; set; }
        public int? CodeCreditCard { get; set; }
        public string CodigoMotivoNotaCredito { get; set; }
        public string PaymentMadeAccount { get; set; }
        public bool StatusInvoice { get; set; }
        public bool StatusCreditNote { get; set; }
        public bool StatusCotization { get; set; }
        public int? StartDay { get; set; }
        public int? FinishDay { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? FinishTime { get; set; }
    }
}
