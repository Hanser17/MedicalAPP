

using MedicalAppoiments.Domain.Entities.system;
using MedicalAppoiments.Domain.Result;

namespace MedicalAppointment.Application.Interfaces.IsystemService
{
    public interface IRolesService
    {
        Task<OperationResult> GetAllRoles();
        Task<OperationResult> GetRolesByID(int id);
        Task<OperationResult> SaveRolesAsync(Roles roles);
        Task<OperationResult> UpdateRolesAsync(Roles roles);
        Task<OperationResult> RemoveRolesAsync(Roles roles);

    }
}
