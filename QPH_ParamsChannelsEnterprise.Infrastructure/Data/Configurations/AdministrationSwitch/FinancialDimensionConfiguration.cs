using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QPH_ParamsChannelsEnterprise.Core.Entities.AdministrationSwitch;

namespace QPH_ParamsChannelsEnterprise.Infrastructure.Data.Configurations.AdministrationSwitch
{
    public partial class FinancialDimensionConfiguration : IEntityTypeConfiguration<FinancialDimension>
    {
        public void Configure(EntityTypeBuilder<FinancialDimension> builder)
        {
            builder.ToTable("FinancialDimension");

            builder.HasKey(e => e.IDFinancialDimension);

            builder.Property(e => e.IDFinancialDimension)
                .HasColumnName("IDFinancialDimension")
                .UseIdentityColumn();

            builder.Property(e => e.Name)
                .HasColumnName("Name");

            builder.Property(e => e.Description)
                .HasColumnName("Description");

            builder.Property(e => e.CodeCostCenter)
                .HasColumnName("CodeCostCenter");

            builder.Property(e => e.Status)
                .HasColumnName("Status");
        }
    }
}
