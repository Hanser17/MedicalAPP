using MedicalAppoiments.Domain.Entities.appointments;
using MedicalAppoiments.Domain.Entities.system;
using MedicalAppoiments.Domain.Result;
using MedicalAppoiments.Persistance.Base;
using MedicalAppoiments.Persistance.Context;
using MedicalAppoiments.Persistance.Interfaces.Isystem;
using MedicalAppoiments.Persistance.Models;
using MedicalAppoiments.Persistance.Repositories.appointmentsRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MedicalAppoiments.Persistance.Repositories.systemRepository
{
    public class RolesRepository : BaseRepository<Roles>, IRolesRepository
    {
        private readonly MedicalAppointmentContext _medicalAppointmentContext;
        private readonly ILogger<RolesRepository> _logger;

        public RolesRepository(MedicalAppointmentContext medicalAppointmentContext, ILogger<RolesRepository> logger)
            : base(medicalAppointmentContext)
        {
            _medicalAppointmentContext = medicalAppointmentContext;
            _logger = logger;
        }

        public async override Task<OperationResult> Save(Roles entity)
        {
            OperationResult operationResult = new OperationResult();

            if (entity.RoleName == null && entity.RoleName.Length <= 50)
            {
                operationResult.success = false;
                operationResult.message = "RoleName requerido y debe contener menor de 50 caracteres.";
                return operationResult;
            }

            try
            {
                operationResult = await base.Save(entity);
            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error creando el Role.";
                _logger.LogError(operationResult.message, ex);
            }

            return operationResult;
        }

      
        public async override Task<OperationResult> Update(Roles entity)
        {
            OperationResult operationResult = new OperationResult();
            if (entity.RoleName == null && entity.RoleName.Length <= 50)
                {
                    operationResult.success = false;
                    operationResult.message = "RoleName requerido y debe contener menor de 50 caracteres.";
                    return operationResult;
                }
            try 
            {
                Roles rolestoUpdate = await _medicalAppointmentContext.Roles.FindAsync(entity.RoleID);
                if(rolestoUpdate == null) 
                {
                    operationResult.success = false;
                    operationResult.message = "El Role ID no existe";
                    return operationResult; 
                }

                rolestoUpdate.RoleID = entity.RoleID;  
                rolestoUpdate.RoleName = entity.RoleName;
                rolestoUpdate.UpdatedAt = DateTime.Now;
                rolestoUpdate.IsActive = entity.IsActive;

                operationResult = await base.Update(rolestoUpdate);

            }
            catch (Exception ex) 
            {
                operationResult.success = false;
                operationResult.message = "Error actualizando el asiento.";
                _logger.LogError(operationResult.message, ex.ToString());
            }
            return operationResult;
        }

        public async override Task<OperationResult> Remove(Roles entity)
        {
            OperationResult operationResult = new OperationResult();

            if (entity.RoleName == null && entity.RoleName.Length <= 50)
            {
                operationResult.success = false;
                operationResult.message = "RoleName requerido y debe contener menor de 50 caracteres.";
                return operationResult;
            }
            if (entity.RoleID <= 0)
            {
                operationResult.success = false;
                operationResult.message = "Se requiere el ID del Role para realizar esta operación.";
                return operationResult;
            }

            try
            {
                Roles roleToRemove = await _medicalAppointmentContext.Roles.FindAsync(entity.RoleID);
                roleToRemove.RoleID = entity.RoleID;
                roleToRemove.RoleName = entity.RoleName;
                roleToRemove.IsActive = entity.IsActive;
                roleToRemove.UpdatedAt = entity.UpdatedAt;


                await base.Update(roleToRemove);

            }
            catch (Exception ex)
            {

                operationResult.success = false;
                operationResult.message = "Error desactivando el asiento.";
                _logger.LogError(operationResult.message, ex.ToString());
            }
            return operationResult;

        }

        public async Task<OperationResult> GetAll()
        {
            OperationResult operationResult = new OperationResult();

            try
            {
                var roles = await _medicalAppointmentContext.Roles.ToListAsync();
                operationResult.success = true;
                operationResult.Data = roles; 
            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error al obtener los roles.";
                _logger.LogError(operationResult.message, ex);
            }

            return operationResult;
        }

        public async Task<OperationResult> GetById(int id)
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
                var role = await _medicalAppointmentContext.Roles.FindAsync(id);
                if (role == null)
                {
                    operationResult.success = false;
                    operationResult.message = "El Role no existe.";
                    return operationResult;
                }

                operationResult.success = true;
                operationResult.Data = role; 
            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error al obtener el rol.";
                _logger.LogError(operationResult.message, ex);
            }

            return operationResult;
        }


    }
}
