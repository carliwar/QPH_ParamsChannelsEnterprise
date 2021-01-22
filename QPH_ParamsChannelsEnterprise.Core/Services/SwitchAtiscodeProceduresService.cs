using QPH_ParamsChannelsEnterprise.Core.CustomEntities;
using QPH_ParamsChannelsEnterprise.Core.DTOs;
using QPH_ParamsChannelsEnterprise.Core.Entities.SwitchAtiscode;
using QPH_ParamsChannelsEnterprise.Core.Interfaces;
using QPH_ParamsChannelsEnterprise.Core.Interfaces.Services;
using System.Linq;
using System.Threading.Tasks;

namespace QPH_ParamsChannelsEnterprise.Core.Services
{
    public class SwitchAtiscodeProceduresService : ISwitchAtiscodeProceduresService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SwitchAtiscodeProceduresService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AtisLogTranDTO> LiberarSecuencial(ManageSequential manageSequential)
        {
            AtisLogTran infoDocument = _unitOfWork.AtisLogTranRepository.GetAll().FirstOrDefault(
                s => s.Canal.Contains(manageSequential.Channel) &&
                     s.Tipo.Contains(manageSequential.TypeDocument) &&
                     s.Secuencial.Contains(manageSequential.Sequential) &&
                     !string.IsNullOrEmpty(s.NumeroDocumento));

            var result = new AtisLogTranDTO
            {
                Canal = manageSequential.Channel,
                Secuencial = manageSequential.Sequential,
                Tipo = manageSequential.TypeDocument
            };

            if (infoDocument != null)
            {
                await _unitOfWork.SwitchAtiscodeProceduresRepository
                    .LiberarSecuencial(manageSequential.Channel, manageSequential.Sequential, manageSequential.TypeDocument);

                result.NumeroDocumento = infoDocument.NumeroDocumento;
            }

            return result;
        }
    }
}
