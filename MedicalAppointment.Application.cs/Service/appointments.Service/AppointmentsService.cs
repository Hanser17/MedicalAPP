

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
    public class AppointmentsService : IAppointmentsService
    {
        private readonly IAppointmentsRepository _appointmentsRepository;
        private readonly ILogger<AppointmentsService> _logger;

        public AppointmentsService(IAppointmentsRepository appointmentsRepository, ILogger<AppointmentsService> logger)
        {
            _appointmentsRepository = appointmentsRepository;
            _logger = logger;
        }

        public async Task<OperationResult> GetAllAppointmentsAsync()
        {
            return await _appointmentsRepository.GetAll();
        }

        public async Task<OperationResult> GetAppointmentsByIdAsync(int id)
        {
            return await _appointmentsRepository.GetEntityBy(id);
        }

        public async Task<OperationResult> RemoveAppointmentsAsync(Appointments appointments)
        {
            return await _appointmentsRepository.Remove(appointments);
        }

        public async Task<OperationResult> SaveAppointmentsAsync(Appointments appointments)
        {
            return await _appointmentsRepository.Save(appointments);
        }

        public async Task<OperationResult> UpdateAppointmentsAsync(Appointments appointments)
        {
            return await _appointmentsRepository.Update(appointments);
        }
    }
}
