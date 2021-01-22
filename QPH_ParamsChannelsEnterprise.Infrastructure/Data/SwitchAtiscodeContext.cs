using Microsoft.EntityFrameworkCore;
using QPH_ParamsChannelsEnterprise.Core.Entities.SwitchAtiscode;
using QPH_ParamsChannelsEnterprise.Core.Interfaces;
using System.Reflection;

namespace QPH_ParamsChannelsEnterprise.Infrastructure.Data
{
    public class SwitchAtiscodeContext : DbContext, IContext
    {
        public SwitchAtiscodeContext() { }
        public SwitchAtiscodeContext(DbContextOptions<SwitchAtiscodeContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LiberarSecuencialResult>().HasNoKey().ToView(null);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
