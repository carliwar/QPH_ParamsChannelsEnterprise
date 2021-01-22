using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QPH_ParamsChannelsEnterprise.Core.Entities.SwitchAtiscode;

namespace QPH_ParamsChannelsEnterprise.Infrastructure.Data.Configurations.SwitchAtiscode
{
    public partial class AtisLogTranConfiguration : IEntityTypeConfiguration<AtisLogTran>
    {
        public void Configure(EntityTypeBuilder<AtisLogTran> builder)
        {
            builder.ToTable("AtisLogTran");

            builder.HasKey(e => e.IdLogTran);

            builder.Property(e => e.IdLogTran)
                .HasColumnName("IdLogTran")
                .UseIdentityColumn();

            builder.Property(e => e.NumeroDocumento)
                .HasColumnName("NumeroDocumento");

            builder.Property(e => e.TramaEntrada)
                .HasColumnName("TramaEntrada");

            builder.Property(e => e.FechaEntrada)
                .HasColumnName("FechaEntrada");

            builder.Property(e => e.Estado)
                .HasColumnName("Estado");

            builder.Property(e => e.TramaRespuesta)
                .HasColumnName("TramaRespuesta");

            builder.Property(e => e.FechaSalida)
                .HasColumnName("FechaSalida");

            builder.Property(e => e.Tipo)
                .HasColumnName("Tipo");

            builder.Property(e => e.Secuencial)
                .HasColumnName("Secuencial");

            builder.Property(e => e.Canal)
                .HasColumnName("Canal");

            builder.Property(e => e.TipoSolicitud)
                .HasColumnName("TipoSolicitud");
        }
    }
}
