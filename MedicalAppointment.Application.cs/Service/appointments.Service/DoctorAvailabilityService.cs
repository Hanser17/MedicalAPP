

using MedicalAppoiments.Domain.Entities.appointments;
using MedicalAppoiments.Domain.Result;
using MedicalAppoiments.Persistance.Interfaces.Iappointments;
using MedicalAppoiments.Persistance.Interfaces.Iusers;
using MedicalAppoiments.Persistance.Repositories.usersRepository;
using MedicalAppointment.Application.Interfaces.IappointmentsService;
using MedicalAppointment.Application.Service.users.service;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Application.Service.appointments.Service
{
    public class DoctorAvailabilityService : IDoctorAvailabilityService
    {
        private readonly IDoctorAvailabilityRepository _doctorAvailabilityRepository;
        private readonly ILogger<DoctorAvailabilityService> _logger;

        public DoctorAvailabilityService(IDoctorAvailabilityRepository doctorAvailabilityRepository, ILogger<DoctorAvailabilityService> logger)
        {
            _doctorAvailabilityRepository = doctorAvailabilityRepository;
            _logger = logger;
        }

        public async Task<OperationResult> GetAllDoctorAvailabilityAsync()
        {
            return await _doctorAvailabilityRepository.GetAll();
        }

        public async Task<OperationResult> GetDoctorAvailabilityByIdAsync(int id)
        {
            return await _doctorAvailabilityRepository.GetEntityBy(id);
        }

        public async Task<OperationResult> RemoveDoctorAvailabilityAsync(DoctorAvailability doctorAvailability)
        {
            return await _doctorAvailabilityRepository.Remove(doctorAvailability);
        }

        public async Task<OperationResult> SaveDoctorAvailabilityAsync(DoctorAvailability doctorAvailability)
        {
            return await _doctorAvailabilityRepository.Save(doctorAvailability);
        }

        public async Task<OperationResult> UpdateDoctorAvailabilityAsync(DoctorAvailability doctorAvailability)
        {
            return await _doctorAvailabilityRepository.Update(doctorAvailability);
        }
    }
}
