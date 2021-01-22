using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QPH_ParamsChannelsEnterprise.Core.Entities.AdministrationSwitch;

namespace QPH_ParamsChannelsEnterprise.Infrastructure.Data.Configurations.AdministrationSwitch
{
    public partial class BusinessLineConfiguration : IEntityTypeConfiguration<BusinessLine>
    {
        public void Configure(EntityTypeBuilder<BusinessLine> builder)
        {
            builder.ToTable("BusinessLine");

            builder.HasKey(e => e.IDBusinessLine);

            builder.Property(e => e.IDBusinessLine)
                .HasColumnName("IDBusinessLine")
                .UseIdentityColumn();

            builder.Property(e => e.Name)
                .HasColumnName("Name");

            builder.Property(e => e.Description)
                .HasColumnName("Description");

            builder.Property(e => e.Status)
               .HasColumnName("Status");

            builder.Property(e => e.CodeCostCenter)
               .HasColumnName("CodeCostCenter");
        }
    }
}
