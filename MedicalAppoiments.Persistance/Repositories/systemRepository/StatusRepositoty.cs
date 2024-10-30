using MedicalAppoiments.Domain.Entities.system;
using MedicalAppoiments.Domain.Result;
using MedicalAppoiments.Persistance.Base;
using MedicalAppoiments.Persistance.Context;
using MedicalAppoiments.Persistance.Interfaces.Isystem;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MedicalAppoiments.Persistance.Repositories.systemRepository
{
    public class StatusRepositoty : BaseRepository<Status>, IStatusRepositoty
    {
        private readonly MedicalAppointmentContext _medicalAppointmentContext;
        private readonly ILogger<StatusRepositoty> _logger;
        public StatusRepositoty(MedicalAppointmentContext medicalAppointmentContext, ILogger<StatusRepositoty> logger) : base(medicalAppointmentContext)
        {
            _medicalAppointmentContext = medicalAppointmentContext;
            _logger = logger;
        }

        public async override Task<OperationResult> Save(Status entity)
        {
            OperationResult operationResult = new OperationResult();

            if (entity.StatusName == null || entity.StatusName.Length >= 50)
            {
                operationResult.success = false;
                operationResult.message = "Status Name requerido y debe contener menor de 50 caracteres.";
                return operationResult;
            }

            try
            {
                operationResult = await base.Save(entity);
            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error creando el Status.";
                _logger.LogError(operationResult.message, ex);
            }

            return operationResult;
        }

        public async override Task<OperationResult> Update(Status entity)
        {
            OperationResult operationResult = new OperationResult();
            if (entity.StatusName == null || entity.StatusName.Length >= 50)
            {
                operationResult.success = false;
                operationResult.message = "Status Name requerido y debe contener menor de 50 caracteres.";
                return operationResult;
            }
            try
            {
                Status statustoUpdate = await _medicalAppointmentContext.Status.FindAsync(entity.StatusID);
                if (statustoUpdate == null)
                {
                    operationResult.success = false;
                    operationResult.message = "Status ID no existe";
                    return operationResult;
                }

                statustoUpdate.StatusID = entity.StatusID;
                statustoUpdate.StatusName = entity.StatusName;


                operationResult = await base.Update(statustoUpdate);

            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error actualizando el asiento.";
                _logger.LogError(operationResult.message, ex.ToString());
            }
            return operationResult;
        }

        public async override Task<OperationResult> Remove(Status entity)
        {
            OperationResult operationResult = new OperationResult();

            if (entity.StatusName == null || entity.StatusName.Length >= 50)
            {
                operationResult.success = false;
                operationResult.message = "Status Name no valido.";
                return operationResult;
            }
            if (entity.StatusID <= 0)
            {
                operationResult.success = false;
                operationResult.message = "Se requiere el ID del Status para realizar esta operación.";
                return operationResult;
            }

            try
            {
                Status statustoUpdate = await _medicalAppointmentContext.Status.FindAsync(entity.StatusID);
                if (statustoUpdate == null)
                {
                    operationResult.success = false;
                    operationResult.message = "Status ID no existe";
                    return operationResult;
                }

                statustoUpdate.StatusID = entity.StatusID;
                statustoUpdate.StatusName = entity.StatusName;


                operationResult = await base.Update(statustoUpdate);

            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error actualizando el asiento.";
                _logger.LogError(operationResult.message, ex.ToString());
            }
            return operationResult;
        }

        public async override Task<OperationResult> GetAll()
        {
            OperationResult operationResult = new OperationResult();

            try
            {
                var status = await _medicalAppointmentContext.Status.ToListAsync();
                operationResult.success = true;
                operationResult.Data = status;
            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error al  obtener todos los Status.";
                _logger.LogError(operationResult.message, ex);
            }

            return operationResult;
        }

        public async override Task<OperationResult> GetEntityBy(int id)
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
                var status = await _medicalAppointmentContext.Status.FindAsync(id);
                if (status == null)
                {
                    operationResult.success = false;
                    operationResult.message = "El status no existe.";
                    return operationResult;
                }

                operationResult.success = true;
                operationResult.Data = status;
            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error al obtener el Status.";
                _logger.LogError(operationResult.message, ex);
            }

            return operationResult;
        }
    }

}





