using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QPH_ParamsChannelsEnterprise.Core.Entities.AdministrationSwitch;

namespace QPH_ParamsChannelsEnterprise.Infrastructure.Data.Configurations.AdministrationSwitch
{
    public partial class FinancialSizingViewResultConfiguration : IEntityTypeConfiguration<FinancialSizingViewResults>
    {
        public void Configure(EntityTypeBuilder<FinancialSizingViewResults> builder)
        { 
            builder.Property(e => e.IDFinancialSizing)
                .HasColumnName("IDFinancialSizing");

            builder.Property(e => e.Dimension1ID)
                .HasColumnName("Dimension1ID");

            builder.Property(e => e.NombreDimension1)
               .HasColumnName("NombreDimension1");

            builder.Property(e => e.Dimension1)
               .HasColumnName("Dimension1");

            builder.Property(e => e.Dimension2ID)
                .HasColumnName("Dimension2ID");

            builder.Property(e => e.NombreDimension2)
               .HasColumnName("NombreDimension2");

            builder.Property(e => e.Dimension2)
               .HasColumnName("Dimension2");

            builder.Property(e => e.Dimension3ID)
                .HasColumnName("Dimension3ID");

            builder.Property(e => e.NombreDimension3)
               .HasColumnName("NombreDimension3");

            builder.Property(e => e.Dimension3)
               .HasColumnName("Dimension3");

            builder.HasNoKey().ToView(null);
        }
    }
}
