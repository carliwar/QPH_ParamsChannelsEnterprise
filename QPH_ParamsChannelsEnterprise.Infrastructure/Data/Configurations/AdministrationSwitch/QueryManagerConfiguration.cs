using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QPH_ParamsChannelsEnterprise.Core.Entities.AdministrationSwitch;

namespace QPH_ParamsChannelsEnterprise.Infrastructure.Data.Configurations.AdministrationSwitch
{
    public partial class QueryManagerConfiguration : IEntityTypeConfiguration<QueryManager>
    {
        public void Configure(EntityTypeBuilder<QueryManager> builder)
        {
            builder.ToTable("QueryManager");

            builder.HasKey(e => e.IDQueryManager);

            builder.Property(e => e.IDQueryManager)
                .HasColumnName("IDQueryManager")
                .UseIdentityColumn();

            builder.Property(e => e.Code)
                .HasColumnName("Code");

            builder.Property(e => e.Description)
                .HasColumnName("Description");

            builder.Property(e => e.Query)
                .HasColumnName("Query");

            builder.Property(e => e.Status)
                .HasColumnName("Status");
        }
    }
}
