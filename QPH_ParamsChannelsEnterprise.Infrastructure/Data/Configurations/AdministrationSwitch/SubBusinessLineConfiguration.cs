using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QPH_ParamsChannelsEnterprise.Core.Entities.AdministrationSwitch;

namespace QPH_ParamsChannelsEnterprise.Infrastructure.Data.Configurations.AdministrationSwitch
{
    public partial class SubBusinessLineConfiguration : IEntityTypeConfiguration<SubBusinessLine>
    {
        public void Configure(EntityTypeBuilder<SubBusinessLine> builder)
        {
            builder.ToTable("SubBusinessLine");

            builder.HasKey(e => e.IDSubBusinessLine);

            builder.Property(e => e.IDSubBusinessLine)
                .HasColumnName("IDSubBusinessLine")
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
