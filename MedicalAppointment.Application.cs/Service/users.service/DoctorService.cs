
using MedicalAppoiments.Domain.Entities.users;
using MedicalAppoiments.Domain.Result;
using MedicalAppoiments.Persistance.Interfaces.Iusers;
using MedicalAppointment.Application.Interfaces.Iusersservice;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Application.Service.users.service
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorsRepository _doctorRepository;
        private readonly ILogger<DoctorService> _logger;

        public DoctorService(IDoctorsRepository doctorRepository, ILogger<DoctorService> logger)
        {
            _doctorRepository = doctorRepository;
            _logger = logger;
        }

        public async Task<OperationResult> GetAllDoctorsAsync()
        {
            return await _doctorRepository.GetAll();
        }

        public async Task<OperationResult> GetDoctorByIdAsync(int id)
        {
            return await _doctorRepository.GetEntityBy(id);
        }

        public async Task<OperationResult> SaveDoctorAsync(Doctors doctor)
        {
            return await _doctorRepository.Save(doctor);
        }

        public async Task<OperationResult> UpdateDoctorAsync(Doctors doctor)
        {
            return await _doctorRepository.Update(doctor);
        }

        public async Task<OperationResult> RemoveDoctorAsync(Doctors doctor)
        {
            return await _doctorRepository.Remove(doctor);
        }
    }
}


