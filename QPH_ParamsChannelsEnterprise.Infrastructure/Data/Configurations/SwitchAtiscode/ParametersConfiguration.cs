using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QPH_ParamsChannelsEnterprise.Core.Entities.SwitchAtiscode;

namespace QPH_ParamsChannelsEnterprise.Infrastructure.Data.Configurations.SwitchAtiscode
{
    public partial class ParametersConfiguration : IEntityTypeConfiguration<Parameters>
    {
        public void Configure(EntityTypeBuilder<Parameters> builder)
        {
            builder.ToTable("Parameters");

            builder.HasKey(e => e.IDParameters);

            builder.Property(e => e.IDParameters)
                .HasColumnName("IDParameters")
                .UseIdentityColumn();

            builder.Property(e => e.Name)
                .HasColumnName("Name");

            builder.Property(e => e.Value)
                .HasColumnName("Value");

            builder.Property(e => e.Code)
                .HasColumnName("Code");
        }
    }
}
