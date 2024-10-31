

using MedicalAppoiments.Domain.Entities.insurance;
using MedicalAppoiments.Domain.Result;
using MedicalAppoiments.Persistance.Interfaces.Iinsurance;
using MedicalAppointment.Application.Interfaces.IinsuranceService;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Application.Service.insurance.Service
{
    public class NetworkTypeService : INetworkTypeService
    {
        private readonly INetworkTypeRepository _networkTypeRepository;
        private readonly ILogger<NetworkTypeService> _logger;

        public NetworkTypeService(INetworkTypeRepository networkTypeRepository, ILogger<NetworkTypeService> logger)
        {
            _networkTypeRepository = networkTypeRepository;
            _logger = logger;
        }
        public async Task<OperationResult> DeleteNetworkTypeAsync(NetworkType networkType)
        {
            return await _networkTypeRepository.Remove(networkType);
        }

        public async Task<OperationResult> GetAllNetworkTypeAsync()
        {
            return await _networkTypeRepository.GetAll();
        }

        public async Task<OperationResult> GetByIDNetworkTypeAsync(int id)
        {
            return await _networkTypeRepository.GetEntityBy(id);
        }

        public async Task<OperationResult> SaveNetworkTypeAsync(NetworkType networkType)
        {
            return await _networkTypeRepository.Save(networkType);
        }

        public async Task<OperationResult> UpdateNetworkTypeAsync(NetworkType networkType)
        {
            return await _networkTypeRepository.Update(networkType);
        }
    }
}
