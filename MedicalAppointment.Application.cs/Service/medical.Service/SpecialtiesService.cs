

using MedicalAppoiments.Domain.Entities.medical;
using MedicalAppoiments.Domain.Result;
using MedicalAppoiments.Persistance.Interfaces.Imedical;
using MedicalAppointment.Application.Interfaces.ImedicalService;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Application.Service.medical.Service
{
    public class SpecialtiesService : ISpecialtiesService
    {
        private readonly ISpecialtiesRepository _specialtiesRepository;
        private readonly ILogger<SpecialtiesService> _logger;

        public SpecialtiesService (ISpecialtiesRepository specialtiesRepository,  ILogger<SpecialtiesService> logger)
        {
            _specialtiesRepository = specialtiesRepository;
            _logger = logger;
        }

        public  async Task<OperationResult> DeleteSpecialtiesAsync(Specialties specialties)
        {
            return await _specialtiesRepository.Remove(specialties);
        }

        public async Task<OperationResult> GetAllSpecialtiesAsync()
        {
            return await _specialtiesRepository.GetAll();
        }

        public async Task<OperationResult> GetByIDSpecialtiesAsync(int id)
        {
            return await _specialtiesRepository.GetEntityBy(id);
        }
    

        public async Task<OperationResult> SaveSpecialtiesAsync(Specialties specialties)
        {
            return await _specialtiesRepository.Save(specialties);
        }

        public async Task<OperationResult> UpdateSpecialtiesAsync(Specialties specialties)
        {
            return await _specialtiesRepository.Update(specialties);
        }
    }
}
