using QPH_ParamsChannelsEnterprise.Core.Interfaces.Repositories;
using System.Threading.Tasks;

namespace QPH_ParamsChannelsEnterprise.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IBusinessLineRepository BusinessLineRepository { get; }
        IChannelRepository ChannelRepository { get; }
        IChannelEnterpriseRepository ChannelEnterpriseRepository { get; }        
        IChannelNonBillableProductsRepository ChannelNonBillableProductsRepository { get; }
        ICredentialsServerRepository CredentialsServerRepository { get; }
        ICredentialsUserRepository CredentialsUserRepository { get; }
        IEnterpriseRepository EnterpriseRepository { get; }
        IEnterpriseCredentialsRepository EnterpriseCredentialsRepository { get; }
        IFinancialDimensionRepository FinancialDimensionRepository { get; }
        IFinancialSizingRepository FinancialSizingRepository { get; }
        INonBillableProductsRepository NonBillableProductsRepository { get; }
        IQueryManagerRepository QueryManagerRepository { get; }
        ISubBusinessLineRepository SubBusinessLineRepository { get; }
        IAdministrationSwitchProceduresRepository AdministrationSwitchProceduresRepository { get; }

        IAtisLogTranRepository AtisLogTranRepository { get; }
        IParametersRepository ParametersRepository { get; }
        ISwitchAtiscodeProceduresRepository SwitchAtiscodeProceduresRepository { get; }

        void SaveAdministrationSwitchChanges();
        Task SaveAdministrationSwitchChangesAsync();        
        void SaveSwitchAtiscodeChanges();
        Task SaveSwitchAtiscodeChangesAsync();
    }
}
