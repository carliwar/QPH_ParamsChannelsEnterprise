using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QPH_ParamsChannelsEnterprise.Core.Entities.AdministrationSwitch;

namespace QPH_ParamsChannelsEnterprise.Infrastructure.Data.Configurations.AdministrationSwitch
{
    public partial class FinancialSizingConfiguration : IEntityTypeConfiguration<FinancialSizing>
    {
        public void Configure(EntityTypeBuilder<FinancialSizing> builder)
        {
            builder.ToTable("FinancialSizing");

            builder.HasKey(e => e.IDFinancialSizing);

            builder.Property(e => e.IDFinancialSizing)
                .HasColumnName("IDFinancialSizing")
                .UseIdentityColumn();

            builder.Property(e => e.Dimension1ID)
                .IsRequired()
                .HasColumnName("Dimension1ID");

            builder.Property(e => e.Dimension2ID)
                .IsRequired()
                .HasColumnName("Dimension2ID");

            builder.Property(e => e.Dimension3ID)
                .IsRequired()
                .HasColumnName("Dimension3ID");

            builder.Property(e => e.Status)
                .IsRequired()
                .HasColumnName("Status");
        }
    }
}
