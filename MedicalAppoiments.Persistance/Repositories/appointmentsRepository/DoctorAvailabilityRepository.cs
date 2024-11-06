using MedicalAppoiments.Domain.Entities.appointments;
using MedicalAppoiments.Domain.Entities.users;
using MedicalAppoiments.Domain.Result;
using MedicalAppoiments.Persistance.Base;
using MedicalAppoiments.Persistance.Context;
using MedicalAppoiments.Persistance.Interfaces.Iappointments;
using MedicalAppoiments.Persistance.Repositories.usersRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MedicalAppoiments.Persistance.Repositories.appointmentsRepository
{
    public class DoctorAvailabilityRepository : BaseRepository<DoctorAvailability>, IDoctorAvailabilityRepository
    {

        private readonly MedicalAppointmentContext _medicalAppointmentContext;
        private readonly ILogger<DoctorAvailabilityRepository> _logger;

        public DoctorAvailabilityRepository(MedicalAppointmentContext medicalAppointmentContext, ILogger<DoctorAvailabilityRepository> logger) : base(medicalAppointmentContext)
        {
            _medicalAppointmentContext = medicalAppointmentContext;
            _logger = logger;
        }
        public async override Task<OperationResult> Save(DoctorAvailability entity)
        {
            OperationResult operationResult = new OperationResult();

            var DoctorExists = await _medicalAppointmentContext.Doctors.AnyAsync(d => d.DoctorID == entity.DoctorID);
            if (!DoctorExists)
            {
                operationResult.success = false;
                operationResult.message = "Este doctor no existe.";
                return operationResult;
            }
            if (entity.DoctorID <= 0)
            {
                operationResult.success = false;
                operationResult.message = "DoctorID no valido";
                return operationResult;
            }
            if (entity.AvailableDate <= DateTime.Now)
            {
                operationResult.success = false;
                operationResult.message = "Fecha de disponibilidad no puede ser en el pasado";
                return operationResult;
            }
            if (entity.StartTime <= DateTime.Now)
            {
                operationResult.success = false;
                operationResult.message = "Hora de inicio de StartTime no puede ser en el pasado";
                return operationResult;
            }
            if (entity.EndTime <= DateTime.Now)
            {
                operationResult.success = false;
                operationResult.message = "Hora de termino no puede ser en el pasado";
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

        public async override Task<OperationResult> Update(DoctorAvailability entity)
        {
            OperationResult operationResult = new OperationResult();

            var DoctorExists = await _medicalAppointmentContext.Doctors.AnyAsync(d => d.DoctorID == entity.DoctorID);
            if (!DoctorExists)
            {
                operationResult.success = false;
                operationResult.message = "Este doctor no existe.";
                return operationResult;
            }
            if (entity.DoctorID <= 0)
            {
                operationResult.success = false;
                operationResult.message = "DoctorID no valido";
                return operationResult;
            }
            if (entity.AvailableDate <= DateTime.Now)
            {
                operationResult.success = false;
                operationResult.message = "Fecha de disponibilidad no puede ser en el pasado";
                return operationResult;
            }
            if (entity.StartTime <= DateTime.Now)
            {
                operationResult.success = false;
                operationResult.message = "Hora de inicio de StartTime no puede ser en el pasado";
                return operationResult;
            }
            if (entity.EndTime <= DateTime.Now)
            {
                operationResult.success = false;
                operationResult.message = "Hora de termino no puede ser en el pasado";
                return operationResult;
            }
            try
            {
                DoctorAvailability doctorAvailabilityoUpdate = await _medicalAppointmentContext.DoctorAvailability.FindAsync(entity.AvailabilityID);
                if (doctorAvailabilityoUpdate == null)
                {
                    operationResult.success = false;
                    operationResult.message = "El DoctorAvailability ID no existe";
                    return operationResult;
                }


                doctorAvailabilityoUpdate.DoctorID = entity.DoctorID;
                doctorAvailabilityoUpdate.AvailableDate = entity.AvailableDate;
                doctorAvailabilityoUpdate.StartTime = entity.StartTime;
                doctorAvailabilityoUpdate.EndTime = entity.EndTime;
                


                operationResult = await base.Update(doctorAvailabilityoUpdate);

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

                var doctorAvailability = await _medicalAppointmentContext.DoctorAvailability.ToListAsync();
                operationResult.success = true;
                operationResult.Data = doctorAvailability;
            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error opteniendo todos la Disponibilidad de los doctors ";
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
                var doctorAvailability = await _medicalAppointmentContext.DoctorAvailability.FindAsync(id);
                if (doctorAvailability == null)
                {
                    operationResult.success = false;
                    operationResult.message = "El DoctorAvailability ID no existe.";
                    return operationResult;
                }

                operationResult.success = true;
                operationResult.Data = doctorAvailability;
            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error opteniendo todos la Disponibilidad del doctor.";
                _logger.LogError(operationResult.message, ex);
            }

            return operationResult;
        }

       public async Task<OperationResult> DoctorAvailabilityByDoctorID(int id)
        {

            OperationResult operationResult = new OperationResult();

            if (id <= 0)
            {
                operationResult.success= false;
                operationResult.message = "El ID proporcionado no es Valido";
                return operationResult;
            }
            try
            {
                operationResult.Data = await (from Da in _medicalAppointmentContext.DoctorAvailability
                                              join d in _medicalAppointmentContext.Doctors on Da.DoctorID equals d.DoctorID
                                              where d.DoctorID == id
                                              select new DoctorAvailability
                                              {
                                                  AvailabilityID = Da.AvailabilityID,
                                                  DoctorID = d.DoctorID,
                                                  AvailableDate = Da.AvailableDate,
                                                  StartTime = Da.StartTime,
                                                  EndTime = Da.EndTime,
                                              }).ToListAsync();

                if (operationResult.Data.Count == 0)
                {
                    operationResult.success = false;
                    operationResult.message = "No se encontró registro ";
                    return operationResult;
                }
                else
                {
                    operationResult.success = true;
                }

            }
            catch(Exception ex) 
            {
                operationResult.success = false;
                operationResult.message = "Error opteniendo todos la Disponibilidad del doctor.";
                _logger.LogError(operationResult.message, ex);
            }

            return operationResult;
        }
    }
}
