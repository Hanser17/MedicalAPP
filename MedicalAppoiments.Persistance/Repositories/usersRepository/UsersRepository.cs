using MedicalAppoiments.Domain.Entities.appointments;
using MedicalAppoiments.Domain.Entities.system;
using MedicalAppoiments.Domain.Entities.users;
using MedicalAppoiments.Domain.Result;
using MedicalAppoiments.Persistance.Base;
using MedicalAppoiments.Persistance.Context;
using MedicalAppoiments.Persistance.Interfaces.Iusers;
using MedicalAppoiments.Persistance.Repositories.appointmentsRepository;
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
            medicalAppointmentContext = medicalAppointmentContext;
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

            if (await base.Exists(user => user.Password == entity.Password 
            && user.Email == entity.Email ))
                                                
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


    }


}
