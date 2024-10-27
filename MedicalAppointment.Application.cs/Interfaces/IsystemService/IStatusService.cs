

using MedicalAppoiments.Domain.Entities.system;
using MedicalAppoiments.Domain.Result;

namespace MedicalAppointment.Application.Interfaces.IsystemService
{
    public interface  IStatusService
    {
        Task<OperationResult> GetAllStatus();
        Task<OperationResult> GetStatusByID(int id);
        Task<OperationResult> SaveStatusAsync(Status status);
        Task<OperationResult> UpdateStatusAsync(Status status);
        Task<OperationResult> RemoveStatusAsync(Status status);

    }
}
