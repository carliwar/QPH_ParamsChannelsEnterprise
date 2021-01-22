using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QPH_ParamsChannelsEnterprise.Core.Entities.AdministrationSwitch;

namespace QPH_ParamsChannelsEnterprise.Infrastructure.Data.Configurations.AdministrationSwitch
{
    public partial class CredentialsUserConfiguration : IEntityTypeConfiguration<CredentialsUser>
    {
        public void Configure(EntityTypeBuilder<CredentialsUser> builder)
        {
            builder.ToTable("CredentialsUser");

            builder.HasKey(e => e.IDCredentialsUser);

            builder.Property(e => e.IDCredentialsUser)
                    .HasColumnName("IDCredentialsUser")
                    .UseIdentityColumn();

            builder.Property(e => e.Username)
                    .HasColumnName("Username");

            builder.Property(e => e.Password)
                    .HasColumnName("Password");

            builder.Property(e => e.Status)
                .HasColumnName("Status");
        }
    }
}
