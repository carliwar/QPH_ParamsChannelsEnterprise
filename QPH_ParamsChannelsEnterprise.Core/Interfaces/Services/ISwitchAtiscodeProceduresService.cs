using QPH_ParamsChannelsEnterprise.Core.CustomEntities;
using QPH_ParamsChannelsEnterprise.Core.DTOs;
using System.Threading.Tasks;

namespace QPH_ParamsChannelsEnterprise.Core.Interfaces.Services
{
    public interface ISwitchAtiscodeProceduresService
    {
        Task<AtisLogTranDTO> LiberarSecuencial(ManageSequential manageSequential);
    }
}
