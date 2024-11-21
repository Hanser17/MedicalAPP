using MedicalAppoiments.Domain.Entities.insurance;

using MedicalAppoiments.Domain.Result;
using MedicalAppoiments.Persistance.Base;
using MedicalAppoiments.Persistance.Context;
using MedicalAppoiments.Persistance.Interfaces.Iinsurance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MedicalAppoiments.Persistance.Repositories.insuranceRepository
{
    public class NetworkTypeRepository : BaseRepository<NetworkType>, INetworkTypeRepository

    {
        private readonly MedicalAppointmentContext _medicalAppointmentContext;
        private readonly ILogger<NetworkTypeRepository> _logger;

        public NetworkTypeRepository(MedicalAppointmentContext medicalAppointmentContext, ILogger<NetworkTypeRepository> logger) : base(medicalAppointmentContext)
        {
            _medicalAppointmentContext = medicalAppointmentContext;
            _logger = logger;
        }
        public async override Task<OperationResult> Save(NetworkType entity)
        {
            OperationResult operationResult = new OperationResult();


            
            if (string.IsNullOrEmpty(entity.Name) || entity.Name.Length >= 50)
            {
                operationResult.success = false;
                operationResult.message = "Name no valida, no puede ser mayor a 50 caracteres  ";
                return operationResult;
            }

            if (entity.Description.Length >= 50)
            {
                operationResult.success = false;
                operationResult.message = "Description no puede ser mayor a 50 caracteres  ";
                return operationResult;
            }
            try
            {
                operationResult = await base.Save(entity);
            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error guardando Datos del Doctor.";
                _logger.LogError(operationResult.message, ex);
            }

            return operationResult;
        }

        public async override Task<OperationResult> Update(NetworkType entity)
        {
            OperationResult operationResult = new OperationResult();

            if (string.IsNullOrEmpty(entity.Name) || entity.Name.Length >= 50)
            {
                operationResult.success = false;
                operationResult.message = "Name no valida, no puede ser mayor a 50 caracteres  ";
                return operationResult;
            }

            if (entity.Description.Length >= 50)
            {
                operationResult.success = false;
                operationResult.message = "Description no puede ser mayor a 50 caracteres  ";
                return operationResult;
            }
            try
            {
                NetworkType networkTypetoUpdate = await _medicalAppointmentContext.NetworkType.FindAsync(entity.NetworkTypeId);
                if (networkTypetoUpdate == null)
                {
                    operationResult.success = false;
                    operationResult.message = "El Doctor ID no existe";
                    return operationResult;
                }


                networkTypetoUpdate.Name = entity.Name;
                networkTypetoUpdate.Description = entity.Description;
                networkTypetoUpdate.UpdatedAt = DateTime.Now;
                networkTypetoUpdate.IsActive = entity.IsActive;


                operationResult = await base.Update(networkTypetoUpdate);

            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error actualizando el registro.";
                _logger.LogError(operationResult.message, ex.ToString());
            }
            return operationResult;

        }

        public async override Task<OperationResult> Remove(NetworkType entity)
        {
            OperationResult operationResult = new OperationResult();
            if (entity.NetworkTypeId <= 0)
            {
                operationResult.success = false;
                operationResult.message = "El NetworkTypeId proporcionado no es valido";
                return operationResult;
            }
            try
            {
                NetworkType networkTypeRemove = await _medicalAppointmentContext.NetworkType.FindAsync(entity.NetworkTypeId);
                if (networkTypeRemove == null)
                {
                    operationResult.success = false;
                    operationResult.message = "El NetworkType ID no existe";
                    return operationResult;
                }
                networkTypeRemove.IsActive = false;
                networkTypeRemove.UpdatedAt = DateTime.Now;

            }
            catch (Exception ex)
            {

                operationResult.success = false;
                operationResult.message = "Error borrando el registro.";
                _logger.LogError(operationResult.message, ex.ToString());
            }
            return operationResult;

        }

        public async override Task<OperationResult> GetAll()
        {
            OperationResult operationResult = new OperationResult();

            try
            {

                var networkType = await _medicalAppointmentContext.NetworkType.ToListAsync();
                operationResult.success = true;
                operationResult.Data = networkType;
            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error opteniendo todos los Doctores";
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
                var networkType = await _medicalAppointmentContext.NetworkType.FindAsync(id);
                if (networkType == null)
                {
                    operationResult.success = false;
                    operationResult.message = "El networkType ID no existe.";
                    return operationResult;
                }

                operationResult.success = true;
                operationResult.Data = networkType;
            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error al obtener el networkType.";
                _logger.LogError(operationResult.message, ex);
            }

            return operationResult;
        }
    }
}

