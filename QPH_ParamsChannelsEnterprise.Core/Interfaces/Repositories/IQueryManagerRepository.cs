using QPH_ParamsChannelsEnterprise.Core.Entities.AdministrationSwitch;
using System.Threading.Tasks;

namespace QPH_ParamsChannelsEnterprise.Core.Interfaces.Repositories
{
    public interface IQueryManagerRepository : IRepository<QueryManager>
    {
        Task<QueryManager> GetByCode(string code, int? oldID);
    }
}
