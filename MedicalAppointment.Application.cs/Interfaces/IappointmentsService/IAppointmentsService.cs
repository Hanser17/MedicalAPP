

using MedicalAppoiments.Domain.Entities.appointments;
using MedicalAppoiments.Domain.Entities.users;
using MedicalAppoiments.Domain.Result;

namespace MedicalAppointment.Application.Interfaces.IappointmentsService
{
    public interface IAppointmentsService
    {
        Task<OperationResult> GetAllAppointmentsAsync();
        Task<OperationResult> GetAppointmentsByIdAsync(int id);
        Task<OperationResult> SaveAppointmentsAsync(Appointments appointments);
        Task<OperationResult> UpdateAppointmentsAsync(Appointments appointments);
        Task<OperationResult> RemoveAppointmentsAsync(Appointments appointments);
    }
}
