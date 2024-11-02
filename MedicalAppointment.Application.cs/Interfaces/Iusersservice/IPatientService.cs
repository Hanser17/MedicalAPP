

using MedicalAppoiments.Domain.Entities.users;
using MedicalAppoiments.Domain.Result;

namespace MedicalAppointment.Application.Interfaces.Iusersservice
{
    public interface IPatientService
    {
        Task<OperationResult> GetAllPatients();
        Task<OperationResult> GetPatientById(int id);
        Task<OperationResult> GetPatientsByInsuranceProviderAsync(int id);
        Task<OperationResult> SavePatientAsync(Patients patient);
        Task<OperationResult> UpdatePatientAsync(Patients patient);
        Task<OperationResult> RemovePatientAsync(int PatientID);

    }
}
