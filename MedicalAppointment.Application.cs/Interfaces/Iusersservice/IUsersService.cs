

using MedicalAppoiments.Domain.Entities.users;
using MedicalAppoiments.Domain.Result;

namespace MedicalAppointment.Application.Interfaces.Iusersservice
{
    public interface IUsersService
    {
        Task<OperationResult> SaveUser(Users user);
        Task<OperationResult> UpdateUser(Users user);
        Task<OperationResult> RemoveUser(int userId);
        Task<OperationResult> GetAllUsers();
        Task<OperationResult> GetUserById(int userId);
    }
}
