

using MedicalAppoiments.Domain.Entities.system;
using MedicalAppoiments.Domain.Entities.users;
using MedicalAppoiments.Domain.Result;
using MedicalAppoiments.Persistance.Base;
using MedicalAppoiments.Persistance.Context;
using MedicalAppoiments.Persistance.Interfaces.Isystem;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MedicalAppoiments.Persistance.Repositories.systemRepository
{
    public class NotificationsRepository : BaseRepository<Notifications>, INotificationsRepository
    {
        private readonly MedicalAppointmentContext _medicalAppointmentContext;
        private readonly ILogger<NotificationsRepository> _logger;
        public NotificationsRepository(MedicalAppointmentContext medicalAppointmentContext, ILogger<NotificationsRepository> logger)
           : base(medicalAppointmentContext)
        {
            medicalAppointmentContext = medicalAppointmentContext;
            _logger = logger;
        }

        public async override Task<OperationResult> Save(Notifications entity)
        {
            OperationResult operationResult = new OperationResult();
            if (entity.UserID <= 0)
            {
                operationResult.success = false;
                operationResult.message = "El ID no valido  ";
                return operationResult;
            }
            if (entity.Message == null)
            {
                operationResult.success = false;
                operationResult.message = "Mesaje no Valido ";
                return operationResult;
            }
            try
            {
                operationResult = await base.Save(entity);

            }catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error guardando el mensaje";
                _logger.LogError(operationResult.message, ex);
            }

            return operationResult;
        }

        public async override Task<OperationResult> Update(Notifications entity)
        {
            OperationResult operationResult = new OperationResult();

            if (entity.UserID <= 0)
            {
                operationResult.success = false;
                operationResult.message = "El ID no valido  ";
                return operationResult;
            }
            if (entity.Message == null)
            {
                operationResult.success = false;
                operationResult.message = "Mesaje no Valido ";
                return operationResult;
            }
            try
            {
                Notifications notificatieonsToUpdate = await _medicalAppointmentContext.Notifications.FindAsync(entity.NotificationID);

                notificatieonsToUpdate.NotificationID = entity.NotificationID;
                notificatieonsToUpdate.UserID = entity.UserID;
                notificatieonsToUpdate.Message = entity.Message;
                notificatieonsToUpdate.SentAt = entity.SentAt;

                operationResult = await base.Update(notificatieonsToUpdate);

            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error actualizando el asiento.";
                _logger.LogError(operationResult.message, ex.ToString());
            }
            return operationResult;
        }

        public async override Task<OperationResult> Remove(Notifications entity)
        {
            OperationResult operationResult = new OperationResult();

            if (entity.UserID <= 0)
            {
                operationResult.success = false;
                operationResult.message = "El ID no valido  ";
                return operationResult;
            }
            if (entity.Message == null)
            {
                operationResult.success = false;
                operationResult.message = "Mesaje no Valido ";
                return operationResult;
            }
            try
            {
                Notifications notificatieonsToUpdate = await _medicalAppointmentContext.Notifications.FindAsync(entity.NotificationID);

                notificatieonsToUpdate.NotificationID = entity.NotificationID;
                notificatieonsToUpdate.UserID = entity.UserID;
                notificatieonsToUpdate.Message = entity.Message;
                notificatieonsToUpdate.SentAt = entity.SentAt;

                operationResult = await base.Remove(notificatieonsToUpdate);

            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error actualizando el asiento.";
                _logger.LogError(operationResult.message, ex.ToString());
            }
            return operationResult;
        }

        public async Task<OperationResult> GetAll()
        {

            OperationResult operationResult = new OperationResult();

            try
            {
                var notifications = await _medicalAppointmentContext.Notifications.ToListAsync();
                operationResult.success = true;
                operationResult.Data = notifications;

            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error al obtener los las Notificaciones.";
                _logger.LogError(operationResult.message, ex);

            }
            return operationResult;
        }
        public async Task<OperationResult> GetEntityBy(int id)
        {
            OperationResult operationResult = new OperationResult();

            if (id <= 0)
            {
                operationResult.success = false;
                operationResult.message = "Se requiere un ID válido para realizar esta operación.";
                return operationResult;
            }

            try
            {
                var notifications = await _medicalAppointmentContext.Notifications.FindAsync(id);
                if (notifications == null)
                {
                    operationResult.success = false;
                    operationResult.message = "La Notificacion no existe.";
                    return operationResult;
                }

                operationResult.success = true;
                operationResult.Data = notifications;
            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error al obtener la notificacion .";
                _logger.LogError(operationResult.message, ex);
            }

            return operationResult;
        }

    }
}
