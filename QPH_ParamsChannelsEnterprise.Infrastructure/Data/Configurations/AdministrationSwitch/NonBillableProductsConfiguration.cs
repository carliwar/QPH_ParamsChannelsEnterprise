using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QPH_ParamsChannelsEnterprise.Core.Entities.AdministrationSwitch;

namespace QPH_ParamsChannelsEnterprise.Infrastructure.Data.Configurations.AdministrationSwitch
{
    public partial class NonBillableProductsConfiguration : IEntityTypeConfiguration<NonBillableProducts>
    {
        public void Configure(EntityTypeBuilder<NonBillableProducts> builder)
        {
            builder.ToTable("NonBillableProducts");

            builder.HasKey(e => e.IDNonBillableProducts);

            builder.Property(e => e.IDNonBillableProducts)
                .HasColumnName("IDNonBillableProducts")
                .UseIdentityColumn();

            builder.Property(e => e.Code)
                .HasColumnName("Code");

            builder.Property(e => e.Status)
                .HasColumnName("Status");
        }
    }
}
