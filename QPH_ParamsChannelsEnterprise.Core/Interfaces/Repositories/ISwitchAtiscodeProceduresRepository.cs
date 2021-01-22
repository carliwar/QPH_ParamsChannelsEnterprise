using System.Threading.Tasks;

namespace QPH_ParamsChannelsEnterprise.Core.Interfaces.Repositories
{
    public interface ISwitchAtiscodeProceduresRepository
    {
        Task LiberarSecuencial(string channel, string sequential, string typeDocument);
    }
}
