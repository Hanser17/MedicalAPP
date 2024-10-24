using MedicalAppoiments.Domain.Entities.medical;
using MedicalAppoiments.Domain.Result;
using MedicalAppoiments.Persistance.Base;
using MedicalAppoiments.Persistance.Context;
using MedicalAppoiments.Persistance.Interfaces.Imedical;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MedicalAppoiments.Persistance.Repositories.medicalRepository
{
    public class AvailabilityModesRepository : BaseRepository<AvailabilityModes>, IAvailabilityModesRepository
    {
        private readonly MedicalAppointmentContext _medicalAppointmentContext;
        private readonly ILogger<AvailabilityModesRepository> _logger;
        public AvailabilityModesRepository(MedicalAppointmentContext medicalAppointmentContext, ILogger<AvailabilityModesRepository> logger)
           : base(medicalAppointmentContext)
        {
            medicalAppointmentContext = medicalAppointmentContext;
            _logger = logger;
        }

        public async override Task<OperationResult> Save(AvailabilityModes entity)
        {
            var operationResult = new OperationResult();

            if (string.IsNullOrEmpty(entity.AvailabilityMode))
            {
                operationResult.success = false;
                operationResult.message = "AvailabilityMode requerido ";
                return operationResult;
            }
            try
            {
                operationResult = await base.Save(entity);

            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error guardando el AvailabilityModes";
                _logger.LogError(operationResult.message, ex);
            }

            return operationResult;

        }

        public async override Task<OperationResult> Update(AvailabilityModes entity)
        {
            var operationResult = new OperationResult();

            if (string.IsNullOrEmpty(entity.AvailabilityMode))
            {
                operationResult.success = false;
                operationResult.message = "AvailabilityMode requerido ";
                return operationResult;
            }

            try
            {
                AvailabilityModes availabilityModesToUpdate = await _medicalAppointmentContext.AvailabilityModes.FindAsync(entity.SAvailabilityModeID);

                availabilityModesToUpdate.AvailabilityMode = entity.AvailabilityMode;
                availabilityModesToUpdate.UpdatedAt = entity.UpdatedAt;
                availabilityModesToUpdate.IsActive = entity.IsActive;


            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error actualizando el AvailabilityModes.";
                _logger.LogError(operationResult.message, ex.ToString());
            }
            return operationResult;
        }

        public async override Task<OperationResult> Remove(AvailabilityModes entity)
        {
            var operationResult = new OperationResult();

            if (string.IsNullOrEmpty(entity.AvailabilityMode))
            {
                operationResult.success = false;
                operationResult.message = "AvailabilityMode requerido ";
                return operationResult;
            }

            try
            {
                AvailabilityModes availabilityModesToRemove = await _medicalAppointmentContext.AvailabilityModes.FindAsync(entity.SAvailabilityModeID);

                availabilityModesToRemove.UpdatedAt = entity.UpdatedAt;
                availabilityModesToRemove.IsActive = false;
            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error Borrando el AvailabilityModes.";
                _logger.LogError(operationResult.message, ex.ToString());
            }
            return operationResult;
        }

        public async Task<OperationResult> GetAll()
        {

            var operationResult = new OperationResult();

            try
            {
                var availabilityModes = await _medicalAppointmentContext.AvailabilityModes.ToListAsync();
                operationResult.success = true;
                operationResult.Data = availabilityModes;

            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error al obtener los las AvailabilityModes.";
                _logger.LogError(operationResult.message, ex);

            }
            return operationResult;
        }

        public async Task<OperationResult> GetEntityBy(int id)
        {
            var operationResult = new OperationResult();

            if (id <= 0)
            {
                operationResult.success = false;
                operationResult.message = "Se requiere un ID válido para realizar esta operación.";
                return operationResult;
            }

            try
            {
                var availabilityModes = await _medicalAppointmentContext.AvailabilityModes.FindAsync(id);
                if (availabilityModes == null)
                {
                    operationResult.success = false;
                    operationResult.message = "La AvailabilityModes no existe.";
                    return operationResult;
                }

                operationResult.success = true;
                operationResult.Data = availabilityModes;
            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error al obtener la AvailabilityModes .";
                _logger.LogError(operationResult.message, ex);
            }

            return operationResult;
        }

    } 
}
