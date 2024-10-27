

using MedicalAppoiments.Domain.Entities.system;
using MedicalAppoiments.Domain.Result;

namespace MedicalAppointment.Application.Interfaces.IsystemService
{
    public interface IRolesService
    {
        Task<OperationResult> GetAllRoles();
        Task<OperationResult> GetRolesByID(int id);
        Task<OperationResult> SaveRolesAsync(Status status);
        Task<OperationResult> UpdateRolesAsync(Status status);
        Task<OperationResult> RemoveRolesAsync(Status status);

    }
}
