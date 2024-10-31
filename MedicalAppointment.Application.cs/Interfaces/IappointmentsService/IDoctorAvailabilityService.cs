

using MedicalAppoiments.Domain.Entities.appointments;
using MedicalAppoiments.Domain.Entities.users;
using MedicalAppoiments.Domain.Result;

namespace MedicalAppointment.Application.Interfaces.IappointmentsService
{
    public interface IDoctorAvailabilityService
    {
            
        Task<OperationResult> GetAllDoctorAvailabilityAsync();
        Task<OperationResult> GetDoctorAvailabilityByIdAsync(int id);
        Task<OperationResult> SaveDoctorAvailabilityAsync(DoctorAvailability doctorAvailability);
        Task<OperationResult> UpdateDoctorAvailabilityAsync(DoctorAvailability doctorAvailability);
        Task<OperationResult> RemoveDoctorAvailabilityAsync(DoctorAvailability doctorAvailability);
    }

}

