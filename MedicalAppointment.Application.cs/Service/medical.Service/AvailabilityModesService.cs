using MedicalAppoiments.Domain.Entities.medical;
using MedicalAppoiments.Domain.Result;
using MedicalAppoiments.Persistance.Interfaces.Imedical;
using MedicalAppointment.Application.Interfaces.ImedicalService;
using Microsoft.Extensions.Logging;


namespace MedicalAppointment.Application.Service.medical.Service
{
    public class AvailabilityModesService : IAvailabilityModesService
    {
        private readonly IAvailabilityModesRepository _availabilityModesRepository;
        private readonly ILogger<AvailabilityModesService> _logger;

        public AvailabilityModesService(IAvailabilityModesRepository availabilityModesRepository, ILogger<AvailabilityModesService> logger)
        {
            _availabilityModesRepository = availabilityModesRepository;
            _logger = logger;
        }
        public async Task<OperationResult> DeleteAvailabilityModesAsync(AvailabilityModes availabilityModes)
        {
            return await _availabilityModesRepository.Remove(availabilityModes);
        }

        public async Task<OperationResult> GetAllAvailabilityModesAsync()
        {
            return await _availabilityModesRepository.GetAll();
        }

        public async Task<OperationResult> GetByIDAvailabilityModesAsync(int id)
        {
            return await _availabilityModesRepository.GetEntityBy(id);
        }

        public async Task<OperationResult> SaveAvailabilityModesAsync(AvailabilityModes availabilityModes)
        {
            return await _availabilityModesRepository.Save(availabilityModes);
        }

        public async Task<OperationResult> UpdateAvailabilityModesAsync(AvailabilityModes availabilityModes)
        {
            return await _availabilityModesRepository.Update(availabilityModes);
        }
    }
}
