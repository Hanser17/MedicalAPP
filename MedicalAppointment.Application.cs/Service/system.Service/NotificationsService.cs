
using MedicalAppoiments.Domain.Entities.system;
using MedicalAppoiments.Domain.Result;
using MedicalAppoiments.Persistance.Interfaces.Isystem;
using MedicalAppointment.Application.Interfaces.IsystemService;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Application.Service.system
{
    public class NotificationsService : INotificationsService
    {
        private readonly INotificationsRepository _notificationsRepository;
        private readonly ILogger<NotificationsService> _logger;

        public NotificationsService(INotificationsRepository notificationsRepository, ILogger<NotificationsService> logger)
        {
            _notificationsRepository = notificationsRepository;
            _logger = logger;
        }

        public async Task<OperationResult> GetAllNotificationsAsync()
        {
            return await _notificationsRepository.GetAll();
        }

        public async Task<OperationResult> GetNotificationByIdAsync(int id)
        {
            return await _notificationsRepository.GetEntityBy(id);
        }

        public async Task<OperationResult> SaveNotificationAsync(Notifications notification)
        {
            return await _notificationsRepository.Save(notification);
        }

        public async Task<OperationResult> UpdateNotificationAsync(Notifications notification)
        {
            return await _notificationsRepository.Update(notification);
        }

        public async Task<OperationResult> RemoveNotificationAsync(Notifications notification)
        {
            return await _notificationsRepository.Remove(notification);
        }
    }
}
