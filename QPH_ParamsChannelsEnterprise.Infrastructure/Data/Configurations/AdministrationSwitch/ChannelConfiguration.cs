using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QPH_ParamsChannelsEnterprise.Core.Entities.AdministrationSwitch;
namespace QPH_ParamsChannelsEnterprise.Infrastructure.Data.Configurations.AdministrationSwitch
{
    public class ChannelConfiguration : IEntityTypeConfiguration<Channel>
    {
        public void Configure(EntityTypeBuilder<Channel> builder)
        {
            builder.ToTable("Channel");

            builder.HasKey(e => e.IDChannel);

            builder.Property(e => e.IDChannel)
                .HasColumnName("IDChannel")
                .UseIdentityColumn();

            builder.Property(e => e.Fecha)
                .HasColumnName("Fecha");

            builder.Property(e => e.Segmento)
                .HasColumnName("Segmento");

            builder.Property(e => e.PuntoEmision)
                .HasColumnName("PuntoEmision");

            builder.Property(e => e.Code)
                .HasColumnName("Code");

            builder.Property(e => e.IdentificatorChannelSAP)
                .HasColumnName("IdentificatorChannelSAP");

            builder.Property(e => e.IdentificatorChannelCreditNoteSAP)
                .HasColumnName("IdentificatorChannelCreditNoteSAP");

            builder.Property(e => e.Description)
                .HasColumnName("Description");

            builder.Property(e => e.AuthotizationNumber)
                .HasColumnName("AuthotizationNumber");

            builder.Property(e => e.ProductItemGroupCode)
                .HasColumnName("ProductItemGroupCode");

            builder.Property(e => e.Declarable)
                .HasColumnName("Declarable");

            builder.Property(e => e.IVACode)
                .HasColumnName("IVACode");

            builder.Property(e => e.PaymentReceivedRequired)
                .HasColumnName("PaymentReceivedRequired");

            builder.Property(e => e.CodeCreditCard)
                .HasColumnName("CodeCreditCard");

            builder.Property(e => e.Ambiente)
                .HasColumnName("Ambiente");

            builder.Property(e => e.Iva)
                .HasColumnName("Iva");

            builder.Property(e => e.CodigoProducto)
                .HasColumnName("CodigoProducto");

            builder.Property(e => e.NombreProducto)
                .HasColumnName("NombreProducto");

            builder.Property(e => e.CategoriaCliente)
                .HasColumnName("CategoriaCliente");

            builder.Property(e => e.CuentaContable)
                .HasColumnName("CuentaContable");

            builder.Property(e => e.BalanceAccount)
                .HasColumnName("BalanceAccount");

            builder.Property(e => e.GrupoCredito)
                .HasColumnName("GrupoCredito");

            builder.Property(e => e.DocumentoElectronico)
                .HasColumnName("DocumentoElectronico");

            builder.Property(e => e.Relacionado)
                .HasColumnName("Relacionado");

            builder.Property(e => e.CodigoMotivoNotaCredito)
                .HasColumnName("CodigoMotivoNotaCredito");

            builder.Property(e => e.PaymentMadeAccount)
                .HasColumnName("PaymentMadeAccount");

            builder.Property(e => e.ListaPrecioCredito)
                .HasColumnName("ListaPrecioCredito");

            builder.Property(e => e.LimiteCredito)
                .HasColumnName("LimiteCredito");

            builder.Property(e => e.Uge)
                .HasColumnName("Uge");

            builder.Property(e => e.Bodega)
                .HasColumnName("Bodega");

            builder.Property(e => e.TipoFormaPago)
                .HasColumnName("TipoFormaPago");

            builder.Property(e => e.StatusChannel)
                .HasColumnName("StatusChannel");

            builder.Property(e => e.EnlaceInvoice)
                .HasColumnName("EnlaceInvoice");

            builder.Property(e => e.EnlaceCreditNote)
                .HasColumnName("EnlaceCreditNote");

            builder.Property(e => e.EnlaceCotization)
                .HasColumnName("EnlaceCotization");

            builder.Property(e => e.Status)
                .HasColumnName("Status");

            builder.Property(e => e.FinancialSizingID)
                .HasColumnName("FinancialSizingID");

            builder.Property(e => e.LimitStartDateTransactions)
                .HasColumnName("LimitStartDateTransactions");

            builder.Property(e => e.LimitFinishDateTransactions)
                .HasColumnName("LimitFinishDateTransactions");
        }
    }
}
