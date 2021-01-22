using Microsoft.EntityFrameworkCore;
using QPH_ParamsChannelsEnterprise.Core.Entities.AdministrationSwitch;
using QPH_ParamsChannelsEnterprise.Core.Interfaces;
using System.Reflection;

namespace QPH_ParamsChannelsEnterprise.Infrastructure.Data
{
    public class AdministrationSwitchContext : DbContext, IContext
    {
        public AdministrationSwitchContext() { }
        public AdministrationSwitchContext(DbContextOptions<AdministrationSwitchContext> options) : base(options) { }
        public virtual DbSet<BusinessLine> BusinessLine { get; set; }
        public virtual DbSet<Channel> Channel { get; set; }
        public virtual DbSet<ChannelEnterprise> ChannelEnterprise { get; set; }
        public virtual DbSet<ChannelEnterpriseInfo> ChannelEnterpriseInfo { get; set; }
        public virtual DbSet<ChannelNonBillableProducts> ChannelNonBillableProducts { get; set; }
        public virtual DbSet<CredentialsServer> CredentialsServer { get; set; }
        public virtual DbSet<CredentialsUser> CredentialsUser { get; set; }
        public virtual DbSet<Enterprise> Enterprise { get; set; }
        public virtual DbSet<EnterpriseCredentials> EnterpriseCredentials { get; set; }
        public virtual DbSet<FinancialDimension> FinancialDimension { get; set; }
        public virtual DbSet<FinancialSizing> FinancialSizing { get; set; }
        public virtual DbSet<FinancialSizingViewResults> FinancialSizingViewResults { get; set; }
        public virtual DbSet<GetNonBilllableProductsResult> GetNonBilllableProductsResult { get; set; }
        public virtual DbSet<NonBillableProducts> NonBillableProducts { get; set; }
        public virtual DbSet<QueryManager> QueryManager { get; set; }
        public virtual DbSet<SubBusinessLine> SubBusinessLine { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FinancialSizingViewResults>().HasNoKey().ToView(null);
            modelBuilder.Entity<ChannelEnterpriseInfo>().HasNoKey().ToView(null);
            modelBuilder.Entity<GetNonBilllableProductsResult>().HasNoKey().ToView(null);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
