
using MedicalAppoiments.Domain.Result;
using MedicalAppoiments.Domain.Entities.system;
using System.Threading.Tasks;

namespace MedicalAppointment.Application.Interfaces.IsystemService
{
    public interface INotificationsService
    {
        Task<OperationResult> GetAllNotificationsAsync();
        Task<OperationResult> GetNotificationByIdAsync(int id);
        Task<OperationResult> SaveNotificationAsync(Notifications notification);
        Task<OperationResult> UpdateNotificationAsync(Notifications notification);
        Task<OperationResult> RemoveNotificationAsync(Notifications notification);
    }
}


