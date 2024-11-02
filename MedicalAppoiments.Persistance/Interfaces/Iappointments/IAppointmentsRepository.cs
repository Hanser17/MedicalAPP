using MedicalAppoiments.Domain.Entities.appointments;
using MedicalAppoiments.Domain.Repositories;
using MedicalAppoiments.Domain.Result;

namespace MedicalAppoiments.Persistance.Interfaces.Iappointments
{
    public interface IAppointmentsRepository : IBaseRepository<Appointments>
    {
        Task<OperationResult> GetAppointmentsByPatientID(int id);
        Task<OperationResult> GetAppointmentsByDoctorID(int id);
        Task<OperationResult> GetAppointmentsByStatusID(int id);

    }
}
