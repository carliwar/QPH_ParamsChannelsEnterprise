using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QPH_ParamsChannelsEnterprise.Core.Entities.AdministrationSwitch;

namespace QPH_ParamsChannelsEnterprise.Infrastructure.Data.Configurations.AdministrationSwitch
{
    public partial class ChannelEnterpriseConfiguration : IEntityTypeConfiguration<ChannelEnterprise>
    {
        public void Configure(EntityTypeBuilder<ChannelEnterprise> builder)
        {
            builder.ToTable("ChannelEnterprise");

            builder.HasKey(e => e.IDChannelEnterprise);

            builder.Property(e => e.IDChannelEnterprise)
                .HasColumnName("IDChannelEnterprise")
                .UseIdentityColumn();

            builder.Property(e => e.IDEnterprise)
                .IsRequired()
                .HasColumnName("IDEnterprise");

            builder.Property(e => e.IDChannel)
                .IsRequired()
                .HasColumnName("IDChannel");

            builder.Property(e => e.Status)
                .IsRequired()
                .HasColumnName("Status");
        }
    }
}
