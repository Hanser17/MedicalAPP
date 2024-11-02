

using MedicalAppoiments.Domain.Entities.users;
using MedicalAppoiments.Domain.Result;

namespace MedicalAppointment.Application.Interfaces.Iusersservice
{
  
    public interface IDoctorService
    {
        Task<OperationResult> GetAllDoctorsAsync();
        Task<OperationResult> GetDoctorByIdAsync(int id);
        Task<OperationResult> GetDoctorByAvailabilityAsync(int id);
        Task<OperationResult> GetDoctorBySpecialtyAsync(int id);
        Task<OperationResult> SaveDoctorAsync(Doctors doctor);
        Task<OperationResult> UpdateDoctorAsync(Doctors doctor);
        Task<OperationResult> RemoveDoctorAsync(int DoctorID);
    }
}

