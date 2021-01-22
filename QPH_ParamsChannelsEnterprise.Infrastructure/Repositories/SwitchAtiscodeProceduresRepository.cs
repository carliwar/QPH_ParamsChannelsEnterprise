using Microsoft.EntityFrameworkCore;
using QPH_ParamsChannelsEnterprise.Core.Interfaces.Repositories;
using QPH_ParamsChannelsEnterprise.Infrastructure.Data;
using System.Threading.Tasks;

namespace QPH_ParamsChannelsEnterprise.Infrastructure.Repositories
{
    public class SwitchAtiscodeProceduresRepository : ISwitchAtiscodeProceduresRepository
    {
        private readonly SwitchAtiscodeContext _context;

        public SwitchAtiscodeProceduresRepository(SwitchAtiscodeContext context)
        {
            _context = context;
        }

        public async Task LiberarSecuencial(string channel, string sequential, string typeDocument)
        {
            await _context.Database.ExecuteSqlRawAsync("exec LiberarSecuencial @canal={0},@secuencial={1},@tipo={2}",
                 channel, sequential, typeDocument);
        }
    }
}
