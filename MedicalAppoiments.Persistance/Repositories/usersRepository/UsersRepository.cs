
using MedicalAppoiments.Domain.Entities.system;
using MedicalAppoiments.Domain.Entities.users;
using MedicalAppoiments.Domain.Result;
using MedicalAppoiments.Persistance.Base;
using MedicalAppoiments.Persistance.Context;
using MedicalAppoiments.Persistance.Interfaces.Iusers;
using MedicalAppoiments.Persistance.Models.usersModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MedicalAppoiments.Persistance.Repositories.usersRepository
{
    public class UsersRepository : BaseRepository<Users>, IUsersRepository
    {
        private readonly MedicalAppointmentContext _medicalAppointmentContext;
        private readonly ILogger<UsersRepository> _logger;

        public UsersRepository(MedicalAppointmentContext medicalAppointmentContext, ILogger<UsersRepository> logger)
            : base(medicalAppointmentContext)
        {
            _medicalAppointmentContext = medicalAppointmentContext;
            _logger = logger;
        }

        public async override Task<OperationResult> Save(Users entity)
        {
            OperationResult operationResult = new OperationResult();

            if (entity.FirstName == null || entity.FirstName.Length >=100)
            {
                operationResult.success = false;
                operationResult.message = "Nombre requerido y debe ser menor a 100 caracteres  ";
                return operationResult;
            }
            if (entity.LastName == null || entity.LastName.Length >= 100)
            {
                operationResult.success = false;
                operationResult.message = "Apellido requerido y debe ser menor a 100 caracteres  ";
                return operationResult;
            }

            if (entity.Email == null || entity.Email.Length >= 250)
            {
                operationResult.success = false;
                operationResult.message = "Email requerido y debe ser menor a 250 caracteres  ";
                return operationResult;
            }

            if (entity.Password == null || entity.Password.Length >= 250)
            {
                operationResult.success = false;
                operationResult.message = "Password requerido y debe ser menor a 250 caracteres  ";
                return operationResult;
            }

           if (entity.RoleID == null)
            {
                operationResult.success = false;
                operationResult.message = "RoleID requerido y debe ser menor a 250 caracteres  ";
                return operationResult;
            }

            var roleExists = await _medicalAppointmentContext.Roles.AnyAsync(r => r.RoleID == entity.RoleID);
            if (!roleExists)
            {
                operationResult.success = false;
                operationResult.message = "El RoleID proporcionado no existe en la tabla Roles.";
                return operationResult;
            }

            if (await base.Exists(user => user.Password == entity.Password 
            || user.Email == entity.Email ))
                                                
            {
                operationResult.success = false;
                operationResult.message = "Correo O Contraseña ya existen.";
                return operationResult;
            }

            try
            {
                operationResult = await base.Save(entity);
            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error guardando creando el Usuario.";
                _logger.LogError(operationResult.message, ex);
            }

            return operationResult;

        }

        public async override Task<OperationResult> Update(Users entity)
        {
            OperationResult operationResult = new OperationResult();

            if (entity.FirstName == null || entity.FirstName.Length >= 100)
            {
                operationResult.success = false;
                operationResult.message = "Nombre requerido y debe ser menor a 100 caracteres  ";
                return operationResult;
            }
            if (entity.LastName == null || entity.LastName.Length >= 100)
            {
                operationResult.success = false;
                operationResult.message = "Apellido requerido y debe ser menor a 100 caracteres  ";
                return operationResult;
            }

            if (entity.Email == null || entity.Email.Length >= 250 )
            {
                operationResult.success = false;
                operationResult.message = "Email requerido, debe contener '@' y ser menor a 250 caracteres.";
                return operationResult;
            }

            if (entity.Password == null || entity.Password.Length >= 250)
            {
                operationResult.success = false;
                operationResult.message = "Password requerido y debe ser menor a 250 caracteres  ";
                return operationResult;
            }



            try
            {
                Users usertoUpdate = await _medicalAppointmentContext.Users.FindAsync(entity.UserID);
                if (usertoUpdate == null)
                {
                    operationResult.success = false;
                    operationResult.message = "El User ID no existe";
                    return operationResult;
                }

                usertoUpdate.RoleID = entity.RoleID;
                usertoUpdate.FirstName = entity.FirstName;
                usertoUpdate.LastName = entity.LastName;
                usertoUpdate.UpdatedAt = DateTime.Now;
                usertoUpdate.Email = entity.Email;
                usertoUpdate.Password = entity.Password;
                usertoUpdate.IsActive = entity.IsActive;
                

                operationResult = await base.Update(usertoUpdate);

            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error actualizando el registro.";
                _logger.LogError(operationResult.message, ex.ToString());
            }
            return operationResult;

        }

        public async override Task<OperationResult> Remove(Users entity)
        {
            OperationResult operationResult = new OperationResult();

            if(entity.UserID <=0) 
            {
                operationResult.success = false;
                operationResult.message = "El UserID proporcionado no es valido";
                return operationResult;
            }
            try
            {
                Users usertoRemove = await _medicalAppointmentContext.Users.FindAsync(entity.UserID);
                if (usertoRemove == null)
                {
                    operationResult.success = false;
                    operationResult.message = "El User ID no existe";
                    return operationResult;
                }
                usertoRemove.IsActive = false;
                usertoRemove.UpdatedAt = DateTime.Now;

                operationResult = await base.Remove(usertoRemove);

            }
            catch (Exception ex)
            {

                operationResult.success = false;
                operationResult.message = "Error actualizando el registro.";
                _logger.LogError(operationResult.message, ex.ToString());
            }
            return operationResult;
        
        }

        public async override Task<OperationResult> GetAll()
        {
            OperationResult operationResult = new OperationResult();

            try
            {
                operationResult.Data = await (from u in _medicalAppointmentContext.Users
                                              join r in _medicalAppointmentContext.Roles on u.RoleID equals r.RoleID
                                              where u.IsActive
                                              select new UserModel
                                              {
                                                  UserID = u.UserID,
                                                  FirstName = u.FirstName,
                                                  LastName = u.LastName,
                                                  Email = u.Email,
                                                  RoleName = r.RoleName,
                                                  IsActive = u.IsActive,

                                              }).ToListAsync();
                if (operationResult.Data.Count == 0)
                {
                    operationResult.success = false;
                    operationResult.message = "No se encontró registro de Users.";
                    return operationResult;
                }
                else
                {
                    operationResult.success = true;
                }
            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error opteniendo todos los Users";
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
                operationResult.Data = await (from u in _medicalAppointmentContext.Users
                                              join r in _medicalAppointmentContext.Roles on u.RoleID equals r.RoleID
                                              where u.IsActive && u.UserID == id
                                              select new UserModel
                                              {
                                                  UserID = u.UserID,
                                                  FirstName = u.FirstName,
                                                  LastName = u.LastName,
                                                  Email = u.Email,
                                                  IsActive = u.IsActive,
                                                  RoleID = r.RoleID,
                                                  Password = u.Password,

                                              }).FirstOrDefaultAsync();
                if (operationResult.Data == null)
                {
                    operationResult.success = false;
                    operationResult.message = "No se encontró registro de Users.";
                    return operationResult;
                }
                else
                {
                    operationResult.success = true;
                }
            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error al obtener el user.";
                _logger.LogError(operationResult.message, ex);
            }

            return operationResult;
        }

    }


}
