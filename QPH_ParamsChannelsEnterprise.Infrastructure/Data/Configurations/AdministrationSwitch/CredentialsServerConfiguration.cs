using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QPH_ParamsChannelsEnterprise.Core.Entities.AdministrationSwitch;

namespace QPH_ParamsChannelsEnterprise.Infrastructure.Data.Configurations.AdministrationSwitch
{
    public partial class CredentialsServerConfiguration : IEntityTypeConfiguration<CredentialsServer>
    {
        public void Configure(EntityTypeBuilder<CredentialsServer> builder)
        {
            builder.ToTable("CredentialsServer");

            builder.HasKey(e => e.IDCredentialsServer);

            builder.Property(e => e.IDCredentialsServer)
                    .HasColumnName("IDCredentialsServer")
                    .UseIdentityColumn();

            builder.Property(e => e.Username)
                    .HasColumnName("Username");

            builder.Property(e => e.Password)
                    .HasColumnName("Password");

            builder.Property(e => e.Servername)
                .HasColumnName("Servername");

            builder.Property(e => e.Databasename)
                .HasColumnName("Databasename");

            builder.Property(e => e.Status)
                .HasColumnName("Status");
        }
    }
}
