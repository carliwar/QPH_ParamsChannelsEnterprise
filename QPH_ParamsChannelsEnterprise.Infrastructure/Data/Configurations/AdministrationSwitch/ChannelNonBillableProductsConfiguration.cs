using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QPH_ParamsChannelsEnterprise.Core.Entities.AdministrationSwitch;

namespace QPH_ParamsChannelsEnterprise.Infrastructure.Data.Configurations.AdministrationSwitch
{
    public partial class ChannelNonBillableProductsConfiguration : IEntityTypeConfiguration<ChannelNonBillableProducts>
    {
        public void Configure(EntityTypeBuilder<ChannelNonBillableProducts> builder)
        {
            builder.ToTable("ChannelNonBillableProducts");

            builder.HasKey(e => e.IDChannelNonBillableProducts);

            builder.Property(e => e.IDChannelNonBillableProducts)
                .HasColumnName("IDChannelNonBillableProducts")
                .UseIdentityColumn();

            builder.Property(e => e.ChannelID)
                .HasColumnName("ChannelID");

            builder.Property(e => e.NonBillableProductID)
                .HasColumnName("NonBillableProductID");
        }
    }
}
