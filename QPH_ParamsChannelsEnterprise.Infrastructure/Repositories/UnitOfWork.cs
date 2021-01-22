using QPH_ParamsChannelsEnterprise.Core.Interfaces;
using QPH_ParamsChannelsEnterprise.Core.Interfaces.Repositories;
using QPH_ParamsChannelsEnterprise.Infrastructure.Data;
using System.Threading.Tasks;

namespace QPH_ParamsChannelsEnterprise.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AdministrationSwitchContext _administrationSwitchContext;
        private readonly SwitchAtiscodeContext _switchAtiscodeContext;

        private readonly IBusinessLineRepository _businessLineRepository;
        private readonly IChannelRepository _channelRepository;
        private readonly IChannelEnterpriseRepository _channelEnterpriseRepository;
        private readonly IChannelNonBillableProductsRepository _channelNonBillableProductsRepository;
        private readonly ICredentialsServerRepository _credentialsServerRepository;
        private readonly ICredentialsUserRepository _credentialsUserRepository;
        private readonly IEnterpriseRepository _enterpriseRepository;
        private readonly IEnterpriseCredentialsRepository _enterpriseCredentialsRepository;
        private readonly IFinancialDimensionRepository _financialDimensionRepository;
        private readonly IFinancialSizingRepository _financialSizingRepository;
        private readonly INonBillableProductsRepository _nonBillableProductsRepository;
        private readonly IQueryManagerRepository _queryManagerRepository;
        private readonly ISubBusinessLineRepository _subBusinessLineRepository;
        private readonly IAdministrationSwitchProceduresRepository _administrationSwitchProceduresRepository;


        private readonly IAtisLogTranRepository _atisLogTranRepository;
        private readonly IParametersRepository _parametersRepository;
        private readonly ISwitchAtiscodeProceduresRepository _switchAtiscodeProceduresRepository;

        public UnitOfWork(AdministrationSwitchContext administrationSwitchContext, SwitchAtiscodeContext switchAtiscodeContext)
        {
            _administrationSwitchContext = administrationSwitchContext;
            _switchAtiscodeContext = switchAtiscodeContext;
        }

        #region AdministrationSwitch Repositories
        public IBusinessLineRepository BusinessLineRepository
            => _businessLineRepository ?? new BusinessLineRepository(_administrationSwitchContext);

        public IChannelRepository ChannelRepository
            => _channelRepository ?? new ChannelRepository(_administrationSwitchContext);

        public IChannelEnterpriseRepository ChannelEnterpriseRepository
            => _channelEnterpriseRepository ?? new ChannelEnterpriseRepository(_administrationSwitchContext);

        public IAdministrationSwitchProceduresRepository AdministrationSwitchProceduresRepository
            => _administrationSwitchProceduresRepository ?? new AdministrationSwitchProceduresRepository(_administrationSwitchContext);

        public IChannelNonBillableProductsRepository ChannelNonBillableProductsRepository
            => _channelNonBillableProductsRepository ?? new ChannelNonBillableProductsRepository(_administrationSwitchContext);

        public ICredentialsServerRepository CredentialsServerRepository
            => _credentialsServerRepository ?? new CredentialsServerRepository(_administrationSwitchContext);

        public ICredentialsUserRepository CredentialsUserRepository
            => _credentialsUserRepository ?? new CredentialsUserRepository(_administrationSwitchContext);

        public IEnterpriseRepository EnterpriseRepository
            => _enterpriseRepository ?? new EnterpriseRepository(_administrationSwitchContext);

        public IEnterpriseCredentialsRepository EnterpriseCredentialsRepository
            => _enterpriseCredentialsRepository ?? new EnterpriseCredentialsRepository(_administrationSwitchContext);

        public IFinancialDimensionRepository FinancialDimensionRepository
            => _financialDimensionRepository ?? new FinancialDimensionRepository(_administrationSwitchContext);

        public IFinancialSizingRepository FinancialSizingRepository
            => _financialSizingRepository ?? new FinancialSizingRepository(_administrationSwitchContext);      

        public INonBillableProductsRepository NonBillableProductsRepository
            => _nonBillableProductsRepository ?? new NonBillableProductsRepository(_administrationSwitchContext);

        public IQueryManagerRepository QueryManagerRepository
            => _queryManagerRepository ?? new QueryManagerRepository(_administrationSwitchContext);

        public ISubBusinessLineRepository SubBusinessLineRepository
            => _subBusinessLineRepository ?? new SubBusinessLineRepository(_administrationSwitchContext);
        #endregion

        #region Switch Atiscode Repositories
        public IAtisLogTranRepository AtisLogTranRepository
            => _atisLogTranRepository ?? new AtisLogTranRepository(_switchAtiscodeContext);

        public IParametersRepository ParametersRepository
            => _parametersRepository ?? new ParametersRepository(_switchAtiscodeContext);

        public ISwitchAtiscodeProceduresRepository SwitchAtiscodeProceduresRepository
            => _switchAtiscodeProceduresRepository ?? new SwitchAtiscodeProceduresRepository(_switchAtiscodeContext);
        #endregion

        public void Dispose()
        {
            if (_administrationSwitchContext != null) _administrationSwitchContext.Dispose();
            if (_switchAtiscodeContext != null) _switchAtiscodeContext.Dispose();
        }
        public void SaveAdministrationSwitchChanges() => _administrationSwitchContext.SaveChanges();
        public async Task SaveAdministrationSwitchChangesAsync() => await _administrationSwitchContext.SaveChangesAsync();
        public void SaveSwitchAtiscodeChanges() => _administrationSwitchContext.SaveChanges();
        public async Task SaveSwitchAtiscodeChangesAsync() => await _administrationSwitchContext.SaveChangesAsync();

    }
}
