using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QPH_ParamsChannelsEnterprise.Core.Entities.AdministrationSwitch;

namespace QPH_ParamsChannelsEnterprise.Infrastructure.Data.Configurations.AdministrationSwitch
{
    public partial class EnterpriseCredentialsConfiguration : IEntityTypeConfiguration<EnterpriseCredentials>
    {
        public void Configure(EntityTypeBuilder<EnterpriseCredentials> builder)
        {
            builder.ToTable("EnterpriseCredentials");

            builder.HasKey(e => e.IDEnterpriseCredentials);

            builder.Property(e => e.IDEnterpriseCredentials)
                .HasColumnName("IDEnterpriseCredentials")
                .UseIdentityColumn();

            builder.Property(e => e.EnterpriseID)
                .HasColumnName("EnterpriseID");

            builder.Property(e => e.CredentialsUserID)
                .HasColumnName("CredenTialsUserID");

            builder.Property(e => e.CredentialsServerID)
                .HasColumnName("CredentialsServerID");

            builder.Property(e => e.Status)
                .HasColumnName("Status");
        }
    }
}
