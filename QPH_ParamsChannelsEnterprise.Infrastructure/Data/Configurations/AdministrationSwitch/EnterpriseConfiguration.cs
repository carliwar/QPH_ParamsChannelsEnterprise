using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QPH_ParamsChannelsEnterprise.Core.Entities.AdministrationSwitch;

namespace QPH_ParamsChannelsEnterprise.Infrastructure.Data.Configurations.AdministrationSwitch
{
    public partial class EnterpriseConfiguration : IEntityTypeConfiguration<Enterprise>
    {
        public void Configure(EntityTypeBuilder<Enterprise> builder)
        {
            builder.ToTable("Enterprise");

            builder.HasKey(e => e.IDEnterprise);

            builder.Property(e => e.IDEnterprise)
                .HasColumnName("IDEnterprise")
                .UseIdentityColumn();

            builder.Property(e => e.Establecimiento)
                .HasColumnName("Establecimiento");

            builder.Property(e => e.RazonSocial)
                .HasColumnName("RazonSocial");

            builder.Property(e => e.RUC)
                .HasColumnName("RUC");

            builder.Property(e => e.DireccionMatriz)
                .HasColumnName("DireccionMatriz");

            builder.Property(e => e.TributaImpuesto)
                .HasColumnName("TributaImpuesto");

            builder.Property(e => e.Contribuyente)
                .HasColumnName("Contribuyente");

            builder.Property(e => e.Ciudad)
                .HasColumnName("Ciudad");

            builder.Property(e => e.Telefono)
                .HasColumnName("Telefono");

            builder.Property(e => e.Status)
                .HasColumnName("Status");
        }
    }
}
