using QPH_ParamsChannelsEnterprise.Core.Entities.AdministrationSwitch;
using System.Threading.Tasks;

namespace QPH_ParamsChannelsEnterprise.Core.Interfaces.Repositories
{
    public interface INonBillableProductsRepository : IRepository<NonBillableProducts>
    {
        Task<NonBillableProducts> GetByCode(string code, int? oldCode);
    }
}
